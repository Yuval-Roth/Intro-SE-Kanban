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
            //CIStringDeserialization();
            //CIStringTesting();
            //getInProgress();
            JsonTests();
        }
        public static void CIStringDeserialization()
        {
            CIString str = new("test");
            string json = JsonSerializer.Serialize(str);
            Console.WriteLine(json);
            CIString str1 = JsonSerializer.Deserialize<CIString>(json);
            Console.WriteLine(str1);
        }
        public static void CIStringTesting()
        {
            stringCompare("test2", "tEst2");

        }
        public static void stringCompare(string s1,string s2)
        {
            Console.WriteLine(s1== (CIString)s2); // true
        }
        public static void getInProgress()
        {
            GradingService gs = new();
            gs.Register("TestEmail@post.bgu.ac.il", "Coolpass1234");
            gs.AddBoard("TestEmail@post.bgu.ac.il", "test");
            gs.AddTask("TestEmail@post.bgu.ac.il", "test", "1", "bla", new DateTime(2200, 10, 20));
            gs.AddTask("TestEmail@post.bgu.ac.il", "test", "2", "blabla", new DateTime(2200,10,20));
            gs.AssignTask("TestEmail@post.bgu.ac.il", "test", 0, 0, "TestEmail@post.bgu.ac.il");
            gs.AssignTask("TestEmail@post.bgu.ac.il", "test", 0, 1, "TestEmail@post.bgu.ac.il");
            gs.AdvanceTask("TestEmail@post.bgu.ac.il", "test", 0, 0);
            gs.AdvanceTask("TestEmail@post.bgu.ac.il", "test", 0, 1);
            Console.WriteLine(gs.GetColumn("TestEmail@post.bgu.ac.il", "test", 1));
            string json = gs.GetColumn("TestEmail@post.bgu.ac.il", "test", 1);
            GradingResponse<LinkedList<Backend.BusinessLayer.Task>> res =
                JsonController.BuildFromJson<GradingResponse<LinkedList<Backend.BusinessLayer.Task>>>(json);
            LinkedList<Backend.BusinessLayer.Task> list = res.ReturnValue;
            foreach (Backend.BusinessLayer.Task task in list)
            {
                Console.WriteLine(task.CreationTime);
            }
        }
        public static void JsonTests()
        {
            GradingService gs = new();
            
            for(int i = 0; i < 10; i++)
            Console.WriteLine(gs.Register($"Testemail{i}@lol.com","coolpAss2"));
            ServiceLayerFactory.DeleteEverything();
            gs = new();
            Console.WriteLine(gs.LoadData());
            Console.WriteLine(gs.DeleteData());
        }
    }
}
