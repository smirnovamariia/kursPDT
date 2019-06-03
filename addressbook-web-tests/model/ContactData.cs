using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData ( string firstname, string  lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }
            if (Object.ReferenceEquals(this, other))
            { return true; }

            return Firstname == other.Firstname && Lastname == other.Lastname;
            

        }
        public override int GetHashCode()
        {
            return Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "full_name = "  + Firstname + " " + Lastname ;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return 1; }
           if (Lastname.CompareTo(other.Lastname) != 0)
            {if (Lastname.CompareTo(other.Lastname)> 0)
                    { return 1; }
             else   { return -1; }
            }
            return Firstname.CompareTo(other.Firstname);

        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
                }
            }
            set { allPhones = value; }
        }

        private string CleanUp(string phone)
        {
            if (phone ==null || phone == "")
            { return ""; }
            return Regex.Replace(phone,"[ -()]", "") +"\r\n";
        }

        public string AllEmails
        {
            get
            { if (allEmails != null)
                { return allEmails; }
                else { return (MakeEmail(Email) + MakeEmail(Email2) + MakeEmail(Email3)).Trim(); }
            }
            set { allEmails = value; }
        }
        private string MakeEmail(string email)
        {
            if (email == null || email == "")
            { return ""; }
            return email  + "\r\n";
        }

    }
}
