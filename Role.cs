using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class Role
    {
        public bool createMessage;
        public bool viewAllMessages;
        public bool editAllMessages;
        public bool deleteAllMessages;
        public bool viewOwnMessages;
        public bool editOwnMessages;
        public bool deleteOwnMessages;
        public bool createUser;
        public bool deleteUser;
        public bool updateUser;        

        public Role()
        {
            viewAllMessages = false;
            editAllMessages = false;
            deleteAllMessages = false;
            viewOwnMessages = false;
            editOwnMessages = false;
            deleteOwnMessages = false;
            createUser = false;
            deleteUser = false;
            updateUser = false;
            createMessage = false;
        }

        public void SetRole(int role)
        {
            switch(role)
            {
                case 4:
                    viewAllMessages = true;
                    editAllMessages = true;
                    deleteAllMessages = true;
                    viewOwnMessages = true;
                    editOwnMessages = true;
                    deleteOwnMessages = true;
                    createUser = true;
                    deleteUser = true;
                    updateUser = true;
                    break;                
                case 3:
                    createMessage = true;
                    viewAllMessages = true;
                    break;
                case 2:
                    createMessage = true;
                    viewAllMessages = true;
                    editAllMessages = true;
                    break;
                case 1:
                    createMessage = true;
                    viewAllMessages = true;
                    editAllMessages = true;
                    deleteAllMessages = true;
                    break;
                default:
                    Console.WriteLine("Something got wrong with the setup of roles!");
                    break;
            }           
            
        }

    }
}
