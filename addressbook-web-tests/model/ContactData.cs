using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData ( string lastname, string firstname)
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
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Email { get; set; }
        public string ContactFullName
        {
            get { return  Lastname + Firstname; }
        }
    }
}
