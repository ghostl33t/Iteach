using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IteachAPI.Models
{
    public class TeachPlan
    {
        [Key]
        [Column(TypeName = "bigint")]
        public int TeachPlanId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "bit")]
        public bool Active { get; set; } = true;
    }
}
