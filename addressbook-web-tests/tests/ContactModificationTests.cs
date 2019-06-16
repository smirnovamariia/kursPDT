using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
          
            if (!app.Contact.IsAnyElement())
            {
                app.Contact.Create(new ContactData("ert","wwewrew"));
            }
            ContactData NewData = new ContactData("ppp","aaa");
            NewData.Address = "mmm";
            NewData.Email = "vvv";
            NewData.Mobile = "8999";

            List<ContactData> oldContacts = ContactData.GetAllContacts();
            ContactData toBeModify = oldContacts[0];
            app.Contact.Modify(toBeModify, NewData);
            List<ContactData> newContacts = ContactData.GetAllContacts();
            oldContacts[0].Firstname = NewData.Firstname;
            oldContacts[0].Lastname = NewData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModify.Id)
                {
                    Assert.AreEqual(NewData.Firstname, contact.Firstname);
                    Assert.AreEqual(NewData.Lastname, contact.Lastname);
                }
            }
        }
    }
}
