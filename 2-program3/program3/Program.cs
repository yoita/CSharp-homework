using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2~100内素数有：");
            Console.Write("2，3，5，7，");
            for (int j = 2; j < 101; j++)
            {
                if (j % 2 != 0)
                {
                    if (j % 3 != 0)
                    {
                        if (j % 5 != 0)
                        {
                            if (j % 7 != 0)
                            {
                                Console.Write(j + "，");
                            }
                        }
                    }
                }
            }
        }
    }
}
