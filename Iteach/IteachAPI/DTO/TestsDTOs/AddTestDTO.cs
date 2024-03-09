namespace IteachAPI.DTO.TestsDTOs;
public class AddTestDTO
{
    public int UserId { get; set; }
    public int Role { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
}
