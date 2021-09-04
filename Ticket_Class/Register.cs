using System;
using System.Collections.Generic;
using System.Linq;

namespace Ticket_Class
{
    public static class Register
    {
        public static void Sign(List<Users> u, List<Admins> a)
        {
            Console.WriteLine("Kullanıcı Adı Girin:");
            var username = Console.ReadLine();
            
            if (u.Any(var => var.GetUsername() == username))
            {
                Console.Clear();//Clear----------------------------
                Console.WriteLine("This Username is in use");
                return;
            }

            if (a.Any(x => x.GetUsername() == username))
            {
                Console.Clear();//Clear----------------------------
                Console.WriteLine("This Username is in use");
                return;
            }

            Console.WriteLine("Şifre Giriniz:");
            var password = Console.ReadLine();
            Console.WriteLine("Sorununuz Nedir? :");
            var ticket = Console.ReadLine();
            Console.Clear();//Clear----------------------------
            
            u.Add(new Users("user", username, password, ticket,"In Progress"));
        }
    }
}