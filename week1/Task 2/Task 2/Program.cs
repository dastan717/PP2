using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_ex2
{
    class Student //создаем  класс Студент
    {
        public string name;
        public string id;
        private int year = 2018;
        public Student(string n, string i) //создаем конструктор из двух параметров
        {
            name = n;
            id = i;
        }

        public void PrintInfo() //создаем функцию войд
        {
            year++;//+1
            Console.WriteLine(name + " " + id + " " + year);
        }

        class Program
        {
            static void Main(string[] args)
            {
                Student s = new Student("Nurbek", "18BD113333");
                Student s1 = new Student("Kanat", "18BD331111");
                Student s2 = new Student("Temirlan", "18BD001122");
                s.PrintInfo(); //вызываем функцию воид
                s1.PrintInfo();
                s2.PrintInfo();
                Console.ReadKey();
            }
        
        }
    }
}
