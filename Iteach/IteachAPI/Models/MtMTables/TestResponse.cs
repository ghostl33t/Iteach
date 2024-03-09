using System.ComponentModel.DataAnnotations;

namespace IteachAPI.Models.MtMTables
{
    public class TestResponse
    {
        [Key]
        public int Id { get; set; }
        public Test Test { get; set; }
        public Child Child { get; set; }
        public string ImagePath { get; set; }
    }
}
