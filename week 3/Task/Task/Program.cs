    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class FarManager
    {
        DirectoryInfo dir = null;
        public int cursor;
        public string path;
        public int size;
        FileSystemInfo f1 = null;
        public FarManager() // пустой конструктор
        {

        }
        public FarManager(string path) // Конструктор, который получает путь и записывает его в исходный путь
        {
            this.path = path;
            cursor = 0;
        }
        public void Color(FileSystemInfo f, int index) // метод для того чтобы красить
        {
            if (cursor == index) // Условие, которое работает, если Курсор равен индексу массива
            {
                Console.BackgroundColor = ConsoleColor.Red ;
                Console.ForegroundColor = ConsoleColor.Black;
                f1 = f; // приравниваем 
            }
            else if (f.GetType() == typeof(DirectoryInfo)) // Условие, которое рисует консоль и имя, если это папка
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else// В противном случае, если это файл
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
        public void Show() //Метод Show для представления всего в мой каталог
        {

            dir = new DirectoryInfo(path); // присвоить значение к Dir
            FileSystemInfo[] FSI = dir.GetFileSystemInfos(); // Получить всю информацию о файлах и записать в массив
            Console.BackgroundColor = ConsoleColor.Black; // Раскрасить консоль в белый цвет каждый раз
            Console.Clear();
            for (int k = 0, j = 0; k < FSI.Length; k++) // цикл для показа всего
            {
                if (FSI[k].Name[0] == '.') // если начало равна . то пропустить
                    continue;
                Color(FSI[k], j); // вызвать функцию 
                Console.WriteLine(j + 1 + ". " + FSI[k].Name); // Показать индекс файла и его имя
                j++;
            }

        }
        public void CalSize() //Метод расчета размера массива без скрытых файлов
        {
            DirectoryInfo d = new DirectoryInfo(path); // приравниваем
            FileSystemInfo[] fi = d.GetFileSystemInfos(); //Создать массив и записать массив всех файлов из каталога
            size = fi.Length; // размер = количество всех элементов в массиве
            for (int k = 0; k < fi.Length; k++) // Цикл для пересчета размера массива
            {
                if (fi[k].Name[0] == '.') // если равна к точке ,то size -1
                    size--;
            }
        }
        public void Down() // метод вниз
        {
            cursor++;
            if (cursor == size) //если курсор равен последнему элементу массива после клика, то перейти в начало
                cursor = 0;
        }
        public void Up()
        {
            cursor--;
            if (cursor < 0) // Если курсор равен меньше 0, мы идем в конец массива
                cursor = size - 1;
        }
        public void Start() // Основная фунцкия
        {

            ConsoleKeyInfo Cons;
            bool Ok = true; // bool фунцкия Ок чтобы использовать для входа 
            while (Ok == true) //цикл работает до тех пор пока, Ок не станет Тру
            {
                CalSize(); //Рассчитать размер массива без скрытых файлов
                Show(); // Показать все элементы в массив, используя метод Show
                Cons = Console.ReadKey(); //нажмите на кнопку чтобы сделать что то
                if (Cons.Key == ConsoleKey.DownArrow) // если кнопка равна downArrow , вызывается Down
                {
                    Down();
                }
                else if (Cons.Key == ConsoleKey.Spacebar) // выйти если ,кнопка равна Spacebar
                {
                    Ok = false;
                }
                else if (Cons.Key == ConsoleKey.UpArrow) // если кнопка равна UParrow , то up
                {
                    Up();
                }
                else if (Cons.Key == ConsoleKey.Enter) // если кнопка равна Enter то открыть
                {
                    if (f1.GetType() == typeof(DirectoryInfo)) // проверка на тип
                    {
                        cursor = 0;
                        path = f1.FullName; // путь равен полному пути этой папки
                    }
                    else
                    {
                        StreamReader SR = new StreamReader(f1.FullName);
                        Console.WriteLine(SR.ReadToEnd());// показать все в файл 
                        SR.Close(); // закрываем
                        Console.ReadKey();
                        Console.Clear();

                    }
                }
                else if (Cons.Key == ConsoleKey.Escape) // если кнопка равный Escape мы возвращаемся в один шаг назад
                {
                    if (dir.Parent.FullName != @"C:\") //  мы можем вернуться назад перед диском
                    {
                        path = dir.Parent.FullName; // обновить наш путь
                        cursor = 0;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You Can't go out from the disk"); // если мы переходим к последней папке после нажатия кнопки Escape показать, что мы не можем вернуться к следующему
                        Console.ReadKey();
                    }
                }
                else if (Cons.Key == ConsoleKey.Backspace) // если кнопка равна  Backspace, то удалить папку(директорию)                
                {
                    if (f1.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        Directory.Delete(f1.FullName);
                    }
                    else
                    {
                        cursor = 0;
                        File.Delete(f1.FullName);
                    }
                }
                else if (Cons.Key == ConsoleKey.Tab) // если buttom равно Tab переименовать файл или папку
                {
                    Console.Clear();
                    string name = Console.ReadLine(); // запись нового имени файла или папки
                    Console.Clear();
                    string copPath = Path.Combine(dir.FullName, name); // создать новый путь, используя новое имя
                    if (f1.GetType() == typeof(DirectoryInfo))
                    {
                        Directory.Move(f1.FullName, copPath);
                    }
                    else
                    {
                        File.Move(f1.FullName, copPath);
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\EVRIKA.Lenovo-PC.003\Desktop\Proba"; // путь к моему каталогу
            FarManager FM = new FarManager(path);
            FM.Start(); // вызов функции start
        }
    }
}