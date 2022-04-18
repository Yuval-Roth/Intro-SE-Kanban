
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
            Backend.BusinessLayer.BinaryTree<int> tree1 = new Backend.BusinessLayer.BinaryTree<int>();
            tree1.Add(5);
            Backend.BusinessLayer.BinaryTree<int> tree2 = new Backend.BusinessLayer.BinaryTree<int>();
            tree2.Add(6);
            
            Console.WriteLine(tree1.Equals(tree2));
        }
    }
}



