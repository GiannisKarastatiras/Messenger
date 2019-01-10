using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class LoginScreen
    {        
        public static User Login()
        {
            User user = new User();            

            try
            {
                DatabaseAccess.DBConnectionOpen();

                Console.WriteLine("Enter username and password to Login:");                
                string usernameInserted = Console.ReadLine();                
                string passwordInserted = Console.ReadLine();

                user = DatabaseAccess.DBLogin(usernameInserted, passwordInserted);
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
            return user;
        }        
    }
}
