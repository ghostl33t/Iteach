using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IteachAPI.Models
{
    public class Child
    {
        [Key]
        [Column(TypeName = "bigint")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; } = string.Empty;
        public User? Parent { get; set; } 

    }
}
