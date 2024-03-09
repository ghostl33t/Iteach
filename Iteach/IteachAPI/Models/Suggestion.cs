using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IteachAPI.Models;
public class Suggestion
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "bigint")]
    public int ChildId { get; set; }
    [ForeignKey("ChildId")] // Specify the foreign key property
    public Child Child { get; set; }
    [Column(TypeName ="nvarchar(max)")]
    public string SuggestionText { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar(max)")]
    public string SuggestionBasedOnTests { get; set; } = string.Empty;

    public DateTime DateOfSuggestion = DateTime.Today;
    
}
