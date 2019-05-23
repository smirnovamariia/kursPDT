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
            if (!app.Groups.IsAnyElement())
            {
                app.Groups.Create(new GroupData("444"));
            }
            GroupData NewData = new GroupData("ppp");
            NewData.Header = "mmm";
            NewData.Footer = "vvv";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, NewData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = NewData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
