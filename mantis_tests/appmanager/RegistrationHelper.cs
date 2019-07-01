using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegisrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl();
            FillPasswordForm(url);
            SubmitPasswordForm();

        }

        private string GetConfirmationUrl()
        {
            throw new NotImplementedException();
        }

        private void FillPasswordForm(string url)
        {
            throw new NotImplementedException();
        }

        private void SubmitPasswordForm()
        {
            throw new NotImplementedException();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a.back-to-login-link.pull-left")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.XPath("//input[@value='Зарегистрироваться']")).Click();
        }

        private void FillRegisrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }


    }
}
