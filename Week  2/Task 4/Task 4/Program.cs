using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fox = "fox say";//создаем стринг

            string st2 = @"C:\Users\EVRIKA.Lenovo-PC.003\Desktop\pp2\week2\Task 4\Task 4\1.txt";//указываем путь
            StreamWriter file = new StreamWriter(@"C:\Users\EVRIKA.Lenovo-PC.003\Desktop\pp2\week2\Task 4\Task 4\2.txt");
                file.Write(fox);//записываем в фокс
            file.Close();
            string st = @"C:\Users\EVRIKA.Lenovo-PC.003\Desktop\pp2\week2\Task 4\Task 4\2.txt";
            if (File.Exists(st2))
            //Проверяем есть ли существующий файл , типо , Метод Move нельзя использовать для перезаписи существующего файла.
            //File.Exists - определяет существует ли файл
            {
                File.Delete(st2);//если есть, то удаляем 
                File.Move(st, st2);// после , данные с st перемещяем в st2
                //Move- перемещяет данные
            }
        }
    }
}
