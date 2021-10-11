using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task_1 // Реализация двусвязного списка и его проверка
{
    // интерфейс последовательного списка
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        int Getindex(Node node); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    class MyLinkedList : ILinkedList
    {
        // голова списка
        private Node head;
        // класс конструктор
        public MyLinkedList(int rootValue)
        {
            head = new Node { Value = rootValue };
        }
        // метод создание узла
        public void AddNode(int value)
        {
            Node r = head; // голова для текущего узла
            // добавляем узлы 
            while (r.NextNode != null)
            {
                r = r.NextNode;
            }
            r.NextNode = new Node() { Value = value };
            r.NextNode.PrevNode = r;
        }

        /// <summary>
        /// добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node">Узел перед искомым</param>
        /// <param name="value">Значение которое нужно присвоить новому узлу </param>
        public void AddNodeAfter(Node node, int value)
        {
            // Новый узел: добавить ссылки
            Node nodeNew = new Node();
            nodeNew.Value = value;
            nodeNew.NextNode = node.NextNode;
            nodeNew.PrevNode = node.PrevNode;
            // Последующий узел: изменить ссылки
            node.NextNode.PrevNode = nodeNew;
            // родительский узел: изменить ссылки
            node.NextNode = nodeNew;
        }
        public Node FindNode(int searchValue)
        {
            Node r = head;
            while (r != null)
            {
                if (r.Value == searchValue)
                {
                    return r;
                }
                r = r.NextNode; // Переход к следующему узлу
            }
            return null;
        }
        /// <summary>
        /// Получить длину списка
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int count = 0;
            Node r = head;
            while (r != null)
            {
                count += 1;
                //count++;
                r = r.NextNode; // Переход к следующему узлу
            }
            return count;
        }
        /// <summary>
        /// удаляет узел по индексу
        /// </summary>
        /// <param name="index"> Индекс узла </param>
        public void RemoveNode(int index)
        {
            int count = 0;
            Node r = head;
            while (r != null)
            {
                count += 1;
                //count++;
                if (count == index)
                {
                    // Последующий узел: изменить ссылки
                    r.NextNode.PrevNode = r.PrevNode;
                    // родительский узел: изменить ссылки
                    r.PrevNode.NextNode = r.NextNode;
                    return;
                }
                r = r.NextNode; // Переход к следующему узлу
            }
        }
        /// <summary>
        /// Удаляет узел по объекту узла
        /// </summary>
        /// <param name="node"> объект узла класса Node, который удаляется из списка </param>
        public void RemoveNode(Node node)
        {
            Node r = head;
            while (r != null)
            {
                if (node == r)
                {
                    // Последующий узел: изменить ссылки
                    r.NextNode.PrevNode = r.PrevNode;
                    // родительский узел: изменить ссылки
                    r.PrevNode.NextNode = r.NextNode;
                    return;
                }
                r = r.NextNode; // Переход к следующему узлу
            }
        }
        public void PrintList()
        {
            Node r = head;
            string printRezult = "";
            while (r != null)
            {
                printRezult = printRezult + " " + r.Value;
                r = r.NextNode;
            }
            Console.WriteLine($"Визуализация связного списка: {printRezult}");
        }
        public int Getindex(Node node) // возвращает количество элементов в списке
        {
            Node r = head;
            int count = 0;
            while (r != null)
            {
                count++;
                if (node == r)
                {
                    return count;
                }
                r = r.NextNode; // Переход к следующему узлу
            }
            return -1;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создать связанный список со значением головного узла 100
            MyLinkedList ListOfNodes = new MyLinkedList(100);
            ListOfNodes.AddNode(13);
            ListOfNodes.AddNode(21);
            ListOfNodes.AddNode(8);
            ListOfNodes.AddNode(18);
            ListOfNodes.AddNode(4);
            ListOfNodes.AddNode(7);
            ListOfNodes.AddNode(81);
            ListOfNodes.AddNode(11);
            ListOfNodes.PrintList(); // Вывести список одной строкой
            Console.WriteLine($"Список размерностью {ListOfNodes.GetCount()} ");
            Console.WriteLine($"Узел с значением {81} находится на позиции {ListOfNodes.Getindex(ListOfNodes.FindNode(81))} в списке");
            // Добавление нового узла:
            ListOfNodes.AddNodeAfter(ListOfNodes.FindNode(4), 67);
            Console.WriteLine($"Добавим новый узел с значением 67, на позицию после узла со значением 4, после этого список изменился:");
            ListOfNodes.PrintList(); // Вывести список одной строкой                  
            // Удаление узла по индексу
            Console.WriteLine($"Удалить узел на 3-й позиции из списка применив метод удаления по индексу, после этого список изменился:");
            ListOfNodes.RemoveNode(3);
            ListOfNodes.PrintList(); // Вывести список одной строкой
            Console.WriteLine($"Удалить узел с значением 18, из списка применив метод удаления по ссылке на объект, после этого список изменился:");
            ListOfNodes.RemoveNode(ListOfNodes.FindNode(18));
            ListOfNodes.PrintList(); // Вывести список одной строкой
        }
    }
}