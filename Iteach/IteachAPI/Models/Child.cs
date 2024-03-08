using System.Globalization;

namespace IteachAPI.Models
{
    public class Child
    {
        public int ChildId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User Parent { get; set; }

    }
}
