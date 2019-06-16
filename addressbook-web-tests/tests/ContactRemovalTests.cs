using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contact.IsAnyElement())
            {
                app.Contact.Create(new ContactData("ert", "wwewrew"));
            }

            List<ContactData> oldContacts = ContactData.GetAllContacts();
            ContactData toBeRemoved = oldContacts[0];
            app.Contact.Remove(toBeRemoved);
            List<ContactData> newContacts = ContactData.GetAllContacts();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
