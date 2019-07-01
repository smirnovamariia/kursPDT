using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemoveTests : TestBase
    {
        [Test]
        public void RemoveProjectTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            app.Auth.Login(account);
            ProjectData project = new ProjectData() { Name = "for_remove" };
            if (! app.Project.IsExistProject(project))
            {
               
                app.Project.Create(project);
            }

         /*   List<ProjectData> oldprojects = new List<ProjectData>();
            oldprojects = app.Project.GetProjectList();
            ProjectData removedProject = oldprojects[2];
*/
            app.Project.Remove(2);

           /* oldprojects.Remove(removedProject);
            List<ProjectData> newprojects = app.Project.GetProjectList();

            oldprojects.Sort();
            newprojects.Sort();
            Assert.AreEqual(oldprojects, newprojects);*/
        }
    }
}
