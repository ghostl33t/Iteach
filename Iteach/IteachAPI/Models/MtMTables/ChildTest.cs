using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IteachAPI.Models.MtMTables
{
    public class ChildTest
    {
        [Key]
        public int Id { get; set; }

        // Define the foreign key relationships
        [Column(TypeName = "bigint")]
        public int ChildId { get; set; }
        [Column(TypeName = "bigint")]
        public int TestId { get; set; }

        [ForeignKey("ChildId")] // Specify the foreign key property
        public Child Child { get; set; }

        [ForeignKey("TestId")] // Specify the foreign key property
        public Test Test { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string TeacherFeedback { get; set; } = string.Empty;
    }
}
