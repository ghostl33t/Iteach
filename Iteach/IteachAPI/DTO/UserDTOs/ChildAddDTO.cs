namespace IteachAPI.DTO.UserDTOs;
public class ChildAddDTO
{
    public string ChildName { get;set; } = string.Empty;
    public string ChildSurname { get; set; } = string.Empty;
    public int ParentId { get; set; }
    public int TeacherId { get;set; }
}
