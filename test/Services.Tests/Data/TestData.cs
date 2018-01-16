using Newtonsoft.Json.Linq;
using Services.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Services.Users.Models;

namespace Services.Tests.Data
{
    public class TestData
    {
        //FIX THIS
        public readonly User userData;

        public TestData(string user)
        {
            this.userData = LoadTestData(user);
        }

        public User LoadTestData(string user)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(
                assembly.GetManifestResourceStream("Services.Tests.Resources.data.json")
            );
            JObject obj = JObject.Parse(reader.ReadToEnd());

            // set default if not provided
            if (user == null)
                user = "canton7";

            var node = obj[user];

            return node.ToObject<User>();
        }
    }
}
