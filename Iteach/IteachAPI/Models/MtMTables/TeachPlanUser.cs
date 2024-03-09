using System.ComponentModel.DataAnnotations;

namespace IteachAPI.Models.MtMTables
{
    public class TeachPlanUser
    {
        [Key]
        public int Id { get; set; }
        public TeachPlan TeachPlan { get; set; }
        public User Teacher { get; set; }
    }
}
