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
            
            if (app.Project.GetProjectList(account).Count() ==0)
            {
                ProjectData project = new ProjectData() { Name = "for_remove", Description = "for_remove_test" };
                app.API.CreateProjectAPI(account, project);
            }

              List<ProjectData> oldprojects = new List<ProjectData>();
               oldprojects = app.Project.GetProjectList(account);
               ProjectData removedProject = oldprojects[1];
 
            app.Project.Remove(removedProject);

            oldprojects.RemoveAt(1);
             List<ProjectData> newprojects = app.Project.GetProjectList(account);

             oldprojects.Sort();
             newprojects.Sort();
             Assert.AreEqual(oldprojects, newprojects);
        }
    }
}
