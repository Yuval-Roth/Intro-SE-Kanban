using System;
using System.Collections.Generic;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.DataAccessLayer;
using IntroSE.Kanban.Backend.ServiceLayer;
using IntroSE.Kanban.Backend.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace IntroSE.Kanban.selfTesting
{
    public class Program
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("selfTesting\\Program.cs");

        public static void Main(string[] args)
        {
            CIStringDeserialization();
        }
        public static void CIStringDeserialization()
        {
            CIString str = new("test");
            string json = JsonSerializer.Serialize(str);
            Console.WriteLine(json);
            CIString str1 = JsonSerializer.Deserialize<CIString>(json);
            Console.WriteLine(str1);
        }
    }
}
