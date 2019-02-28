using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_3
{
    class Program
    {
        static void kaz(DirectoryInfo dir, int j)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;//закрашиваем текст который будет выводится в консоль
            string s = "";
            for(int i = 0; i < j; i++)
            {
                s += " ";//отправленное количесвто int равно пробелу , тоесть столько раз добавит пробел

            }
            Console.WriteLine(s + dir.Name);//выводим пробел,название, формат файла
            FileSystemInfo[] x = dir.GetFileSystemInfos();
            //Возвращает массив строго типизированных объектов FileSystemInfo, представляющих все файлы и подкаталоги в том или ином каталоге.
            //узнаем инфуо папке т.е. внутри папки заходим в папку и получаем инфу что внутри нее
           for(int i=0;i<x.Length;j++){
                if(x[i](GetType()==typeof(DirectoryInfo)))

           console.Write (x+5);
  





}
           Console.ReadKey();
        }
 
        static void Main(string[] args)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(@"C:\Users\EVRIKA.Lenovo-PC.003\Desktop\Proba");
            kaz(dirinfo, 0);// отправляем в функцию вместе с нулем(0)
        }
       
    }
} 
