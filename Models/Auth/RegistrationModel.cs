namespace PZ.Models.Auth
{
    public class RegistrationModel : LoginModel
    {
        public RegistrationModel()
        {
            this.ConfirmPassword = "";
            this.FirstName = "";
            this.LastName = "";
        }
        
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}