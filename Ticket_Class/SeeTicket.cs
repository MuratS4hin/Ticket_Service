using System;
using System.Collections.Generic;

namespace Ticket_Class
{
    public static class SeeTicket
    {
        public static void SeeUsersTickets(Users user, List<Users> u)
        {
            var i = 0;
            if (user.Ticket.Count == 0) return;
            foreach (var var in user.Ticket)
            {
                i++;
                Console.WriteLine(i + "." + var);   
            }
            
        }

        public static void SeeAllTickets(List<Users> u)
        {
            var i = 0;
            foreach (var varıable in u)
            {
                foreach (var variable in varıable.Ticket)
                {
                    i++;
                    Console.WriteLine(i + "." + variable + "  -->  " + varıable.Answer[varıable.Ticket.IndexOf(variable)]);
                }
            }
            
        }
    }
}