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
        private string fullContactInfo;

        public ContactData ( string firstname, string  lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData()
        {
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
        public string FullContactInfo
        {
            get
            {
                if (fullContactInfo != null)
                {
                    return fullContactInfo;
                }
                else
                {
                    return UnionContactInfo(fullContactInfo).Trim();
                }
            }
            set
            {
                fullContactInfo = value;
            }
        }

        public string UnionContactInfo(string fullContactInfo)
        {
            if (Firstname != null && Firstname != "")
            { fullContactInfo = Firstname; }

            if (Lastname != null && Lastname != "")
            {
                fullContactInfo= fullContactInfo + " " + Lastname + "\r\n";
            }
            if (Nickname != null && Nickname != "")
            {
                fullContactInfo = fullContactInfo + Nickname + "\r\n";
            }
            if (Title != null && Title != "")
            {
                fullContactInfo = fullContactInfo + Title + "\r\n";
            }

            if (Address != null && Address != "")
            {
                fullContactInfo = fullContactInfo+ Address.Trim() + "\r\n" ;
            }
            fullContactInfo = fullContactInfo + "\r\n";

            if (Home != null && Home != "")
            {
                fullContactInfo = fullContactInfo + "H: " + Home + "\r\n";
            }
        
            if (Mobile != null && Mobile != "")
            {
                fullContactInfo = fullContactInfo  + "M: " + Mobile + "\r\n";
            }
        
            if (Work != null && Work != "")
             {
                fullContactInfo = fullContactInfo +  "W: " + Work + "\r\n" ;
            }
            
            fullContactInfo = fullContactInfo + "\r\n";

            if (Email != null && Email != "")
            {
                fullContactInfo = fullContactInfo + Email + "\r\n";
            }

            if (Email2 != null && Email2 != "")
            {
                fullContactInfo = fullContactInfo + Email2 + "\r\n";
            }

            if (Email3 != null && Email3 != "")
            {
                fullContactInfo = fullContactInfo + Email3 + "\r\n";
            }

            return fullContactInfo;
        }
    }
}
