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
            JsonTesting();

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
            Console.WriteLine(date.Day());
        }

        public static void UserControllerTesting()
        {
            String pass = "afgHH123456";
            String pass2 = "asHddggdgdgd33!@";
            bool ans = Backend.BusinessLayer.UserController.IsLegalPassword(pass2);
            Console.WriteLine(ans);
            
        }
        public static void JsonTesting()
        {
            Backend.ServiceLayer.Response response = new Backend.ServiceLayer.Response(true, "Hello World!");
            Console.WriteLine(response.GenerateJson());
        }
    }
}



