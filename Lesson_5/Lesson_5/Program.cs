using System;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // массив значений для сбалансированного дерева
            int[] ValueArray = new int[] { 4, 5, 9, 98, 33, 23, 88, 73, 98, 66, 89, 54 };

            // Создание сбалансированного дерева:
            TreeBuilder treeBuilder = new TreeBuilder();                        
            TreeBuilder.Node<int> root = new TreeBuilder.Node<int>();

            root = treeBuilder.BalanceTree(ValueArray, ValueArray.Length, null);
            Console.WriteLine("Визуализация созданнного дерева:");
            treeBuilder.PreOrderTravers(root);

            Console.WriteLine(); Console.WriteLine();
            // Обход дерева в ширену BFS (breadth-first serche) 

            int serchedValue = 2;
            var rezultBFS = treeBuilder.BFSTravers(root, serchedValue);
            bool rezSerch = false;
            if (rezultBFS != null)
                rezSerch = true;
            Console.WriteLine($"Поиск в ширину узла дерева со значением {serchedValue} дал результат {rezSerch}, узел дерева {rezultBFS}");

            // Обход дерева в глубину BFS (breadth-first serche) 
            serchedValue = 9;
            var rezultDFS = treeBuilder.DFSTravers(root, serchedValue);
            rezSerch = false;
            if (rezultDFS != null)
                rezSerch = true;
            Console.WriteLine($"Поиск в глубину узла дерева со значением {serchedValue} дал результат {rezSerch}, узел дерева {rezultDFS}");
            Console.WriteLine();
        }
    }
}
