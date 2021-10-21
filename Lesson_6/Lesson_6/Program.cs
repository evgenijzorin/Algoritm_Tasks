using System;
using System.Collections.Generic;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {            
            const int N = 6;
            // Заполнение весовой матрицы
            int[,] arrayWeigth = new int[N, N] // Весовая матрица
                {
                    {99,1, 2, 99,99,99},
                    {1, 99,9, 10,99,99},
                    {2, 9, 99,8, 5, 99},
                    {99,10,8, 99,3, 1},
                    {99,99,5, 3, 99,3},
                    {99,99,99,1, 3, 99}
                };
            // Построение Графа 
            GraphBuilder graphBuilder = new GraphBuilder();
            // Создать узлы
            Node nodeA = new Node();
            nodeA.Value = "A"; nodeA.IsTraversed = false;
            Node nodeB = new Node();
            nodeB.Value = "B"; nodeB.IsTraversed = false;
            Node nodeC = new Node();
            nodeC.Value = "C"; nodeC.IsTraversed = false;
            Node nodeD = new Node();
            nodeD.Value = "D"; nodeD.IsTraversed = false;
            Node nodeE = new Node();
            nodeE.Value = "E"; nodeE.IsTraversed = false;
            Node nodeF = new Node();
            nodeF.Value = "F"; nodeF.IsTraversed = false;
            // Создать ребра
            nodeA.Edges = new List<Edge> 
            { 
                new Edge(){Weight = 1, Node = nodeB},
                new Edge(){Weight = 2, Node = nodeC}
            };
            nodeB.Edges = new List<Edge>
            {
                new Edge(){Weight = 1, Node = nodeA},
                new Edge(){Weight = 9, Node = nodeC},
                new Edge(){Weight = 10, Node = nodeD}
            };
            nodeC.Edges = new List<Edge>
            {
                new Edge(){Weight = 2, Node = nodeA},
                new Edge(){Weight = 9, Node = nodeB},
                new Edge(){Weight = 8, Node = nodeD},
                new Edge(){Weight = 5, Node = nodeE}
            };
            nodeD.Edges = new List<Edge>
            {
                new Edge(){Weight = 10, Node = nodeB},
                new Edge(){Weight = 8, Node = nodeC},                
                new Edge(){Weight = 3, Node = nodeE},
                new Edge(){Weight = 1, Node = nodeF}
            };
            nodeE.Edges = new List<Edge>
            {                
                new Edge(){Weight = 5, Node = nodeC},
                new Edge(){Weight = 3, Node = nodeD}
            };
            nodeF.Edges = new List<Edge>
            {
                new Edge(){Weight = 1, Node = nodeD},
                new Edge(){Weight = 3, Node = nodeE}
            };
            // Обход графа в ширену
            Console.WriteLine($"Поиск узла со значением \"E\", В ширину");
            graphBuilder.BFSTravers(nodeA, "E");

            // обнулить все значения по обходу
            nodeA.IsTraversed = false;
            nodeB.IsTraversed = false;
            nodeC.IsTraversed = false;
            nodeD.IsTraversed = false;
            nodeE.IsTraversed = false;
            nodeF.IsTraversed = false;
            // Обход графа в глубину
            Console.WriteLine();
            Console.WriteLine($"Поиск узла со значением \"D\", В глубину");
            graphBuilder.DFSTravers(nodeA, "D");

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
