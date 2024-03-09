namespace IteachAPI.Models
{
    
    public class ErrorProvider
    {
        public bool Status { get; set; }
        public string Error { get; set; }
        public List<object>? Object {  get; set; }

    }
}
