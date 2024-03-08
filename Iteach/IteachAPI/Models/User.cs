namespace IteachAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }    
        public bool Active { get; set; }
        public int Roles { get; set; }
    }
}
