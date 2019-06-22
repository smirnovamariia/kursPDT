using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            if (!app.Groups.IsAnyElement()) { app.Groups.Create(new GroupData("444")); }
            if (!app.Contact.IsAnyElement()) { app.Contact.Create(new ContactData("ert", "wwewrew")); }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            if (group.CountContactsInGroups() == 0)
            {
                ContactData first_contact = ContactData.GetAllContacts()[0];
                app.Contact.AddContactToGroup(first_contact, group);
                oldList = group.GetContacts();
            }

            ContactData contact = ContactData.GetAllContacts().Intersect(oldList).First();

            app.Contact.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
