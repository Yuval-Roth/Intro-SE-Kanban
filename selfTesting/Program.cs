using System.Text.Json;

[assembly: log4net.Config.XmlConfigurator(ConfigFile ="log4net.config" ,Watch = true)]
namespace IntroSE.Kanban.selfTesting
{
    public class Program
    {

        //============== READ ME ==================

        // This is an executable project to test code during development 

        //============== READ ME ================== 

        private static log4net.ILog log = log4net.LogManager.GetLogger("selfTesting\\Program.cs");

        public static void Main(string[] args)
        {
            //BinaryTreeTesting();
            //BoardTreeTesting();
            //datetesting();
            //UserControllerTesting();
            //JsonTesting();
            //PasswordHashingTesting();
            //logTesting();
            //registerTest();
            //validEmailTest();
            //enumsTests();
            gradingTests();

        }
        //public static void BinaryTreeTesting()
        //{
        //    //Backend.BusinessLayer.BinaryTree<int,int> tree1 = new();
        //    //tree1.Add(7,1);
        //    //tree1.Add(9,2);
        //    //tree1.Add(2,3);
        //    //tree1.Add(3,4);
        //    //tree1.Add(1,5);
        //    //tree1.Add(-5,6);

        //    //Console.WriteLine(tree1.GetData(7));

        //}
        //public static void BoardTreeTesting() 
        //{
        //    //Backend.BusinessLayer.User user1 = new Backend.BusinessLayer.User("yuval", "12345");
        //    //Backend.BusinessLayer.User user2 = new Backend.BusinessLayer.User("yuval2", "12345");
        //    //Backend.BusinessLayer.BoardTree tree = new Backend.BusinessLayer.BoardTree();

        //    //Backend.BusinessLayer.Board board = tree.AddBoard(user1, "test");
        //    //tree.RemoveBoard(user1, "test");
        //    //tree.GetAllBoards(user1);
        //    //tree.RemoveBoard(user1, "test");
        //    //tree.GetAllBoards(user1);
        //}
        //public static void DateTesting()
        //{
        //    //Backend.BusinessLayer.Date date = new Backend.BusinessLayer.Date("12.6.1998");
        //    //Console.WriteLine(date.day);
        //}

        //public static void UserControllerTesting()
        //{
        //    //String pass = "afgHH123456";
        //    //String pass2 = "asHddggdgdgd33!@";
        //    //bool ans = Backend.BusinessLayer.UserController.IsLegalPassword(pass2);
        //    //Console.WriteLine(ans);


            
        //}
        //public static void JsonTesting()
        //{
        //    Backend.ServiceLayer.Response<string> res = new(true,"hello");
        //    string json = Backend.ServiceLayer.JsonController.ConvertToJson(res);
        //    Console.WriteLine(json);
        //    Backend.ServiceLayer.Response<string> des = Backend.ServiceLayer.JsonController.BuildFromJson<Backend.ServiceLayer.Response<string>>(json);
        //    Console.WriteLine(des.returnValue);
        //    Console.WriteLine(des.operationState);
        //    Console.WriteLine("========================");
        //    Backend.BusinessLayer.Task task = new()
        //    {
        //        Id= 1,
        //        Title= "sup",
        //        CreationTime= DateTime.Now,
        //        DueDate= DateTime.Now,
        //        Description = "bro"
        //    };
        //    Backend.ServiceLayer.Response<Backend.BusinessLayer.Task> res1 = new(true, task);
        //    json = Backend.ServiceLayer.JsonController.ConvertToJson(res1);
        //    Backend.ServiceLayer.Response<Backend.BusinessLayer.Task> des1 = Backend.ServiceLayer.JsonController.BuildFromJson<Backend.ServiceLayer.Response<Backend.BusinessLayer.Task>>(json);
        //    Console.WriteLine(des1.returnValue.Id);
        //    Console.WriteLine(des1.returnValue.Description);
        //    Console.WriteLine(des1.operationState);

        //}
        //public static void PasswordHashingTesting()
        //{
            //int sum = 0;
            //int max = 0;
            //int min = 100000;
            //for (int i = 0; i < 500; i++) 
            //{
            //    Backend.BusinessLayer.PasswordHash passwordHash = new Backend.BusinessLayer.PasswordHash();
            //    string temp = passwordHash.Hash("t%3Ka6gaw2^1sJ5AF");
            //    sum += temp.Length;
            //    if (min > temp.Length) min = temp.Length;
            //    if (max < temp.Length) max = temp.Length;
            //}
            //Console.WriteLine("min: "+min);
            //Console.WriteLine("max: "+max);
            //Console.WriteLine("avg: "+(sum / 500));
            //for (int i = 0; i < 50; i++) 
            //{
            //Backend.BusinessLayer.PasswordHash passwordHash = new Backend.BusinessLayer.PasswordHash();

            //Backend.BusinessLayer.User user = new("test","TestPassword12");
            //Console.WriteLine(user.CheckPasswordMatch("TestPassword12"));
        //}
        //public static void logTesting()
        //{
        //    log.Debug("Hello m8");
        //}
        //public static void registerTest()
        //{
        //    Backend.ServiceLayer.GradingService gs = new();
        //    gs.Register("test", "sismaSababa23");
        //    Console.WriteLine(gs.Login("test", "sismaSababa23"));
        //    Console.WriteLine(gs.Logout("test"));
        //}

        //public static void validEmailTest()
        //{
        //    Backend.ServiceLayer.GradingService gs = new();
        //    //gs.Register("test", "sismaSababa23");
        //    //Console.WriteLine(gs.Login("test", "sismaSababa23"));
        //    //Console.WriteLine(gs.Logout("test"));
        //    string email = "prinrz@post.bgu.ac.il";
        //    string email1 = "Prein@pdij";
        //    string email2 = "12344.@gmail.com"; //false/ true?
        //    string email3 = "hadaspr100gmail.com";
        //    string email4 = "hadas@gmailcom";
        //    string email5 = null;
        //    string email6 = "fdsa";
        //    string email7 = "fdsa@";
        //    string email8 = "fdsa@fdsa";
        //    string email9 = "fdsa@fdsa.";
        //    string email10 = "someone@somewhere.com";
        //    string email11 = "someone@somewhere.co.uk";
        //    string email12 = "someone+tag@somewhere.net"; // false/true?
        //    string email13 = "futureTLD@somewhere.fooo";
        //    bool ans = Backend.BusinessLayer.UserController.IsEmailValid(email13);
        //    Console.WriteLine(ans);
        //}
        public enum State
        {
            backlog,
            inprogress,
            done,
        }
        public static void enumsTests()
        {
            Console.WriteLine("hello: "+(int)State.backlog);
        }
    }
}



