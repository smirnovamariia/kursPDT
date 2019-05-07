using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string email = "";

        public ContactData (string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Home
        {
            get { return home; }
            set { home = value; }
        }
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        public string Work
        {
            get { return work; }
            set { work = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
