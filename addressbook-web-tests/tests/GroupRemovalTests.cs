using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
  
        [Test]
        public void GroupRemovalTest()
        {
            //app.Groups.CreateBeforeModify();
            if (! app.Groups.IsAnyElement())
            {
                app.Groups.Create(new GroupData("444"));
            }
            app.Groups.Remove(1);
        }

     }
}
