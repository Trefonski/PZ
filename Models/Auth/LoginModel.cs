namespace PZ.Models.Auth
{
    public class LoginModel
    {
        public LoginModel()
        {
            this.UserName = "";
            this.Password = "";
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}