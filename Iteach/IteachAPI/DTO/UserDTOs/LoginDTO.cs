namespace IteachAPI.DTO.UserDTOs;
public class LoginDTO
{
    public string Email { get;set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
public class LoginResponse
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public int Role { get; set; }    
}
