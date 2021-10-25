using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    // Класс узел графа
    public class Node //Вершина
    {
        public bool IsTraversed { get; set; } // пройденый
        public string Value { get; set; }
        public List<Edge> Edges { get; set; } //исходящие связи
    }
}

