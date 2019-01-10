using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class ApplicationMenu
    {
        public static bool repeat = false;
        public static ConsoleKeyInfo keyPressed;
        public static ConsoleKeyInfo esc;

        public static void GoBackToMenu(Role role, User user)
        {            
            Console.WriteLine("If you want to go back press Esc else press any other key.");
            esc = Console.ReadKey();
            if (esc.Key == ConsoleKey.Escape)
                DisplayMenu(role, user);
        }        

        public static void DisplayAfterFirstAction(string action, int choise)
        {
            Console.WriteLine("What do you want to do now?");
            Console.WriteLine($"{action} another Message? Press {choise}.");
            Console.WriteLine("Go back to main menu? Press any other button.");            
        }

        public static void DisplayMenu(Role role, User user)
        {          

            Console.WriteLine();
            Console.WriteLine("Welcome!");
            Console.WriteLine();
            Console.WriteLine("What do yo want to do?");
            Console.WriteLine();
            Console.WriteLine("1. Send Message to another User.");
            Console.WriteLine("2. View your Messages.");
            Console.WriteLine("3. Edit your Messages.");
            Console.WriteLine("4. Delete your Messages.");


            if (role.viewAllMessages)
                Console.WriteLine("5. View All the Messages of the other Users.");
            if (role.editAllMessages)
                Console.WriteLine("6. Edit All the Messages of the other Users.");
            if (role.deleteAllMessages)
                Console.WriteLine("7. Delete All the Messages of the other Users.");
            Console.WriteLine("8. Exit.");
            string choise = Console.ReadLine();

            switch (choise)
            {
                case "1":
                    do
                    {
                        GoBackToMenu(role, user);

                                                
                        DBMessageHandle.CreateMessage(user.UserName);
                        DisplayAfterFirstAction("Create", 1);
                        
                        keyPressed = Console.ReadKey();
                        if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                        {
                            repeat = true;
                            Console.Clear();
                        }
                        else
                        {
                            repeat = false;
                        }


                    }
                    while (repeat == true);
                    Console.Clear();
                    DisplayMenu(role, user);
                    break;
                case "2":
                    do
                    {
                        GoBackToMenu(role, user);                      
                        
                        DBMessageHandle.ViewMessage(user.UserName);
                        DisplayAfterFirstAction("View", 2);
                        
                        keyPressed = Console.ReadKey();
                        if (keyPressed.Key == ConsoleKey.D2 || keyPressed.Key == ConsoleKey.NumPad2)
                        {
                            repeat = true;
                            Console.Clear();
                        }
                        else
                        {
                            repeat = false;
                        }
                    }
                    while (repeat == true);
                    Console.Clear();
                    DisplayMenu(role, user);
                    break;
                case "3":
                    do
                    {
                        GoBackToMenu(role, user);

                        DBMessageHandle.ViewMessage(user.UserName);
                        DBMessageHandle.EditMessage(user.UserName);
                        DisplayAfterFirstAction("Edit", 3);
                        
                        keyPressed = Console.ReadKey();
                        if (keyPressed.Key == ConsoleKey.D3 || keyPressed.Key == ConsoleKey.NumPad3)
                        {
                            repeat = true;
                            Console.Clear();
                        }
                        else
                        {
                            repeat = false;
                        }
                    }
                    while (repeat == true);
                    Console.Clear();
                    DisplayMenu(role, user);
                    break;
                case "4":
                    do
                    {
                        GoBackToMenu(role, user);
                        DBMessageHandle.ViewMessage(user.UserName);
                        DBMessageHandle.DeleteMessage(user.UserName);
                        DisplayAfterFirstAction("Delete", 4);
                        
                        keyPressed = Console.ReadKey();
                        if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                        {
                            repeat = true;
                            Console.Clear();
                        }
                        else
                        {
                            repeat = false;
                        }
                    }
                    while (repeat == true);
                    Console.Clear();
                    DisplayMenu(role, user);
                    break;
                case "5":
                    if (role.viewAllMessages)
                    {
                        do
                        {
                            GoBackToMenu(role, user);
                            DBMessageHandle.ViewAllMessages();
                            DisplayAfterFirstAction("View", 5);
                            
                            keyPressed = Console.ReadKey();
                            if (keyPressed.Key == ConsoleKey.D5 || keyPressed.Key == ConsoleKey.NumPad5)
                            {
                                repeat = true;
                                Console.Clear();
                            }
                            else
                            {
                                repeat = false;
                            }
                        }
                        while (repeat == true);
                        Console.Clear();
                        DisplayMenu(role, user);
                    }
                    else
                    {
                        Console.WriteLine("Choose another option....");                        
                        DisplayMenu(role, user);
                    }
                    break;
                case "6":
                    if (role.editAllMessages)
                    {
                        do
                        {
                            GoBackToMenu(role, user);

                            DBMessageHandle.ViewAllMessages();
                            DBMessageHandle.EditAllMessages();
                            DisplayAfterFirstAction("Edit", 6);
                            
                            keyPressed = Console.ReadKey();
                            if (keyPressed.Key == ConsoleKey.D6 || keyPressed.Key == ConsoleKey.NumPad6)
                            {
                                repeat = true;
                                Console.Clear();
                            }
                            else
                            {
                                repeat = false;
                            }
                        }
                        while (repeat == true);
                        Console.Clear();
                        DisplayMenu(role, user);
                    }
                    else
                    {
                        Console.WriteLine("Choose another option....");                        
                        DisplayMenu(role, user);
                    }
                    break;
                case "7":
                    if (role.deleteAllMessages)
                    {
                        do
                        {
                            GoBackToMenu(role, user);
                            DBMessageHandle.ViewAllMessages();
                            DBMessageHandle.DeleteAllMessages();
                            DisplayAfterFirstAction("Delete", 7);
                            
                            keyPressed = Console.ReadKey();
                            if (keyPressed.Key == ConsoleKey.D7 || keyPressed.Key == ConsoleKey.NumPad7)
                            {
                                repeat = true;
                                Console.Clear();
                            }
                            else
                            {
                                repeat = false;
                            }
                        }
                        while (repeat == true);
                        Console.Clear();
                        DisplayMenu(role, user);
                    }
                    else
                    {
                        Console.WriteLine("Choose another option....");                        
                        DisplayMenu(role, user);
                    }
                    break;
                case "8":
                    do
                    {
                        Console.WriteLine("Are you sure? Press 8");
                        Console.WriteLine("Go back to main menu? Press any other button.");
                        keyPressed = Console.ReadKey();
                        if (keyPressed.Key == ConsoleKey.D8 || keyPressed.Key == ConsoleKey.Escape)
                        {
                            repeat = true;
                            Console.Clear();
                            Environment.Exit(2);

                        }
                        else
                        {
                            repeat = false;
                            DisplayMenu(role, user);
                        }
                    }
                    while (repeat == true);
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Choose one of the valid options!");
                    DisplayMenu(role, user);
                    break;    
            }        
            
        }
    }
}
