using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
          [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("yyy","uuu");
            contact.Nickname = "ddd";
            contact.Title = "zzz";
            contact.Email = "fdf";
            contact.Home = "rere";
            contact.Work = "fsfs";
            contact.Address = "jkjkjk";

            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contact);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contact);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
