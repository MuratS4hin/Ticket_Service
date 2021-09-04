using System.Collections.Generic;

namespace Ticket_Class
{
    public class Users
    {
        public string Role { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public List<string> Ticket { set; get; }
        public List<string> Answer { set; get; }

        public Users(string role,string username, string password, string ticket, string answer)
        {
            Role = role;
            Username = username;
            Password = password;
            Ticket = new List<string>{ticket};
            Answer = new List<string>{answer};
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