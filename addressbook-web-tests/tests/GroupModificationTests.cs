using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModify = oldGroups[0];

            app.Groups.Modify(toBeModify, NewData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = NewData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModify.Id)
                {
                    Assert.AreEqual(NewData.Name, group.Name);
                }
            }
        }
    }
}
