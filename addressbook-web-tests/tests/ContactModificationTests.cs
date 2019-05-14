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
            ContactData NewData = new ContactData("ppp","aaa");
            NewData.Address = "mmm";
            NewData.Email = "vvv";
            NewData.Mobile = "8999";

            app.Contact.Modify(2, NewData);
        }
    }
}
