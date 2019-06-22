using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        private int numrow;

        [Test]
        public void TestAddingContactToGroup ()
        {
            if (!app.Groups.IsAnyElement()) { app.Groups.Create(new GroupData("444")); }
            if (!app.Contact.IsAnyElement()) { app.Contact.Create(new ContactData("ert", "wwewrew")); }

  

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            if (group.CountContactsInGroups()== ContactData.GetAllContacts().Count())
            {
                numrow = ContactData.GetAllContacts().Count();
                app.Contact.Create(new ContactData("new_f"+"_"+numrow, "new_l" + "_" + numrow));
                 oldList = group.GetContacts();
            }

            ContactData contact = ContactData.GetAllContacts().Except(oldList).First();

            app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
