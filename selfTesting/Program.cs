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
        CIString boardName2 = "board2";
        CIString title3 = "task3";
        CIString desc3 = "3bla";
        //DateTime cre1 = new DateTime(2022, 06, 15);
        //DateTime cre2 = new DateTime(2022, 06, 15);
        //DateTime cre3 = new DateTime(2022, 06, 15);
        DateTime due3 = new DateTime(2023, 06, 15);

        public static void Main(string[] args)
        {
            //CIStringDeserialization();
            //CIStringTesting();
            //getInProgress();
            //JsonTests();
            //Change_Owner_User_Joined_With_Tasks();
            //Remove_Board_Owner();
            //Leave_Board();
            //Limit_Column();
            //Join_To_Exsisting_BoardName();
            //Delete_Board();
            //Add_Board();
            change_Things();

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
            string user1 = "TestEmail@lol.com";
            string pass1 = "coolpAss2";
            string user2 = "yuval@lol.com";
            string pass2 = "coolpAss2";
            GradingService gs = new();
            Console.WriteLine(gs.DeleteData());
            Console.WriteLine(gs.Register(user1,pass1));
            Console.WriteLine(gs.Register(user2, pass2));
            Console.WriteLine(gs.AddBoard(user1,"Board1"));
            Console.WriteLine(gs.AddBoard(user2, "    "/*"BoardYuval"*/));
            Console.WriteLine(gs.JoinBoard(user2, 0));
            Console.WriteLine(gs.JoinBoard(user1, 0));
            Console.WriteLine(gs.JoinBoard(user2, 1));
            Console.WriteLine(gs.AddTask(user1,"board1","task1","",new DateTime(2200,2,2)));
            Console.WriteLine(gs.AddTask(user2, "BoardYuval", "task2", "", new DateTime(2200, 2, 2)));
            Console.WriteLine(gs.AssignTask(user1, "boaRd1", 0, 0, user1));
            Console.WriteLine(gs.AssignTask(user2, "boaRdYuval", 0, 0, user2));
            Console.WriteLine(gs.UpdateTaskDescription(/*user1*/"testemAil@lol.com", "BOARD1",0,0,"hello1upDated"));
            gs = new();
            Console.WriteLine(gs.LoadData());
            Console.WriteLine(gs.Login("TESTEMAIL@LOL.COM",pass1));
            Console.WriteLine(gs.Login(user2, pass2));
            Console.WriteLine(gs.GetUserBoards(user1));
            Console.WriteLine(gs.GetUserBoards(user2));
        }

        public static void Change_Owner_User_Joined_With_Tasks()
        {
            GradingService gs = new();
            gs.DeleteData();
            CIString email1 = "printz@post.bgu.ac.il";
            CIString email2 = "hadaspr100@gmail.com";
            CIString password1 = "Hadas1234";
            CIString password2 = "Printz1234";
            CIString boardName1 = "board1";
            CIString title1 = "task1";
            CIString desc1 = "1bla";
            DateTime due1 = new DateTime(2023, 06, 15);
            gs.Register(email1, password1);
            gs.AddBoard(email1, boardName1);
            gs.AddTask(email1, boardName1, title1, desc1, due1);
            gs.Register(email2, password2);
            gs.JoinBoard(email2, 0);
            gs.AssignTask(email1, boardName1, 0, 0, email1);
            gs.TransferOwnership(email1, email2, boardName1);
        }

        public static void Remove_Board_Owner()
        {
            GradingService gs = new();
            gs.DeleteData();
            CIString email1 = "printz@post.bgu.ac.il";
            CIString password1 = "Hadas1234";
            CIString boardName1 = "board1";
            CIString title1 = "task1";
            CIString desc1 = "1bla";
            DateTime due1 = new DateTime(2023, 06, 15);
            CIString title2 = "task2";
            CIString desc2 = "2bla";
            DateTime due2 = new DateTime(2023, 06, 15);
            CIString email2 = "hadaspr100@gmail.com";
            CIString password2 = "Printz1234";
            gs.Register(email1, password1);
            gs.Register(email2, password2);
            gs.AddBoard(email1, boardName1);
            gs.AddTask(email1, boardName1, title1, desc1, due1);
            gs.AddTask(email1, boardName1, title2, desc2, due2);
            gs.JoinBoard(email2, 0);
            gs.RemoveBoard(email1, boardName1);
        }

        public static void Leave_Board()
        {
            GradingService gs = new();
            gs.DeleteData();
            CIString email1 = "printz@post.bgu.ac.il";
            CIString password1 = "Hadas1234";
            CIString boardName1 = "board1";
            CIString title1 = "task1";
            CIString desc1 = "1bla";
            DateTime due1 = new DateTime(2023, 06, 15);
            CIString title2 = "task2";
            CIString desc2 = "2bla";
            DateTime due2 = new DateTime(2023, 06, 15);
            CIString email2 = "hadaspr100@gmail.com";
            CIString password2 = "Printz1234";
            gs.Register(email1, password1);
            gs.Register(email2, password2);
            gs.AddBoard(email1, boardName1);
            gs.JoinBoard(email2, 0);
            gs.AddTask(email1, boardName1, title1, desc1, due1);
            gs.AddTask(email1, boardName1, title2, desc2, due2);
            gs.AssignTask(email1, boardName1, 0, 0, email1);
            gs.AssignTask(email2, boardName1, 0, 1, email2);
            gs.LeaveBoard(email2, 0);
        }

        public static void Limit_Column()
        {
            GradingService gs = new();
            gs.DeleteData();
            CIString email1 = "printz@post.bgu.ac.il";
            CIString password1 = "Hadas1234";
            CIString boardName1 = "board1";
            CIString title1 = "task1";
            CIString desc1 = "1bla";
            DateTime due1 = new DateTime(2023, 06, 15);
            CIString title2 = "task2";
            CIString desc2 = "2bla";
            DateTime due2 = new DateTime(2023, 06, 15);
            gs.Register(email1, password1);
            gs.AddBoard(email1, boardName1);
            gs.AddTask(email1, boardName1, title1, desc1, due1);
            gs.AddTask(email1, boardName1, title2, desc2, due2);
            gs.AddTask(email1, boardName1, title2, desc2, due2);
            gs.AddTask(email1, boardName1, title2, desc2, due2);
            gs.AddTask(email1, boardName1, title2, desc2, due2);
            gs.AddTask(email1, boardName1, title2, desc2, due2);
            gs.AssignTask(email1, boardName1, 0, 0, email1);
            gs.AssignTask(email1, boardName1, 0, 1, email1);
            gs.AssignTask(email1, boardName1, 0, 2, email1);
            gs.AssignTask(email1, boardName1, 0, 3, email1);
            gs.AssignTask(email1, boardName1, 0, 4, email1);
            gs.AssignTask(email1, boardName1, 0, 5, email1);
            gs.LimitColumn(email1, boardName1, 1, 4);
            gs.AdvanceTask(email1, boardName1, 0, 1);
            gs.AdvanceTask(email1, boardName1, 0, 2);
            gs.AdvanceTask(email1, boardName1, 0, 3);
            gs.AdvanceTask(email1, boardName1, 0, 4);
            gs.AdvanceTask(email1, boardName1, 0, 5);
        }

        public static void Join_To_Exsisting_BoardName()
        {
            GradingService gs = new();
            gs.DeleteData();
            CIString email1 = "printz@post.bgu.ac.il";
            CIString password1 = "Hadas1234";
            CIString boardName1 = "board1";
            CIString boardName2 = "board1";
            gs.Register(email1, password1);
            gs.AddBoard(email1, boardName1);
            CIString email2 = "hadaspr100@gmail.com";
            CIString password2 = "Printz1234";
            gs.Register(email2, password2);
            gs.AddBoard(email2, boardName2);
            Console.WriteLine(gs.JoinBoard(email2, 0));
        }

        public static void Delete_Board()
        {
            GradingService gs = new();
            gs.DeleteData();
            CIString email1 = "printz@post.bgu.ac.il";
            CIString password1 = "Hadas1234";
            CIString boardName1 = "board1";
            gs.Register(email1, password1);
            gs.AddBoard(email1, boardName1);
            gs.Logout(email1);
            CIString email2 = "hadaspr100@gmail.com";
            CIString password2 = "Printz1234";
            gs.Register(email2, password2);
            gs.JoinBoard(email2, 0);
        }

        public static void Add_Board()
        {
            GradingService gs = new();
            gs.DeleteData();
            CIString email1 = "printz@post.bgu.ac.il";
            CIString password1 = "Hadas1234";
            CIString boardName1 = "board1";
            gs.Register(email1, password1);
            gs.AddBoard(email1, boardName1);
            CIString email2 = "hadaspr100@gmail.com";
            CIString password2 = "Printz1234";
            gs.Register(email2, password2);
            CIString title1 = "task1";
            CIString desc1 = "1bla";
            DateTime due1 = new DateTime(2023, 06, 15);
            gs.AddTask(email2, boardName1, title1, desc1, due1);
        }

        public static void change_Things()
        {
            GradingService gs = new();
            gs.DeleteData();
            CIString email1 = "printz@post.bgu.ac.il";
            CIString password1 = "Hadas1234";
            CIString boardName1 = "board1";
            gs.Register(email1, password1);
            gs.AddBoard(email1, boardName1);
            CIString title1 = "task1";
            CIString desc1 = "1bla";
            DateTime due1 = new DateTime(2023, 06, 15);
            gs.AddTask(email1, boardName1, title1, desc1, due1);
            CIString email2 = "hadaspr100@gmail.com";
            CIString password2 = "Printz1234";
            gs.Register(email2, password2);
            gs.JoinBoard(email2, 0);
            gs.AssignTask(email2, boardName1, 0, 0, email1);
        }
    }
}
