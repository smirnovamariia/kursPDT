using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; }
        public FtpHelper Ftp { get; }
        public JamesHelper James { get;  set; }
        public MailHelper Mail { get;  set; }
        public ProjectManagmentHelper Project { get;  set; }
        public AdminHelper Admin { get;  set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager ()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/mantisbt-2.21.1/mantisbt-2.21.1";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Project = new ProjectManagmentHelper(this);
            Admin = new AdminHelper(this, baseURL);
            Auth = new LoginHelper(this);
            API = new APIHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if ( ! app.IsValueCreated )
            {
                  ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value; 
        }
        public IWebDriver Driver
        { get { return driver; }
        }

       
        public LoginHelper Auth { get;  set; }
        public APIHelper API { get;  set; }
    }
}
