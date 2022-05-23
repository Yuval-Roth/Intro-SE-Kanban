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
            AVLTreeTesting();
            //BoardTreeTesting();
            //datetesting();
            //UserControllerTesting();
            //JsonTesting();
            //PasswordHashingTesting();
            //logTesting();
            //registerTest();
            //validEmailTest();
            //enumsTests();
            //gradingTests();
            //tests();

        }
        public static void AVLTreeTesting()
        {
            int count = 15;
            Backend.BusinessLayer.AVLTree<int, int> tree1 = new();
            Random random = new Random();
            int[] nums = {409, 123, 227, -10, 90, -304, -324, 330, -335, -316, 431, -271, -122, -267, 197 };
            //int[] nums = new int[count];
            for (int i = 0; i < count; i++)
            {
                int num = random.Next(-500, 500);
                try
                {
                    tree1.Add(nums[i], 6);
                    //tree1.Add(num, 6);
                    //nums[i] = num;
                }
                catch (ArgumentException) { }
            }
            tree1.PrintTree();
            //Console.Write("{ ");
            //foreach (int o in nums)
            //{
            //    Console.Write(o + ", ");
            //}
            //Console.WriteLine("}");
            //tree1.Remove(nums[0]);
            //tree1.Remove(nums[1]);
            //tree1.Remove(nums[2]);
            //tree1.Remove(nums[3]);
            //tree1.Remove(nums[4]);
            ////tree1.Remove(nums[5]);
            //Console.WriteLine("==========================================================");
            //Console.WriteLine(tree1.ToString());

            //for (int i = 5; i < count; i++)
            //{
            //    try
            //    {
            //        Console.WriteLine("Remove for " + nums[i]);
            //        Console.WriteLine();
            //        tree1.Remove(nums[i]);
            //    }
            //    catch (Backend.BusinessLayer.NoSuchElementException) { }
                //Console.WriteLine("==========================================================");
                //tree1.PrintTree();
            //}
        }
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

        public static void gradingTests()
        {
            Backend.ServiceLayer.GradingService gs = new();
            Console.WriteLine(gs.Register("blahblah@gmail.com", "SismaTil123"));
            Console.WriteLine(gs.Login("blahblah@gmail.com", "SismaTil123"));
            Console.WriteLine(gs.AddBoard("blahblah@gmail.com", "test"));
            Console.WriteLine(gs.AddTask("blahblah@gmail.com", "test", "toDo_ZERO", "stam", new DateTime(2022, 5, 20)));
            Console.WriteLine(gs.AddTask("blahblah@gmail.com", "test", "toDo_ONE", "stam", new DateTime(2022, 5, 20)));
            Console.WriteLine(gs.AdvanceTask("blahblah@gmail.com", "test", 0, 0));
            Console.WriteLine(gs.AdvanceTask("blahblah@gmail.com", "test", 0, 1));
            Backend.ServiceLayer.GradingService.GradingResponse<LinkedList<Backend.BusinessLayer.Task>> res =
                Backend.ServiceLayer.JsonController.BuildFromJson<Backend.ServiceLayer.
                GradingService.GradingResponse<LinkedList<Backend.BusinessLayer.Task>>>(gs.InProgressTasks("blahblah@gmail.com"));
            Console.WriteLine(gs.InProgressTasks("blahblah@gmail.com"));
            LinkedList<Backend.BusinessLayer.Task> taskList = res.ReturnValue;
            foreach (Backend.BusinessLayer.Task task in taskList)
            {
                Console.WriteLine(task.Id);
            } 
        }

        public static void tests()
        {
            Backend.ServiceLayer.GradingService gradingService = new ();
            string email = "rrr@gmial.com";
            string board = "one";
            gradingService.Register(email, "Aka123k123");
            gradingService.Login(email, "Aka123k123");
            string invalid = "jgiosejiooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooojjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjoooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo";
            gradingService.AddBoard(email, "one");
            gradingService.AddTask(email, "one", "bRAND", "HELLOW WORLD", DateTime.Now);
            gradingService.AddTask(email, "one", "new", "HELLOW WORLD", DateTime.Now);
            gradingService.AdvanceTask(email, "one", 0, 0);
            gradingService.AdvanceTask(email, "one", 0, 1);
            gradingService.AdvanceTask(email, "one", 1, 0);
            gradingService.AdvanceTask(email, "one", 1, 1);
            gradingService.AddTask(email, "one", "new", "HELLOW WORLD", DateTime.Now);
            gradingService.AdvanceTask(email, "one", 2, 0);
            gradingService.AdvanceTask(email, "one", 0, 0); // no such task in column 0
            gradingService.AdvanceTask(email, "one", 0, 2);
            gradingService.InProgressTasks(email);
            gradingService.LimitColumn(email, board, 1, 5);
            gradingService.LimitColumn(email, board, 1, 4);
            gradingService.LimitColumn(email, board, 1, 10);
            gradingService.GetColumnLimit(email, board, 1);
            gradingService.GetColumnName(email, board, 5); // INVALID NUMBER
            gradingService.AddTask(email, "three", "new", "HELLOW WORLD", DateTime.Now); // no such board three
            gradingService.UpdateTaskDueDate(email, "one", 1, 0, DateTime.Now);// not good , changes to task that not in true coloumn number
            gradingService.UpdateTaskDueDate(email, "one", 9, 2, DateTime.Now);// not good , changes to invalid coloumn number
            gradingService.RemoveBoard(email, "one");
            gradingService.AddTask(email, "one", "new", "HELLOW WORLD", DateTime.Now);
            gradingService.AddBoard(email, "two");
            gradingService.AddTask(email, "two", "new", "HELLOW WORLD", DateTime.Now);
            gradingService.UpdateTaskDueDate(email, "two", 0, 0, DateTime.Now);//
            gradingService.UpdateTaskTitle(email, "two", 0, 0, "new title");//
            gradingService.UpdateTaskTitle(email, "two", 0, 1, "new title");//no such task
            gradingService.AdvanceTask(email, "two", 0, 0);
            gradingService.UpdateTaskTitle(email, "two", 1, 0, "new title");//
            gradingService.UpdateTaskTitle(email, "two", 1, 0, invalid);//invalid title
            gradingService.UpdateTaskDescription(email, "two", 1, 0, "new descp");
            gradingService.UpdateTaskDescription(email, "two", 1, 0, invalid);//
            gradingService.LimitColumn(email, "two", 1, 1);
            gradingService.AddTask(email, "two", "new task", "HELLOW WORLD", DateTime.Now);
            Console.WriteLine(gradingService.AdvanceTask(email, "two", 0, 1)); // the column in full
        }

    }

}



