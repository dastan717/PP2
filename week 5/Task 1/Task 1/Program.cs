using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace Task_1
{

    public class Complex
    {
        public double a;
        public double b;
        public override string ToString()
        {
            return string.Format("{0}+{1}*i", a, b);
        }
        public void PrintInfo()
        {
            Console.WriteLine(string.Format("{0}+{1}*i", a, b));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F1();
            
            Complex complex = F2();
            complex.PrintInfo();
            Console.ReadKey();
                               }
                
        public static Complex F2()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            FileStream fs = new FileStream("AAA", FileMode.Open, FileAccess.Read);
            Complex complex = xs.Deserialize(fs) as Complex;

            fs.Close();
            complex.ToString();
            return complex;
        }
        public static void F1()
        {
            Complex number = new Complex();
            number.a = 4;
            number.b = 5;
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            FileStream fs = new FileStream("AAA", FileMode.Create, FileAccess.Write);

            xs.Serialize(fs, number);
            fs.Close();
        }
    }
}
