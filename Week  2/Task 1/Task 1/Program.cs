using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();//читаем строку в консоли
            for (int i = 0; i < s.Length / 2; i++)//делим на 2 , потому что достаточно проверить половину
            {

                if (s[i] != s[s.Length - 1 - i])//сравниваем начало с концом 
                {
                    Console.Write("No");//если они не совпадают , то выводим no
                    return;
                }


            }
            Console.WriteLine("Yes");//если совпадет то , yes
            Console.ReadKey();//чтобы консоль сразу не закрылся
        }


    }
   
}
 