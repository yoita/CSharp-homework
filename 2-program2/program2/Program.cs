using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] b = { 1, 2, 3, 4, 5, 6 };
            Console.Write("数组元素分别为：" );
            for (int n = 0; n < 6; n++)
            {
                Console.Write(b[n]);
            }
            Console.WriteLine();
            for (int i=0;i<5;i++)
            {
                if (b[i] < b[i + 1])
                    b[0] = b[i + 1];
            }
            Console.WriteLine("最大值为：" + b[0]);
            b[0] = 1;
            for (int j = 0; j < 5; j++)
            {
                if (b[j] > b[j + 1])
                    b[0] = b[j + 1];
            }
            Console.WriteLine("最小值为：" + b[0]);
            int sum = 0;
            for(int k=0;k<6;k++)
            {
              sum = sum + b[k];
            }
            Console.WriteLine("所有元素的和为：" + sum);
            double average = sum / 6.0;
            Console.WriteLine("平均值为：" + average);
        }
    }
}
