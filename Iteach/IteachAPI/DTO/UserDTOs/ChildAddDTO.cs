namespace IteachAPI.DTO.UserDTOs;
public class ChildAddDTO
{
    public string FirstName { get;set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int ParentId { get; set; }
    public int TeacherId { get;set; }
}
