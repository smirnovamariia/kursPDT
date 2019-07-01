using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreateTests : TestBase
    {
        [Test]
        public void CreateProjectTest()
        {
            int count = 0;
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            app.Auth.Login(account);
            ProjectData project = new ProjectData() { Name = "test", Description = "d_test" };
            if (app.Project.IsExistProject(project))
            {
                count = app.Project.CountProject();
                project.Name = "test_" + count; }

            List<ProjectData> oldprojects = new List<ProjectData>();
            oldprojects = app.Project.GetProjectList();


            app.Project.Create(project);

            oldprojects.Add(project);
            List<ProjectData> newprojects = app.Project.GetProjectList();
            oldprojects.Sort();
            newprojects.Sort();
            Assert.AreEqual(oldprojects, newprojects);
        }
    }
}
