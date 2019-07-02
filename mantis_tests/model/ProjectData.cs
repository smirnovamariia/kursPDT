using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IComparable<ProjectData>, IEquatable<ProjectData>
    {
      
        public ProjectData()
        {
         
        }

        public ProjectData(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }


        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CompareTo(ProjectData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Name.CompareTo(other.Name) == 0)
            {
                return Description.CompareTo(other.Description);
            }
            return Name.CompareTo(other.Name);
        }

        public bool Equals(ProjectData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Name == other.Name) && (Description == other.Description);
        }
    }
}
