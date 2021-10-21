namespace SDE_Server.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public OrganizationModel Organization { get; set; }

    }
}
