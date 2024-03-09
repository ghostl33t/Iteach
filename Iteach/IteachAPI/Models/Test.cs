using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IteachAPI.Models
{
    public class Test
    {
        [Key]
        [Column(TypeName = "bigint")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = string.Empty;
        
        
        [Column(TypeName = "bigint")]
        public int TeacherId { get; set; }

        [ForeignKey("TeacherId")] // Specify the foreign key property
        public User Teacher { get; set; }
    }
}
