using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Task_2
{
    
        public class Mark
        {
            public int a;
            public Mark()
            {

            }
            public Mark(int a)
            {
                this.a = a;

            }
            public string GetLetter(int a)
            {
                string f = "Retake";
                if (a <= 49)
                    f = "F";
                if (a >= 50 && a < 54)
                    f = "D";
                if (a >= 55 && a < 59)
                    f = "D+";
                if (a >= 60 && a < 64)
                    f = "C-";
                if (a >= 65 && a < 69)
                    f = "C";
                if (a >= 70 && a < 74)
                    f = "C+";
                if (a >= 75 && a < 79)
                    f = "B-";
                if (a >= 80 && a < 84)
                    f = "B";
                if (a >= 85 && a < 89)
                    f = "B+";
                if (a >= 90 && a < 94)
                    f = "A-";
                if (a >= 95 && a < 100)
                    f = "A";
                if (a > 100) 
                    f= "Sorry.You are very clever and we don't have mark for you";

                return f;
            }
            public override string ToString()
            {
                return a+"="+ GetLetter(a);
            }
        }

        class Program
        {
            static void Main(string[] args)
        {
            Mark mark = new Mark(45);
            Mark mark1 = new Mark(50);
            Mark mark2 = new Mark(60);
            Mark mark3 = new Mark(75);
            Mark mark4 = new Mark(85);
            Mark mark5 = new Mark(95);
            Mark mark6 = new Mark(105);

            List<Mark> marks = new List<Mark>();
            marks.Add(mark);
            marks.Add(mark1);
            marks.Add(mark2);
            marks.Add(mark3);
            marks.Add(mark4);
            marks.Add(mark5);
            marks.Add(mark6);

            F1(marks);

            Console.WriteLine("Array1:");

            foreach (Mark m in marks)
            {
                Console.WriteLine(m);
            }
            List<Mark> marks2 = F2();
            Console.WriteLine("\nArray2: ");

            foreach (Mark m in marks2)
            {
                Console.WriteLine(m);
            }
            Console.ReadKey();
        }

        public static List<Mark> F2()
        {
            FileStream fs = new FileStream("Mymarks.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            List<Mark> marks = xs.Deserialize(fs) as List<Mark>;
            return marks;
        }

        public static void F1(List<Mark>marks)
            {
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            FileStream fs = new FileStream("Mymarks.xml", FileMode.Create, FileAccess.Write);


            xs.Serialize(fs, marks);

            fs.Close();

        }

    }

}

