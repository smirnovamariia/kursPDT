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

            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Modify(1, NewData);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = NewData.Firstname;
            oldContacts[0].Lastname = NewData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
