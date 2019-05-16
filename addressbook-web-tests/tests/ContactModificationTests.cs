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
            //app.Contact.CreateBeforeModify();
            if (!app.Contact.IsAnyElement())
            {
                app.Contact.Create(new ContactData("ert","wwewrew"));
            }
            ContactData NewData = new ContactData("ppp","aaa");
            NewData.Address = "mmm";
            NewData.Email = "vvv";
            NewData.Mobile = "8999";

            app.Contact.Modify(2, NewData);
        }
    }
}
