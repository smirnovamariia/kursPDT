using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
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

        public ContactData ( string lastname, string firstname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }
            if (Object.ReferenceEquals(this, other))
            { return true; }
            return ContactFullName == other.ContactFullName;
               

        }
        public override int GetHashCode()
        {
            return ContactFullName.GetHashCode();
        }
        public override string ToString()
        {
            return "full_name = " + Lastname + " " + Firstname  ;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return 1; }
            return ContactFullName.CompareTo(other.ContactFullName);

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

        public string ContactFullName
        {
            get { return  Lastname + Firstname; }
        }
    }
}
