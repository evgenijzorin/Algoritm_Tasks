using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // массив значений для сбалансированного дерева
            int[] ValueArray = new int[] { 4, 5, 9, 98, 33, 23, 88, 73, 98, 66,89, 54};
            // Создание сбалансированного дерева:
            TreeBuilder.Node<int> root =  TreeBuilder.BalanceTree(ValueArray, ValueArray.Length,null);
            // Визуализация созданного дерева  
            TreeBuilder.PreOrderTravers(root);          
            Console.WriteLine(); Console.WriteLine();
            // Удаление узла дерева со значением 88:
            TreeBuilder.RemuveNode(root, 88);
            Console.WriteLine("Из дерева были удалены узлы со значением 88. Визуализация дерева после удаления:");
            TreeBuilder.PreOrderTravers(root);// Визуализация дерева
            Console.WriteLine(); Console.WriteLine();
            // Поиск узла с заданным значением
            int changedValue = 5;            
            TreeBuilder.Node<int> root1 = TreeBuilder.FindNode(root, changedValue);            
            // Добавление нового узла на место заданного с перемещением заданного угла в правую ветку
            int changedValue1 = 777;
            TreeBuilder.AddNodeRightShift(root1, changedValue1);
            Console.WriteLine($"В дерево добавили узел, вместо узла со значением \"{changedValue}\" узел со значением \"{changedValue1}\". В результате визуализация дерева:") ;
            TreeBuilder.PreOrderTravers(root);// Визуализация дерева
            Console.WriteLine();
        }
    }
}
