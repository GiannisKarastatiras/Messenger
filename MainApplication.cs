using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
   class MainApplication
   {
        public const int adminRole = 4;        
        
        public static void MainApp()
        {
            Role role = new Role();
            User user = new User();

            user = LoginScreen.Login();

            if (user.Role == adminRole)
                SuperAdminMenu.DisplayMenu();
            if (user.Role != 0) 
            {
                role.SetRole(user.Role);
                ApplicationMenu.DisplayMenu(role, user);
            }            
        }        
   }
}
