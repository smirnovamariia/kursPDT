using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagmentHelper : HelperBase
    {
        public ProjectManagmentHelper(ApplicationManager manager) : base(manager) { }
        public void Create(ProjectData project)
        {
           OpenToggMenu();
           OpenProjectPage();
           OpenNewProjectForm();
           FillProjectForm(project);
           SubmitAdding();

            
        }

        internal void Remove(int p)
        {
           OpenToggMenu();
           OpenProjectPage();
           SelectProject(p);
           SubmitRemoving();
        }

        private void SubmitRemoving()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void SelectProject(int p)
        {
            // driver.FindElement(By.CssSelector("td > a")).Click(); //anyproject
            driver.FindElement(By.XPath("//tr["+p+"]/td/a")).Click();
            // driver.FindElement(By.XPath(".//table[1]/tbody/tr/td/a[contains(text(),'" + p + "')])")).Click();
        }

        private void SubmitAdding()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            driver.FindElement(By.LinkText("Продолжить")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            Type(By.Name("description"), project.Description);
        }

        public bool IsExistProject(ProjectData project)
        {
            if (! IsElementPresent(By.XPath("(//a[contains(text(),'"+ project.Name+"')])")) )
            {
                return false;
            }
            return true;
        }
        public int CountProject()
        {
            int count = driver.FindElements(By.XPath("//a[@href]")).Count();
            return count;
        }
        public List<ProjectData> GetProjectList()
        {
           OpenToggMenu();
           
            OpenProjectPage();

            
            List<ProjectData> projects = new List<ProjectData>();

            ICollection<IWebElement> elements = driver.FindElement(By.XPath(".//table[1]/tbody"))
                .FindElements(By.XPath(".//tr"));

            foreach (IWebElement element in elements)
            {
                ProjectData project = new ProjectData(element.FindElement(By.XPath("//td[1]")).Text, element.FindElement(By.XPath("//td[5]")).Text);
                projects.Add(project);
            }


            return new List<ProjectData>(projects);
        }

        public void OpenToggMenu()
        {
            driver.FindElement(By.CssSelector("#menu-toggler")).Click();
      
            driver.FindElement(By.XPath("//li[7]/a/span")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
         .Until(d => d.FindElements(By.LinkText("Управление проектами")).Count > 0);

        }
        public void OpenProjectPage()
        {
            driver.FindElement(By.LinkText("Управление проектами")).Click();

        }
        public void OpenNewProjectForm()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
    }

}
