using System.Text.Json;
namespace IntroSE.Kanban.selfTesting
{
    public class Program
    {

        //============== READ ME ==================

        // This is an executable project to test code during development 

        //============== READ ME ================== 

        public static void Main(string[] args)
        {
            //BinaryTreeTesting();
            //BoardTreeTesting();
            //datetesting();
            //UserControllerTesting();
            //JsonTesting();
            //PasswordHashingTesting();



        }
        public static void BinaryTreeTesting()
        {
            //Backend.BusinessLayer.BinaryTree<int,int> tree1 = new();
            //tree1.Add(7,1);
            //tree1.Add(9,2);
            //tree1.Add(2,3);
            //tree1.Add(3,4);
            //tree1.Add(1,5);
            //tree1.Add(-5,6);

            //Console.WriteLine(tree1.GetData(7));

        }
        public static void BoardTreeTesting() 
        {
            //Backend.BusinessLayer.User user1 = new Backend.BusinessLayer.User("yuval", "12345");
            //Backend.BusinessLayer.User user2 = new Backend.BusinessLayer.User("yuval2", "12345");
            //Backend.BusinessLayer.BoardTree tree = new Backend.BusinessLayer.BoardTree();

            //Backend.BusinessLayer.Board board = tree.AddBoard(user1, "test");
            //tree.RemoveBoard(user1, "test");
            //tree.GetAllBoards(user1);
            //tree.RemoveBoard(user1, "test");
            //tree.GetAllBoards(user1);
        }
        public static void DateTesting()
        {
            //Backend.BusinessLayer.Date date = new Backend.BusinessLayer.Date("12.6.1998");
            //Console.WriteLine(date.day);
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
            //Backend.ServiceLayer.Response res = new("hello");
            //string json = Backend.ServiceLayer.JsonController.ConvertToJson(res);
            //Console.WriteLine(json);
            //Backend.ServiceLayer.Response des = Backend.ServiceLayer.JsonController.BuildFromJson<Backend.ServiceLayer.Response>(json);
            //Console.WriteLine(des.ReturnValue==null);
            //Console.WriteLine(des.ErrorMessage);

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
            //Backend.BusinessLayer.PasswordHash passwordHash = new Backend.BusinessLayer.PasswordHash();

            //Backend.BusinessLayer.User user = new("test","TestPassword12");
            //Console.WriteLine(user.CheckPasswordMatch("TestPassword12"));
        }
    }
}



