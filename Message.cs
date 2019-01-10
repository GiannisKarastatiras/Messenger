using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class Message
    {
        public DateTime DateOfSubmission { get; set; }
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }

        private string messageData;
        public string MessageData
        {
            get
            {
                return messageData;
            }
            set
            {
                if (value.Length > 250)
                    throw new ArgumentOutOfRangeException("MessageData", "MessageData Must be up to 250 characters!");

                messageData = value;
            }
        }

        public Message()
        {
        }

        public Message(DateTime dateOfSubmission, string senderUserName, string receiverUserName)
        {
            DateOfSubmission = dateOfSubmission;
            SenderUserName = senderUserName;
            ReceiverUserName = receiverUserName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .Append($"DateOfSubmission: {DateOfSubmission}\t")
                .Append($"Sender: {SenderUserName}\t")
                .Append($"Receiver: {ReceiverUserName}\t")
                .Append($"MessageData: {MessageData}");
                

            return sb.ToString();
        }

        
    }
}
