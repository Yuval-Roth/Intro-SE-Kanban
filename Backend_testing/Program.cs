
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
            BinaryTreeTesting();
        }
        public static void BinaryTreeTesting()
        {
            Backend.BusinessLayer.BinaryTree<int> tree = new Backend.BusinessLayer.BinaryTree<int>();
            tree.Add(5);
            tree.Add(6);
            Console.WriteLine(tree.Search(5).Successor().GetElement());
        }
    }
}



