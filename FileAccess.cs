using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndividualProject
{
    public class FileAccess
    {
        public static string path = @//Specify the path here

        public static void StoreDataToAText(string path, DateTime dateOfSubmission, string sender, string receiver, string messageData)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"Date Of Submission: {dateOfSubmission}");
                    sw.WriteLine($"Sender: {sender}");
                    sw.WriteLine($"Receiver: {receiver}");
                    sw.WriteLine($"Message Data: {messageData}");

                }
            }
            else
            {
                using (StreamWriter s = File.AppendText(path))
                {
                    s.WriteLine();
                    s.WriteLine($"Date Of Submission: {dateOfSubmission}");
                    s.WriteLine($"Sender: {sender}");
                    s.WriteLine($"Receiver: {receiver}");
                    s.WriteLine($"Message Data: {messageData}");
                }
            }
        }

        //public static void StoreARevisedEditionOfMessageToAText(string path, DateTime dateOfSubmission, string sender, string receiver, string newMessageData, string messageData)
        //{
        //    using (StreamWriter s = File.AppendText(path))
        //    {
        //        s.WriteLine();
        //        s.WriteLine("Revised Edition");
        //        s.WriteLine($"Date Of Revised Edition: {DateTime.Now}");
        //        s.WriteLine($"Date Of First Submission: {dateOfSubmission}");                
        //        s.WriteLine($"Sender: {sender}");
        //        s.WriteLine($"Receiver: {receiver}");
        //        s.WriteLine($"First Submission Of Message Data: {messageData}");
        //        s.WriteLine($"Revised Edition Of Message Data: {newMessageData}");
                
                               
                
        //    }
        //}
    }
}
