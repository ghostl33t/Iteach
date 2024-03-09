namespace IteachAPI.DTO.TestsDTOs;
public class ChildTestFeedbackDTO
{
    public int ChildId { get; set; }
    public int TestId { get; set; }
    public string TeacherFeedback { get; set; } = string.Empty;
}
