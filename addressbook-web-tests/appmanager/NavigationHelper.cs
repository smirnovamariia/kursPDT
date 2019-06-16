﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        private string newURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) :base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            if (driver.Url == baseURL )
            { return; }
            driver.Navigate().GoToUrl(baseURL);
        }


        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "group.php"
                && IsElementPresent(By.Name("new")))
                {
                return;
                }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenEditPage(string id)
        {
            newURL = baseURL + "edit.php?id=" + id ;
            driver.Navigate().GoToUrl(newURL);
        }

    }
}
