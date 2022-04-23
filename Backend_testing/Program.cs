using System.Text.Json;
namespace IntroSE.Kanban.Backend_testing
{
    public class Program
    {

        //============== READ ME ==================

        // kfir and hadas, you might need to exclude from project class files that are causing compilation error
        // in order to run testing here.

        // ask yuval how to do it and how to re-include them after you're done

        //============== READ ME ================== 

        public static void Main(string[] args)
        {
            //BinaryTreeTesting();
            //BoardTreeTesting();
            //datetesting();
            //UserControllerTesting();
            //JsonTesting();
            PasswordHashingTesting();



        }
        public static void BinaryTreeTesting()
        {
            Backend.BusinessLayer.BinaryTree<int> tree1 = new Backend.BusinessLayer.BinaryTree<int>();
            tree1.Add(5);
            Backend.BusinessLayer.BinaryTree<int> tree2 = new Backend.BusinessLayer.BinaryTree<int>();
            tree2.Add(6);
            
            Console.WriteLine(tree1.Equals(tree2));
        }
        public static void BoardTreeTesting() 
        {
            Backend.BusinessLayer.User user1 = new Backend.BusinessLayer.User("yuval", "12345");
            Backend.BusinessLayer.User user2 = new Backend.BusinessLayer.User("yuval2", "12345");
            Backend.BusinessLayer.BoardTree tree = new Backend.BusinessLayer.BoardTree();

            Backend.BusinessLayer.Board board = tree.AddBoard(user1, "test");
            tree.RemoveBoard(user1, "test");
            tree.GetAllBoards(user1);
            //tree.RemoveBoard(user1, "test");
            //tree.GetAllBoards(user1);
        }
        public static void DateTesting()
        {
            Backend.BusinessLayer.Date date = new Backend.BusinessLayer.Date("12.6.1998");
            Console.WriteLine(date.day);
        }

        public static void UserControllerTesting()
        {
            //String pass = "afgHH123456";
            //String pass2 = "asHddggdgdgd33!@";
            //bool ans = Backend.BusinessLayer.UserController.IsLegalPassword(pass2);
            //Console.WriteLine(ans);


            
        }
        public static void JsonTesting()
        {
            //    Backend.BusinessLayer.Serializable.Board_Serializable board = new() 
            //    {
            //        Title = "TestBoard"
            //    };
            //    board.Backlog = new LinkedList<Backend.BusinessLayer.Serializable.Task_Serializable>();
            //    board.Backlog.AddLast(new Backend.BusinessLayer.Serializable.Task_Serializable
            //    {
            //        Title = "task1",
            //        CreationTime = new Backend.BusinessLayer.Date("16/25/1900"),
            //        Description = "stahp",
            //        DueDate = new Backend.BusinessLayer.Date("16/25/1909"),
            //        State = Backend.BusinessLayer.TaskStates.backLog
            //    });
            //    board.InProgress = new LinkedList<Backend.BusinessLayer.Serializable.Task_Serializable>();
            //    board.InProgress.AddLast(new Backend.BusinessLayer.Serializable.Task_Serializable
            //    {
            //        Title = "task2",
            //        CreationTime = new Backend.BusinessLayer.Date("16/25/1900"),
            //        Description = "STAHP",
            //        DueDate = new Backend.BusinessLayer.Date("16/25/1909"),
            //        State = Backend.BusinessLayer.TaskStates.inProgress
            //    });
            //    board.Done = new LinkedList<Backend.BusinessLayer.Serializable.Task_Serializable>();
            //    board.Done.AddLast(new Backend.BusinessLayer.Serializable.Task_Serializable
            //    {
            //        Title = "task3",
            //        CreationTime = new Backend.BusinessLayer.Date("16/25/1900"),
            //        Description = "STAHHHHP",
            //        DueDate = new Backend.BusinessLayer.Date("16/25/1909"),
            //        State = Backend.BusinessLayer.TaskStates.done
            //    });
            //    string json = Backend.ServiceLayer.JsonController.Serialize(board);
            //    Console.WriteLine(json);
            //    Console.WriteLine("=========================");

            //    Backend.BusinessLayer.Board deserialized =
            //        Backend.ServiceLayer.JsonController.Deserialize<Backend.BusinessLayer.Board>(json);


            //    foreach (Backend.BusinessLayer.Task task in deserialized.Backlog) 
            //    {
            //        Console.WriteLine(task.Title);
            //        Console.WriteLine(task.Description);
            //        Console.WriteLine(task.CreationTime);
            //        Console.WriteLine(task.DueDate);
            //        Console.WriteLine(task.State);
            //    }
            //    Console.WriteLine("=========================");
            //    foreach (Backend.BusinessLayer.Task task in deserialized.InProgress)
            //    {
            //        Console.WriteLine(task.Title);
            //        Console.WriteLine(task.Description);
            //        Console.WriteLine(task.CreationTime);
            //        Console.WriteLine(task.DueDate);
            //        Console.WriteLine(task.State);
            //    }
            //    Console.WriteLine("=========================");
            //    foreach (Backend.BusinessLayer.Task task in deserialized.Done)
            //    {
            //        Console.WriteLine(task.Title);
            //        Console.WriteLine(task.Description);
            //        Console.WriteLine(task.CreationTime);
            //        Console.WriteLine(task.DueDate);
            //        Console.WriteLine(task.State);
            //    }


           
        }
        public static void PasswordHashingTesting()
        {
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
            Backend.BusinessLayer.PasswordHash passwordHash = new Backend.BusinessLayer.PasswordHash();

            Backend.BusinessLayer.User user = new("test","TestPassword12");
            Console.WriteLine(user.CheckPasswordMatch("TestPassword12"));
        }
    }
}



