using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// JsonConstructorAttribute
    /// </summary>
    public static class Recipe6Program
    {
        public static void Run()
        {
            //The JsonConstructorAttribute instructs the JsonSerializer to use a specific constructor when deserializing a class. 
            //It can be used to create a class using a parameterized constructor instead of the default constructor, 
            //or to pick which specific parameterized constructor to use if there are multiple.
          
            string json = @"{
                              ""UserName"": ""domain\\username"",
                               ""Enabled"": true
                            }";

            User user = JsonConvert.DeserializeObject<User>(json);

            System.Console.WriteLine(user.UserName);
        }
        public class User
        {
            public string UserName { get; private set; }
            public bool Enabled { get; private set; }
            [JsonConstructor]
            public User(string userName, bool enabled)
            {
                UserName = userName;
                Enabled = enabled;
            }
        }
    }
   
}
