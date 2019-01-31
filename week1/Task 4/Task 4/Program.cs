using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
           string[,] array = new string[a, a];//создаем двойной массив
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if (i >= j)//Сравниваем индексы
                    {
                      array[i,j]="[*]";//занесение в массив
                    }

                }
    

            }

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    
                       Console.Write( array[i, j] );//оутпут
                    

                }
                Console.WriteLine("");//Чтобы ряды звезды писались отдельно

            }

            Console.ReadKey();//Чтобы окно сразу не закрылось
        }
    }
}

