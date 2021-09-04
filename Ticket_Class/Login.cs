using System;
using System.Collections.Generic;
using System.Linq;

namespace Ticket_Class
{
    public static class LoginClass
    {
        public static void Login(List<Users> u, List<Admins> a)
            {
               Console.WriteLine("Username:");
                var uName = Console.ReadLine();
                Console.WriteLine("Password");
                var pass = Console.ReadLine();
                Console.Clear();//Clear----------------------------
                foreach (var varıable in u.Where(varıable => varıable.GetUsername() == uName && varıable.GetPassword() == pass && varıable.GetRole() == "user"))
                {
                    User(varıable,u);
                }
                
                foreach (var unused in a.Where(varıable => varıable.GetUsername() == uName && varıable.GetPassword() == pass && varıable.GetRole() == "admin"))
                {
                    Admin(u);
                }
            }

        private static void User(Users varıable, List<Users> u)
        {
            while(true){
                Console.WriteLine("--------------------------\nUser Entry\nWhat do you want to do?\n1.See your tickets\n2.See all tickets\n3.Add ticket\n4.Delete ticket\n5.Exit");
                var temp = Console.ReadLine();

                if (temp == "1")
                {
                    Console.Clear();//Clear----------------------------
                    SeeTicket.SeeUsersTickets(varıable,  u);
                }//show users ticket

                else if (temp == "2")
                {
                    Console.Clear();//Clear----------------------------
                    SeeTicket.SeeAllTickets(u);
                }//shows all tickets

                else if (temp == "3")
                {
                    Console.Clear();//Clear----------------------------
                    Console.WriteLine("What is your problem?");
                    varıable.Ticket.Add(Console.ReadLine());
                    varıable.Answer.Add("In progress");
                }//adding ticket

                else if (temp == "4")
                {
                    Console.Clear();//Clear----------------------------
                    SeeTicket.SeeUsersTickets(varıable, u);
                    Console.WriteLine("which one do you want to delete?");

                    if (!int.TryParse(Console.ReadLine(), out var change))
                    {
                        Console.WriteLine("You Must give proper integer");
                        continue;
                    }
                    
                    if (change <= varıable.Ticket.Count && change > 0)
                    {
                        varıable.Ticket.RemoveAt(change-1);
                        varıable.Answer.RemoveAt(change-1);
                    }
                    else Console.WriteLine("Wrong entry");
                    
                }//deleting users ticket
                
                else if (temp == "5")
                {
                    Console.Clear();//Clear----------------------------
                    return;
                }//Returns
                
                else
                {
                    Console.Clear();//Clear----------------------------
                    Console.WriteLine("Wrong entry");
                }//wrong entry
            }
        }

        private static void Admin(List<Users> u)
        {
            while(true){
                Console.WriteLine("--------------------\nAdmin Entry\nWhat do you want to do?\n1.Look at the tickets\n2.Answer the ticket\n3.Close Ticket\n4.Exit");
                var temp = Console.ReadLine();
                if (temp == "1")
                {
                    Console.Clear();//Clear----------------------------
                    SeeTicket.SeeAllTickets(u);
                }//shows all tickets
                        
                else if (temp == "2")
                {
                    Console.Clear();//Clear----------------------------
                    SeeTicket.SeeAllTickets(u);
                    Console.WriteLine("which one do you want to answer?");

                    if (!int.TryParse(Console.ReadLine(), out var change))
                    {
                        Console.Clear(); //Clear----------------------------
                        Console.WriteLine("Wrong Entry");
                    }
                    else
                    {
                        var ind = 0;
                        if (change <= 0)
                        {
                            Console.WriteLine("Wrong Entry");
                            continue;
                        }

                        foreach (var us in u)
                        { foreach (var st in us.Ticket)
                        {
                                ind++;
                                if (ind != change) continue;
                                Console.WriteLine("You can write your comment");
                                us.Answer[us.Ticket.IndexOf(st)] = Console.ReadLine();
                                break;
                        } }
                    }
                }//Answering ticket
                        
                else if (temp =="3")
                {
                    Console.Clear();//Clear----------------------------
                    SeeTicket.SeeAllTickets(u);
                    Console.WriteLine("which one do you want to close?");
                    
                    if (!int.TryParse(Console.ReadLine(), out var close)) continue;
                    var ticketClosed = false;
                    var ind=0;
                    
                    if (close  <= 0)
                    {
                        Console.WriteLine("Wrong Entry"); 
                        continue;
                    }
                    
                    foreach (var us in u)
                    {
                        foreach (var st in us.Ticket)
                        {
                            ind++;
                            
                            if (ind != close) continue;
                            us.Answer.RemoveAt(us.Ticket.IndexOf(st));
                            us.Ticket.RemoveAt(us.Ticket.IndexOf(st));
                            Console.Clear();//Clear----------------------------
                            ticketClosed = true;
                            break;
                        }

                        if (!ticketClosed) continue;
                        Console.WriteLine("Ticket hes been removed");
                        break;
                    }

                }//Closing ticket
                
                else if (temp == "4")
                {
                    Console.Clear();//Clear--------------------------
                    return;
                }//returns;
                
                else Console.WriteLine("Undefined Entry");
                
            }
        }
    }
}