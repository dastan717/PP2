using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine()); // размер массива
            string[] nums = Console.ReadLine().Split(); // for taking numbers separate
            int[] a = new int[s]; // 1 ый массив 
            int[] b = new int[s]; // массив с готовым результатом
            int num = 0; // количество простых чисел 


            for (int i = 0; i < s; i++)
            {

                a[i] = int.Parse(nums[i]); // занести в массив чисел массив строк в котором введенные пользователем числа 
                bool isNotPrime = false; // bool переменная поначалу которой все прайм числа
                for (int j = 2; j <= Math.Sqrt(a[i]); j++) //идем до корня проверяемой цифры
                {
                    if (a[i] % j == 0)
                    {
                        isNotPrime = true;   // если поделилось на что то,  то это НЕ прайм
                        break;
                    }
                }
                if (!isNotPrime && a[i] != 1) // если это ПРАЙМ и не равно 1 
                {
                    num++; // увеличение кол-во прайм чисел
                    b[i] = a[i]; // кладем в массив с прайм числами
                }

            }
            Console.WriteLine(num); // выводим количество простых чисел
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != 0)
                    Console.Write(b[i] + " "); // выводим простые числа
            }

            Console.ReadKey();  // чтобы не закрылось сразу окно

        }
    }
}