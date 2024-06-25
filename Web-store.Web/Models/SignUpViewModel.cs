namespace Web_store.Web.Models
{
    public class SignUpViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Document { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
