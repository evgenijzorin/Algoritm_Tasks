using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    class GraphBuilder
    {


        /// <summary>
        /// BFS (breadth-first serche) Обход графа в ширину 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node BFSTravers(Node root, string value)
        {
            List<Edge> listEdges = new List<Edge>();
            var queue = new Queue<Node>();
            // Добавить элемент в очередь
            queue.Enqueue(root);// Добавление нового элемента в конец очереди.
            while (queue.Count != 0)// Если очередь пуста завершить работу
            {
                // Извлечь из очереди элемент
                var root1 = queue.Dequeue();
                // Пометить, что элемент пройден
                root1.IsTraversed = true;
                
                if (root1.Value == value)
                {
                    Console.Write($"{root1.Value} - Найден искомый элемент.");
                    return root1;
                }   
                else
                    Console.WriteLine($"{root1.Value}, ");
                // Поместить в очередь дочерние элементы
                listEdges = root1.Edges;
                for (int i = 0; i < listEdges.Count; i++)
                {
                    if(listEdges[i].Node.IsTraversed!=true)
                    {
                        queue.Enqueue(listEdges[i].Node);
                    }
                }
            }            
            return null;
        }

        /// <summary>
        /// DFS (depth-first serche) Обход графа в глубину
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal Node DFSTravers(Node root, string value)
        {
            List<Edge> listEdges = new List<Edge>();
            var stack = new Stack<Node>();
            // Добавить элемент в стек
            stack.Push(root);// Добавление нового элемента в стек.

            while (stack.Count != 0)// Если стек пуст завершить работу
            {
                // Извлечь из стека элемент
                var root1 = stack.Pop();
                // Пометить, что элемент пройден
                root1.IsTraversed = true;
                if (root1.Value == value)
                {
                    Console.Write($"{root1.Value} - Найден искомый элемент.");
                    return root1;
                }
                else
                    Console.WriteLine($"{root1.Value}, ");

                // Поместить в стек дочерние элементы
                listEdges = root1.Edges;
                for (int i = 0; i < listEdges.Count; i++)
                {
                    if (listEdges[i].Node.IsTraversed != true)
                    {
                        stack.Push(listEdges[i].Node);
                    }
                }
            }
            return null;
        }
    }
}
