using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class User
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        


        public User()
        {           
        }

        public User(string name, string lastName, int age, string telephone, string email, string userName, string password, int role)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Telephone = telephone;
            Email = email;
            UserName = userName;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"UserID: {ID}")
                .AppendLine($"Name: {Name}")
                .AppendLine($"Surname: {LastName}")
                .AppendLine($"Age: {Age}")
                .AppendLine($"Telephone: {Telephone}")
                .AppendLine($"Email: {Email}")
                .AppendLine($"UserName: {UserName}")
                .AppendLine();
                
                //.Append($"Username is {UserName}")
                //.Append($"Password is {Password}");*/

            return sb.ToString();
        }
    }
}
