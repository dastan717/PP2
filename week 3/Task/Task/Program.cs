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
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else// В противном случае, если это файл
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
        public void Show() //Метод Show для представления всего в мой каталог
        {

            dir = new DirectoryInfo(path); // присвоить значение к Dir
            FileSystemInfo[] FSI = dir.GetFileSystemInfos(); // Get all the Info about files and write into array
            Console.BackgroundColor = ConsoleColor.White; // Paint the Console intp White color every time
            Console.Clear();
            for (int k = 0, j = 0; k < FSI.Length; k++) // Cycle for showing everything
            {
                if (FSI[k].Name[0] == '.') // если начало равна . то пропустить
                    continue;
                Color(FSI[k], j); // Call the function to Paint all interface
                Console.WriteLine(j + 1 + ". " + FSI[k].Name); // Show the index of the File and its name
                j++;
            }

        }
        public void CalSize() // Method fo calculating size of the array without Hidden files
        {
            DirectoryInfo d = new DirectoryInfo(path); // Create the Direcotory With and send the path
            FileSystemInfo[] fi = d.GetFileSystemInfos(); // Create The array and Write the array of all the files from Directory
            size = fi.Length; // size = The number of all elements into array
            for (int k = 0; k < fi.Length; k++) // Cycle for recalculating the size of the array 
            {
                if (fi[k].Name[0] == '.') // если равна к точке ,то size -1
                    size--;
            }
        }
        public void Down() // The method for go down
        {
            cursor++;
            if (cursor == size) // if the Cursor is equal the last element of the array after Click go to the beginning
                cursor = 0;
        }
        public void Up()
        {
            cursor--;
            if (cursor < 0) // If the cursor is equal less then 0-th we go the end of the array
                cursor = size - 1;
        }
        public void Start() //The main function
        {

            ConsoleKeyInfo Cons;
            bool Ok = true; // Bool function Ok to use for going out
            while (Ok == true) //Cycle works until Ok is true
            {
                CalSize(); // Calculate the size of the array without Hidden files
                Show(); // Show all the Elements into array using method Show
                Cons = Console.ReadKey(); //Click the buttom to do something
                if (Cons.Key == ConsoleKey.DownArrow) // if the buttom is DownArrow call the method DOwn
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