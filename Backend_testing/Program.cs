
namespace IntroSE.Kanban.Backend_testing
{
    public class Program
    {
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



