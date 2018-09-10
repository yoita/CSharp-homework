using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program1
{
    public static void Main(string[] args)
    {
        Console.WriteLine("请输入第一个数：");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("请输入第二个数：");
        int b = int.Parse(Console.ReadLine()); 
        int sum = a * b;
        Console.WriteLine("两个数的积为：" + sum);
        Console.ReadKey();
    }
 }