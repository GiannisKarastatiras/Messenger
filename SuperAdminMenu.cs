using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IndividualProject
{
    class SuperAdminMenu
    {
        public static bool repeat = false;
        public static ConsoleKeyInfo keyPressed;
        public static ConsoleKeyInfo esc;

        public static void GoBackToMenu()
        {
            Console.WriteLine("If you want to go back press Esc else press any other key.");
            esc = Console.ReadKey();
            if (esc.Key == ConsoleKey.Escape)
                DisplayMenu();
        }

        public static void DisplayAfterFirstAction(string action, int choise)
        {
            Console.WriteLine("What do you want to do now?");
            Console.WriteLine($"{action} another User? Press {choise}.");
            Console.WriteLine("Go back to main menu? Press any other button.");
        }

        public static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome!");
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine();
            Console.WriteLine("1. Create a User.");
            Console.WriteLine("2. Update a User.");
            Console.WriteLine("3. Delete a User.");
            Console.WriteLine("4. Assign a Role to a User.");
            Console.WriteLine("5. Exit.");
            string superAdminChoise = Console.ReadLine();
            
            switch (superAdminChoise)
            {
                case "1":
                    do
                    {
                        GoBackToMenu();
                        DBUserHandle.CreateUser();
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
                    DisplayMenu();
                    break;
                case "2":
                    do
                    {
                        GoBackToMenu();

                        DBUserHandle.ViewAllUsers();
                        DBUserHandle.UpdateUser();
                        DisplayAfterFirstAction("Update",2);
                        
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
                    DisplayMenu();
                    break;
                case "3":
                    do
                    {
                        GoBackToMenu();

                        DBUserHandle.ViewAllUsers();
                        DBUserHandle.DeleteUser();
                        DisplayAfterFirstAction("Delete", 3);
                        
                        
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
                    DisplayMenu();
                    break;
                case "4":
                    do
                    {
                        GoBackToMenu();

                        DBUserHandle.ViewAllUsers();
                        DBUserHandle.UpdateUser();
                        DisplayAfterFirstAction("Assign a Role to", 4);                        

                        keyPressed = Console.ReadKey();
                        if (keyPressed.Key == ConsoleKey.D4|| keyPressed.Key == ConsoleKey.NumPad4)
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
                    DisplayMenu();
                    break;
                case "5":
                    do
                    {
                        Console.WriteLine("Are you sure? Press 5");
                        Console.WriteLine("Go back to main menu? Press any other button.");
                        keyPressed = Console.ReadKey();
                        if (keyPressed.Key == ConsoleKey.D5 || keyPressed.Key == ConsoleKey.Escape)
                        {
                            repeat = true;
                            Console.Clear();
                            Environment.Exit(2);
                            break;
                        }
                        else
                        {
                            repeat = false;
                            DisplayMenu();
                        }
                    }
                    while (repeat == true);
                    Console.Clear();                    
                    break;
                default:
                    Console.WriteLine("Choose one of the valid options!");
                    DisplayMenu();
                    break;
            }
        }
    }
}
