using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class DBUserHandle
    {
        public static void CreateUser()
        {        
            try
            {
                DatabaseAccess.DBConnectionOpen();

                Console.WriteLine("Enter a Name and LastName");
                string name = Console.ReadLine();
                string lastname = Console.ReadLine();

                Console.WriteLine("Enter Age and Telephone");
                int age = int.Parse(Console.ReadLine());
                string telephone = Console.ReadLine();

                Console.WriteLine("Enter an Email");
                string email = Console.ReadLine();

                Console.WriteLine("Enter a UserName and Password");
                string username = Console.ReadLine();
                string password = Console.ReadLine();

                Console.WriteLine("Enter the Users Role");
                int role = int.Parse(Console.ReadLine());

                DatabaseAccess.DBInsertUser(name, lastname, age, telephone, email, username, password, role);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DatabaseAccess.DBConnectionClose();
                DatabaseAccess.DBConnectionDispose();
            }
        }

        public static void ViewAllUsers()
        {
            try
            {
                DatabaseAccess.DBConnectionOpen();
                DatabaseAccess.DBViewAllUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DatabaseAccess.DBConnectionClose();
                DatabaseAccess.DBConnectionDispose();
            }
        }

        public static void UpdateUser()
        {
            try
            {
                DatabaseAccess.DBConnectionOpen();

                Console.WriteLine("Enter a UserID for Update");
                int userID = int.Parse(Console.ReadLine());
                Console.WriteLine("Which information do you want to Update");
                string updateInfo = Console.ReadLine();
                Console.WriteLine($"Enter a new {updateInfo} for User");
                string newUpdateInfo = Console.ReadLine();

                DatabaseAccess.DBUpdateUserInfo(updateInfo, userID, newUpdateInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DatabaseAccess.DBConnectionClose();
                DatabaseAccess.DBConnectionDispose();
            }
        }

        public static void DeleteUser()
        {
            try
            {
                DatabaseAccess.DBConnectionOpen();

                Console.WriteLine("Enter a user to DELETE");
                string nameForDelete = Console.ReadLine();

                DatabaseAccess.DBDeleteUser(nameForDelete);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DatabaseAccess.DBConnectionClose();
                DatabaseAccess.DBConnectionDispose();
            }
        }        
        
    }
}
