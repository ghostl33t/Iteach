using System.ComponentModel.DataAnnotations;

namespace IteachAPI.Models.MtMTables
{
    public class ChildTest
    {
        [Key]
        public int Id { get; set; }
        public Child Child { get; set; }
        public Test Test { get; set; }
    }
}
