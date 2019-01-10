using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndividualProject
{
    class DBMessageHandle
    {
        public static void CreateMessage(string senderUserName)
        {         


            try
            {
                DatabaseAccess.DBConnectionOpen();
                Message message = new Message();

                DatabaseAccess.DBViewUsersforMessage(senderUserName);
                Console.WriteLine("Write the UserName of the receiver for your message!");
                message.ReceiverUserName = Console.ReadLine();

                DatabaseAccess.DBExistentUserToSendMessage(senderUserName, message.ReceiverUserName);

                message.SenderUserName = senderUserName;
                message.DateOfSubmission = DateTime.Now;
                Console.WriteLine("Write your Message:");
                message.MessageData = Console.ReadLine();


                DatabaseAccess.DBInsertMessage(message.DateOfSubmission, message.SenderUserName, message.ReceiverUserName, message.MessageData);
                
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

        public static void ViewMessage(string senderUserName)
        {
            try
            {
                DatabaseAccess.DBConnectionOpen();
                
                DatabaseAccess.DBViewMessage(senderUserName);
                
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

        public static void ViewAllMessages()
        {
            try
            {
                DatabaseAccess.DBConnectionOpen();
                DatabaseAccess.DBViewAllMessages();
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

        public static void EditMessage(string senderUserName)
        {
            try
            {
                DatabaseAccess.DBConnectionOpen();                

                Console.WriteLine("Write the username of the receiver that you want to Edit: ");
                string receiverUserName = Console.ReadLine();
                
                Console.WriteLine("Enter the Date and time of the message.");
                var dateOfSubmission = DateTime.Parse(Console.ReadLine());                

                Console.WriteLine("Write the new Message: ");
                string newMessage = Console.ReadLine();

                DatabaseAccess.DBExistentUsernameInMessages(senderUserName, receiverUserName, dateOfSubmission);                             

                DatabaseAccess.DBUpdateMessage(senderUserName, receiverUserName, dateOfSubmission, newMessage);
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

        public static void EditAllMessages()
        {
            try
            {
                DatabaseAccess.DBConnectionOpen();

                
                Console.WriteLine("Write the username of the sender that you want to Edit: ");
                string senderUserName = Console.ReadLine();

                Console.WriteLine("Write the username of the receiver that you want to Edit: ");
                string receiverUserName = Console.ReadLine();

                
                Console.WriteLine("Enter the Date and time of the message.");
                var dateOfSubmission = DateTime.Parse(Console.ReadLine());



                Console.WriteLine("Write the new Message: ");
                string newMessage = Console.ReadLine();

                DatabaseAccess.DBExistentUsernameInMessages(senderUserName, receiverUserName, dateOfSubmission);



                DatabaseAccess.DBUpdateMessage(senderUserName, receiverUserName, dateOfSubmission, newMessage);
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

        public static void DeleteMessage(string userName)
        {
            try
            {
                DatabaseAccess.DBConnectionOpen();

                //Console.WriteLine("Enter a UserName to Delete the message!");
                //string senderUserName = Console.ReadLine();
                Console.WriteLine("Write the username of the receiver that you want to Delete: ");
                string receiverUserName = Console.ReadLine();

                Console.WriteLine("Enter the Date and time of the message.");
                var dateOfSubmission = DateTime.Parse(Console.ReadLine());

                DatabaseAccess.DBDeleteMessage(userName, receiverUserName, dateOfSubmission);
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

        public static void DeleteAllMessages()
        {
            try
            {
                DatabaseAccess.DBConnectionOpen();

                Console.WriteLine("Enter the username of the sender that you want to Delete: ");
                string senderUserName = Console.ReadLine();

                Console.WriteLine("Write the username of the receiver that you want to Delete: ");
                string receiverUserName = Console.ReadLine();

                Console.WriteLine("Enter the Date and time of the message.");
                var dateOfSubmission = DateTime.Parse(Console.ReadLine());

                DatabaseAccess.DBDeleteMessage(senderUserName, receiverUserName, dateOfSubmission);
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
