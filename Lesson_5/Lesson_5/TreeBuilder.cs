﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class TreeBuilder
    {
        //public static int[] ValueArray = new int[] { 4, 4, 9, 98, 33, 23, 88, 73 };
        private int i = 0;

        // Класс узел дерева
        public class Node<T> // T - обобщенный тип данных узла (обобщения generics) 
        {
            public T Data { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            public Node<T> Parent { get; set; }
        }

        /// <summary>
        ///  BFS (breadth-first serche) Обход дерева в ширену созданного дерева
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        public Node<int> BFSTravers(Node<int> root, int value)
        {
            var queue = new Queue<Node<int>>();
            // Добавить элемент в очередь
            queue.Enqueue(root);// Добавление нового элемента в конец очереди.
            while (queue.Count != 0)// Если очередь пуста завершить работу
            {
                // Извлечь из очереди элемент
                var root1 = queue.Dequeue();
                if (root1.Data == value)
                    return root1;
                if (root1.Right != null)
                    queue.Enqueue(root1.Right);
                if (root1.Left != null)
                    queue.Enqueue(root1.Left);
            }
            return null;
        }

        /// <summary>
        /// Обход графа в глубину
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal Node<int> DFSTravers(Node<int> root, int value)
        {
            var stack = new Stack<Node<int>>();
            // Добавить элемент в стек
            stack.Push(root);// Добавление нового элемента в стек.

            while (stack.Count != 0)// Если стек пуст завершить работу
            {
                // Извлечь из стека элемент
                var root1 = stack.Pop();
                if (root1.Data == value)
                    return root1;
                if (root1.Right != null)
                    stack.Push(root1.Right);
                if (root1.Left != null)
                    stack.Push(root1.Left);
            }
            return null;
        }

        /// <summary>
        /// Удаление узлов с заданным значением
        /// </summary>
        /// <param name="root">корень дерева</param>
        /// <param name="value">Значение удаляемого узла</param>
        internal void RemuveNode(Node<int> root, int value)
        {
            if (root.Right != null || root.Left != null)
            {
                if (root.Left != null)
                {
                    if (root.Left.Data == value)
                    {
                        root.Left = null;
                    }
                    else
                        RemuveNode(root.Left, value);
                }
                if (root.Right != null)
                {
                    if (root.Right.Data == value)
                    {
                        root.Right = null;
                    }
                    else
                        RemuveNode(root.Right, value);
                }
            }
        }

        public void AddNodeRightShift(Node<int> root, int value)
        {
            Node<int> newRoot = new Node<int>();
            // Замена ссылки на новый узел в родительском узле
            if (root.Parent.Right == root)
                root.Parent.Right = newRoot;
            if (root.Parent.Left == root)
                root.Parent.Left = newRoot;
            // сдвиг заменяемого узла с последующим деревом в правую ветвь
            newRoot.Right = root;
            root.Parent = newRoot;
            // Присвоение узлу значения
            newRoot.Data = value;
        }


        /// <summary>
        /// Найти узел
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<int> FindNode(Node<int> root, int value)
        {
            Node<int> serchedNode = null;
            if (root.Right != null || root.Left != null)
            {
                if (root.Left != null && serchedNode == null)
                {
                    if (root.Left.Data == value)
                    {
                        serchedNode = root.Left;
                    }
                    else
                        serchedNode = FindNode(root.Left, value);
                }
                if (root.Right != null && serchedNode == null)
                {
                    if (root.Right.Data == value)
                    {
                        serchedNode = root.Right;
                    }
                    else
                        serchedNode = FindNode(root.Right, value);
                }
            }
            return serchedNode;
        }

        // Прямой обход дерева
        public void PreOrderTravers<T>(Node<T> root)
        {
            Console.Write($"{root.Data}");
            if (root.Right != null || root.Left != null)
            {
                Console.Write("(");
                if (root.Left != null) PreOrderTravers(root.Left);
                else Console.Write("nil");
                Console.Write(",");
                if (root.Right != null) PreOrderTravers(root.Right);
                else Console.Write("nil");
                Console.Write(")");
            }
        }

        // Обратный обход дерева
        public void PostOrderTravers<T>(Node<T> root, string p = "")
        {
            if (root != null)
            {
                PostOrderTravers(root.Left, p + "  ");
                PostOrderTravers(root.Right, p + "  ");
                Console.WriteLine($"{p}{root.Data}");
            }
        }
        // Построение идеально сбалансированного дерева с n узлами
        // со случайными значениями
        public Node<int> BalanceTree(int[] ValueArray, int n, Node<int> parantNode)
        {
            Node<int> newNode = null;
            if (n == 0)
                return null;
            else
            {
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new Node<int>();
                newNode.Data = ValueArray[i++];
                newNode.Left = BalanceTree(ValueArray, nl, newNode);
                newNode.Right = BalanceTree(ValueArray, nr, newNode);
                newNode.Parent = parantNode;

            }
            return newNode;
        }
    }
}
