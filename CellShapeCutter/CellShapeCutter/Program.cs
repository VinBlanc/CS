using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellShapeCutter
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<string> { "a1", "a2", "a3", "a4", "a5", "a6" };
            var b = new List<string> { "b1", "b2", "b3", "b4", "b5", "b6" };
            //var c = new List<string> { "c1", "c2", "c3", "c4", "c5", "c6" };
            var alphabet = new List<List<string>>{ a, b};
            var cellList = Cutter.CutToCellShape(alphabet,2, 2);

            foreach(var list in cellList)
            {
                foreach (var e in list)
                {
                    Console.Write(e + ",");
                }
                Console.WriteLine();
            }
        }
    }
}
