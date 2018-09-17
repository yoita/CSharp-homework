using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = {1,3,4,6 };
            Console.WriteLine("用户指定数字为：");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(a[i]+" ");
            }
            Console.WriteLine("素数有");
            for (int j = 0; j < 4; j++)
            {
                if (a[j] % 2 != 0)
                    Console.WriteLine(a[j]);
            }
        }
    }
}
