using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_2
{
    class Program
    {
        static bool IsPrime(int x)
        {
            if (x == 1) return false;//если 1 то будет false
            if (x == 2) return true;//если 2 то это будет true

            bool easy = true;// в данный момент тру
            for(int i = 2; i < x; ++i)
            {
                if (x % i == 0)//если делителей не один , то easy false
                {
                    easy = false;
                    break;
                }
            }
            return easy;//если easy true то выводим его и в далнейшем записываем в res
}
 static bool IsPrimeString(string s)
        {
            return IsPrime(int.Parse(s));
            // после каждой строки разделенным пробелом , переводим в интежер и вызываем функию , чтобы проверить  является ли prime или нет
        }

        static void Main(string[] args)
        {
            List<string> res = new List<string>();//делаем инициализацию строк , в каждую строку этого списка будет записываться string [] line  
            FileStream fs = new FileStream(@"C:\Users\EVRIKA.Lenovo-PC.003\Desktop\pp2\week2\Task 2\Task 2\Write.txt", FileMode.Open, FileAccess.Read);
            //FileStream класс чтения и записи , открывать и закрывать файлы 
            StreamReader sr = new StreamReader(fs);//функция чтобы прочитать из файла, указываем путь
            string line = sr.ReadLine();//читаем и присваеваем в line 
            String[] nums = line.Split(' ');// Сплин функция пустая , потому что цифры разделены пробелами

            foreach (var x in nums)//пробегаемся , как в форике
            {
                if (IsPrimeString(x))//вызываем в функцию по отдельности из строки разделенную пробелом
                {
                    res.Add(x);//Присваеваем в res
                }

            }
            sr.Close();//чтобы закрыть
            fs.Close();

            FileSystem.fs2=FyleSystem(@"C:\Users\EVRIKA.Lenovo-PC.003\Desktop\pp2\week2\Task 2\Task 2\Write.txt");
            StreamWriter=
        }
    }
}
