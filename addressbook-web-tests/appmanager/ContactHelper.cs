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
            contactCache = null;
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+1) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContactForEdit(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+1) + "]/td[8]/a/img")).Click();
            return this;
        }

        private ContactHelper ModifyContact()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contactCache = null;
            return this;
        }

        public bool IsAnyElement()
        {
            manager.Navigator.OpenHomePage();
            return IsElementPresent(By.Name("selected[]"));
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name = entry]"));
                foreach (IWebElement element in elements)
                {
                    var lastName = element.FindElement(By.XPath(".//td[2]"));
                    var firstName = element.FindElement(By.XPath(".//td[3]"));
                    contactCache.Add(new ContactData(lastName.Text, firstName.Text));
                }
            }
           
            return new List<ContactData>(contactCache);
        }

    }
}
