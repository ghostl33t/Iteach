namespace IteachAPI.DTO.TestsDTOs;
public class ChildTestAndFeedbackDTO : ChildTestFeedbackDTO
{
    public string TestDescription { get; set; } = string.Empty;
    public string TestName { get; set; } = string.Empty;
    public string ChildName { get; set; } = string.Empty;
}
