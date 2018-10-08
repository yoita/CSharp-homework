using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_program2
{
    class Program
    {

        private static void Main(string[] args)
        {
           Console.WriteLine("Number1:" + new RandomNumber().GetRandom1());
        }

        public class RandomNumber //生成订单号
        {
            public static object _lock = new object();
            public static int count = 1;

            public string GetRandom1()
            {
                lock (_lock)
                {
                    if (count >= 10000)
                    {
                        count = 1;
                    }
                    var number = "P" + DateTime.Now.ToString("yyMMddHHmmss") + count.ToString("0000");
                    count++;
                    return number;
                }
            }
        }
        

    }
}
