using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.OpenHomePage();
            SelectContactForEdit(p);
            FillContactForm(newData);
            ModifyContact();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(p);
            RemoveContact();
            manager.Navigator.OpenHomePage();
            return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("mobile"), contact.Mobile);
            return this;

        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                CreateBeforeSelect();
            }
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContactForEdit(int index)
        {
                if (!IsElementPresent(By.Name("selected[]")))
            {
                CreateBeforeSelect();
            }
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
            return this;
        }

        private ContactHelper ModifyContact()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }
        private ContactHelper CreateBeforeSelect()
        {
            ContactData newContact = new ContactData("987", "7897");
            Create(newContact);
            return this;
        }
    }
}
