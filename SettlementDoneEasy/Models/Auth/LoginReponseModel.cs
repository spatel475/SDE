namespace SDE_Server.Models.Auth
{
    public class LoginReponseModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public UserModel User { get; set; }
    }
}
