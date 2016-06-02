using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// StringEnumConverter
    /// </summary>
    public static class Recipe4Program
    {
        public static void Run()
        {
            User user = new User();
            user.UserName = "tangwh";
            user.Status = UserStatus.Active;
            string jsonStr = JsonConvert.SerializeObject(user);
            System.Console.WriteLine(jsonStr);
            //output:{"UserName":"tangwh","Status":"Active"}
        }
    }
}
