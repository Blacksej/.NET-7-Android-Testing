using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMenuTest.Model
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }


        public UserModel(string name, string password, int age)
        {
            this.Name = name;
            this.Password = password;
            this.Age = age;
        }
    }
}
