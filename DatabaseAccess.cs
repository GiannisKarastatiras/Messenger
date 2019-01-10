using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class DatabaseAccess
    {
        static string connectionString = @"Server = ASUS;Database = IndividualProjectDB; Trusted_Connection = True;";
        static SqlConnection sqlConnection; 

        public static void DBConnectionOpen()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public static void DBConnectionClose()
        {
            sqlConnection.Close();
        }

        public static void DBConnectionDispose()
        {
            sqlConnection.Dispose();
        }

        public static void DBInsertUser(string name, string lastName, int age, string telephone, string email, string username, string password, int role)
        {
            SqlCommand cmdInsertUsernamePassword = new SqlCommand($"INSERT INTO UserNames(UserName, Password) VALUES('{username}', '{password}')", sqlConnection);
            int rowsOfUsernamesInserted = cmdInsertUsernamePassword.ExecuteNonQuery();
            if (rowsOfUsernamesInserted > 0)
            {
                Console.WriteLine("Insertion Successful");
                Console.WriteLine($"{rowsOfUsernamesInserted} rows inserted Successfully");
            }

            SqlCommand cmdInsert = new SqlCommand($"INSERT INTO UsersDetailsTable(Name, LastName, Age, Telephone, Email, Role, UserName) VALUES('{name}', '{lastName}', '{age}', '{telephone}', '{email}', '{role}', '{username}')", sqlConnection);
            int rowsInserted = cmdInsert.ExecuteNonQuery();
            if (rowsInserted > 0)
            {
                Console.WriteLine("Insertion Successful");
                Console.WriteLine($"{rowsInserted} rows inserted Successfully");
            }
        }
        
        public static void DBInsertMessage(DateTime dateOfSubmission, string senderUserName, string receiverUserName, string messageData)
        {
            SqlCommand cmdInsert = new SqlCommand($"INSERT INTO Messages(DateOfSubmission, Sender, Receiver, MessageData) VALUES('{dateOfSubmission}', '{senderUserName}', '{receiverUserName}', '{messageData}')", sqlConnection);
            int rowsInserted = cmdInsert.ExecuteNonQuery();
            if (rowsInserted > 0)
            {
                Console.WriteLine("Insertion Successful");
                Console.WriteLine($"{rowsInserted} rows inserted Successfully");
            }
            FileAccess.StoreDataToAText(FileAccess.path, dateOfSubmission, senderUserName, receiverUserName, messageData);
        }

        public static void DBUpdateUserInfo(string updateInfo, int userID, string newUpdateInfo)
        {
            SqlCommand cmdUpdate = new SqlCommand($"UPDATE UsersDetailsTable SET {updateInfo} = '{newUpdateInfo}' WHERE ID = '{userID}'", sqlConnection);
            int rowsUpdated = cmdUpdate.ExecuteNonQuery();
            if (rowsUpdated > 0)
            {
                Console.WriteLine("Update Successfull");
                Console.WriteLine($"{rowsUpdated} rows updated successfully");
            }
        }

        public static void DBUpdateMessage(string senderUserName, string receiverUserName, DateTime dateOfSubmission, string newMessageData)
        {           
            SqlCommand cmdUpdate = new SqlCommand($"UPDATE Messages SET MessageData = '{newMessageData}' WHERE DateOfSubmission = '{dateOfSubmission}' AND Sender = '{senderUserName}' AND Receiver = '{receiverUserName}'", sqlConnection);

            int rowsUpdated = cmdUpdate.ExecuteNonQuery();
            if (rowsUpdated > 0)
            {
                Console.WriteLine("Update Successfull");
                Console.WriteLine($"{rowsUpdated} rows updated successfully");
            }
                        
            FileAccess.StoreDataToAText(FileAccess.path, dateOfSubmission, senderUserName, receiverUserName, newMessageData);
        }       

        public static void DBDeleteUser(string nameForDelete)
        {
            SqlCommand cmdDelete = new SqlCommand($"DELETE FROM UsersDetailsTable WHERE Name = '{nameForDelete}'", sqlConnection);
            int rowsDeleted = cmdDelete.ExecuteNonQuery();
            if (rowsDeleted > 0)
            {
                Console.WriteLine("Delete Successfull");
                Console.WriteLine($"{rowsDeleted} rows deleted successfully");
            }
        }

        public static void DBDeleteMessage(string userName, string receiverUserName, DateTime dateOfSubmission)
        {
            SqlCommand cmdDelete = new SqlCommand($"DELETE FROM Messages WHERE Sender = '{userName}' AND Receiver = '{receiverUserName}' AND DateOfSubmission = '{dateOfSubmission}'", sqlConnection);
            int rowsDeleted = cmdDelete.ExecuteNonQuery();
            if (rowsDeleted > 0)
            {
                Console.WriteLine("Delete Successfull");
                Console.WriteLine($"{rowsDeleted} rows deleted successfully");
            }
        }

        public static void DBViewUsersforMessage(string senderUserName)
        {
            SqlCommand cmdSelect = new SqlCommand($"SELECT Name, LastName, UserName FROM UsersDetailsTable WHERE UserName != '{senderUserName}'", sqlConnection);
            SqlDataReader reader = cmdSelect.ExecuteReader();

            while (reader.Read())
            {
                User user = new User();

                user.Name = reader.GetString(0);
                user.LastName = reader.GetString(1);                
                user.UserName = reader.GetString(2);

                StringBuilder sb = new StringBuilder();
                sb
                    .AppendLine($"Name: {user.Name}")
                    .AppendLine($"LastName: {user.LastName}")
                    .AppendLine($"UserName: {user.UserName}");

                Console.WriteLine(sb);
            }
            reader.Close();
        }

        public static void DBExistentUserToSendMessage(string senderUserName, string userName)
        {
            SqlCommand cmdSelect = new SqlCommand($"SELECT COUNT(*) FROM UserNames WHERE UserName = @username", sqlConnection);
            cmdSelect.Parameters.AddWithValue("@username", $"{userName}");
            int result = (int)cmdSelect.ExecuteScalar();

            if (result > 0)
            {
                Console.WriteLine("Existent Username.");
            }
            else
            {
                Console.WriteLine("Non existent username.");
                DBMessageHandle.CreateMessage(senderUserName);
            }
        }

        public static void DBExistentUsernameInMessages(string senderUserName, string userName, DateTime dateOfSubmission)
        {
            SqlCommand cmdSelect = new SqlCommand($"SELECT COUNT(*) FROM Messages WHERE Receiver = @username AND DateOfSubmission = @dateOfSubmission", sqlConnection);
            cmdSelect.Parameters.AddWithValue("@username", $"{userName}");
            cmdSelect.Parameters.AddWithValue("@dateOfSubmission", $"{dateOfSubmission}");
            int result = (int)cmdSelect.ExecuteScalar();

            if (result > 0)
            {
                Console.WriteLine("Existent Log.");
            }
            else
            {
                Console.WriteLine("Non existent Log.");
                DBMessageHandle.EditMessage(senderUserName);
            }
        }

        public static User DBLogin(string userName, string password)
        {
            User user = new User();            

            SqlCommand cmdLogin = new SqlCommand($"SELECT COUNT(*) FROM UserNames WHERE UserName = @username AND Password = @password", sqlConnection);
            cmdLogin.Parameters.AddWithValue("@username", $"{userName}");
            cmdLogin.Parameters.AddWithValue("@password", $"{password}");
            int result = (int)cmdLogin.ExecuteScalar();    

            if (result > 0)
            {
                Console.WriteLine("User Login Successfully!");
                user = DBSelectAndFillInfoOfUser(userName);
            }
            else
            {
                Console.WriteLine("Not found User");
                user = LoginScreen.Login();
            }
            
            return user;
        }

        public static User DBSelectAndFillInfoOfUser(string username)
        {
            SqlCommand cmdSelect = new SqlCommand($"SELECT ID, Name, LastName, Age, Telephone, Email, Role, UserName FROM UsersDetailsTable WHERE UserName = @username", sqlConnection);
            cmdSelect.Parameters.AddWithValue("@username", $"{username}");
            
            SqlDataReader reader = cmdSelect.ExecuteReader();
            
            User user = new User();

            while(reader.Read())
            {                
                user.ID = reader.GetInt32(0);
                user.Name = reader.GetString(1);
                user.LastName = reader.GetString(2);
                user.Age = reader.GetInt32(3);
                user.Telephone = reader.GetString(4);
                user.Email = reader.GetString(5);
                user.Role = reader.GetInt32(6);
                user.UserName = reader.GetString(7);               

                Console.WriteLine(user);
            }
            reader.Close();
            return user;
        }

        public static void DBViewMessage(string userName)
        {
            SqlCommand cmdView = new SqlCommand($"SELECT DateOfSubmission, Sender, Receiver, MessageData FROM Messages WHERE Sender = '{userName}'", sqlConnection);
            SqlDataReader reader = cmdView.ExecuteReader();
            while (reader.Read())
            {
                Message message = new Message();
                message.DateOfSubmission = reader.GetDateTime(0);
                message.SenderUserName = reader.GetString(1);
                message.ReceiverUserName = reader.GetString(2);
                message.MessageData = reader.GetString(3);

                Console.WriteLine(message);
            }
            reader.Close();
        }

        public static void DBViewAllMessages()
        {
            SqlCommand cmdView = new SqlCommand($"SELECT DateOfSubmission, Sender, Receiver, MessageData FROM Messages", sqlConnection);
            SqlDataReader reader = cmdView.ExecuteReader();
            while (reader.Read())
            {
                Message message = new Message();
                message.DateOfSubmission = reader.GetDateTime(0);
                message.SenderUserName = reader.GetString(1);
                message.ReceiverUserName = reader.GetString(2);
                message.MessageData = reader.GetString(3);

                Console.WriteLine(message);
            }
            reader.Close();
        }

        public static void DBViewAllUsers()
        {
            SqlCommand cmdSelect = new SqlCommand($"SELECT ID, Name, LastName, Age, Telephone, Email, Role, UserName FROM UsersDetailsTable", sqlConnection);            
            SqlDataReader reader = cmdSelect.ExecuteReader();            
            while (reader.Read())
            {
                User user = new User();

                user.ID = reader.GetInt32(0);
                user.Name = reader.GetString(1);
                user.LastName = reader.GetString(2);
                user.Age = reader.GetInt32(3);
                user.Telephone = reader.GetString(4);
                user.Email = reader.GetString(5);
                user.Role = reader.GetInt32(6);
                user.UserName = reader.GetString(7);

                Console.WriteLine(user);
            }
            reader.Close();
        }        
    }
}
