using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IteachAPI.Models
{
    public class User
    {
        [Key]
        [Column(TypeName = "bigint")]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(16)")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Column(TypeName = "bit")]
        public bool Gender { get; set; }
        [Column(TypeName = "bit")]
        public bool Active { get; set; } = true;
        [Column(TypeName = "smallint")]
        public int Roles { get; set; }
    }
}
