using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;

namespace Ticket_Class
{
    class Program
    {
        static void Main()
        {
            var a = new List<Admins>();
            var u = new List<Users>();

            while (true)
            {
                Console.WriteLine("---------------\nWhat do you want to do?\n1.Register\n2.Log_in\n3.Exit");
                var temp = Console.ReadLine();
                
                if (temp == "1") Register.Sign(u,a); 
                
                else if (temp == "2") LoginClass.Login(u,a); 
                
                else if (temp == "3")
                {
                    DataBase.SetAndExit(u,a);
                    return;
                } 
                
                else
                {
                    Console.Clear();//Clear----------------------------
                    Console.WriteLine("Wrong entry");
                }
            }
            
        }
    }
}