namespace IteachAPI.DTO.TestsDTOs;
public class SuggestionDTO
{
    public int ChildId { get; set; }
    public string ChildName { get; set; } = string.Empty;
    public string ParentName { get; set; } = string.Empty;  
    public string SuggestionText { get; set; } = string.Empty;
    public string SuggestionBasedOnTests { get; set; } = string.Empty;
    public DateTime SuggestionDate { get;set; }
}
