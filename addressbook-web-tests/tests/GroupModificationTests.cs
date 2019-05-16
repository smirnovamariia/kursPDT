using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            //  app.Groups.CreateBeforeModify();
            if (!app.Groups.IsAnyElement())
            {
                app.Groups.Create(new GroupData("444"));
            }
            GroupData NewData = new GroupData("ppp");
            NewData.Header = "mmm";
            NewData.Footer = "vvv";

            app.Groups.Modify(1, NewData);
        }
    }
}
