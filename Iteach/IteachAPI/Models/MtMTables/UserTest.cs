using System.ComponentModel.DataAnnotations;

namespace IteachAPI.Models.MtMTables
{
    public class UserTest
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Test Test { get; set; }
    }
}
