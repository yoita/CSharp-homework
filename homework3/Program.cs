using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tria = new Triangle(3.0,4.0,5.0);
            Circle cir = new Circle(2);
            square squ = new square(2);
            rectangle rec = new rectangle(2, 4);
        }
        public class Triangle
        {
            public Triangle(double v1, double v2, double v3)
            {
                ValueOne = v1;
                ValueTwo = v2;
                ValueThree = v3;
                double p = (ValueOne + ValueTwo + ValueThree) / 2;
                double s= Math.Sqrt(p * (p - ValueOne) * (p - ValueTwo) * (p - ValueThree));
                Console.WriteLine("三角形的面积是：" + s);
            }
            public double ValueOne { get; private set; }//声明了一个公有属性，返回double
            public double ValueTwo { get; private set; }
            public double ValueThree { get; private set; }
        }
        public class Circle
        {
            public Circle(double r)
            {
                ValueOne = r;
                double pai = 3.1415926;
                double s = pai * r * r;
                Console.WriteLine("圆的面积是：" + s);
            }
            public double ValueOne { get; private set; }
        }
        public class square
        {
            public square(double a)
            {
                ValueOne = a;
                double s = a*a;
                Console.WriteLine("正方形的面积是：" + s);
            }
            public double ValueOne { get; private set; }
        }
        public class rectangle
        {
            public rectangle(double a, double b)
            {
                ValueOne = a;
                ValueTwo = b;
                double s = a*b;
                Console.WriteLine("长方形的面积是：" + s);
            }
            public double ValueOne { get; private set; }
            public double ValueTwo { get; private set; }
        }
    }
}
