namespace Ticket_Class
{
    public class Admins
    {
        private string Role { set; get; }
        private string Username { set; get; }
        private string Password { set; get; }

        public Admins(string role,string username, string password)
        {
            Role = role;
            Username = username;
            Password = password;
        }

        public string GetUsername()
        {
            return Username;
        }
        
        public string GetPassword()
        {
            return Password;
        }

        public string GetRole()
        {
            return Role;
        }
    }
}