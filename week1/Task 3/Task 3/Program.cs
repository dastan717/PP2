using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();  //считываем первую строку
            string line2 = Console.ReadLine();   //вторую строку

            int n = int.Parse(line1); //преоброзуем из стринга в интеджер 
            string[] numsStr = line2.Split(); //создаем новый массив без пробелов

            for (int i = 0; i < numsStr.Length; ++i)
            {
                int x = int.Parse(numsStr[i]); //кол-во чисел в массиве
                for (int j = 0; j < 2; ++j) //каждое число  по 2 раза
                {
                    Console.Write(x + " "); // выводим через пробелы 
                }
                
            }Console.ReadKey();
        }
    }
}