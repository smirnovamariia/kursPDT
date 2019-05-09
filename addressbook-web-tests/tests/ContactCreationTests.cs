using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests :TestBase
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
            app.Contact.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            app.Contact.Create(contact);
        }
    }
}
