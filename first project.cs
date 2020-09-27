// Первый проект - написать консольный "архиватор" (по сути работа с побитовым представлением чисел, побитовые сдвиги, маски и прочее)

using System;
namespace std
{
    class proj1
    {
        static long Write(long rar) //функция 1 - запись
        {
            int i;
            bool wrtn = false;
            long zip = rar;
            Wrt: Console.Write("\n Записать в память число: ");
            long wrt = long.Parse(Console.ReadLine());
            if (wrt < 1 || wrt > 15) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n Допустимый диапазон - от 1 до 15! Повторите ввод!\n"); Console.ResetColor(); goto Wrt; }
            //теперь к делу
            for (i = 0; i <= 60; i += 4)
            {
                if ((zip & (15L << i)) == 0)
                {
                    zip = zip | (wrt << i);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n Готово!\n");
                    Console.ResetColor();
                    wrtn = true;
                    break;
                }
            }
            if (wrtn == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n Ошибка! Память заполнена!\n");
                Console.ResetColor();
            }
            return zip;
        }
        static void Read(long rar) //функция 2 - чтение
        {
            Rd: Console.Write("\n Прочитать ячейку: ");
            int n = int.Parse(Console.ReadLine());
            if (n < 0 || n > 15) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n Допустимый диапазон - от 0 до 15! Повторите ввод!\n"); Console.ResetColor(); goto Rd; }
            long zip = (rar >> (n * 4)) & 0x0FL;            
            if (zip == 0) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n Ячейка #{0} пуста!\n", n); }
            else { Console.ForegroundColor = ConsoleColor.Green; Console.Write("\n В ячейке #{0} записано число {1}\n", n, zip); }
            Console.ResetColor();
        }
        static long Clear(long rar) //функция 3 - удаление
        {
            Clr: Console.Write("\n Очистить ячейку: ");
            int n = int.Parse(Console.ReadLine());
            if (n < 0 || n > 15) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n Допустимый диапазон - от 0 до 15! Повторите ввод!\n"); Console.ResetColor(); goto Clr; }
            long zip = rar;
            zip = (long)(0xFFFFFFFFFFFFFFFF ^ (0xFul << (n * 4))) & zip;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n Готово!\n");
            Console.ResetColor();
            return zip;
        }
        static void Main(string[] args)
        {
            long rar = 0; //переменная-архив
            bool cont = true; int contH; //флаг продолжения цикла
            int opnum; //номер вызываемой функции
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n ***** Здравствуйте! Вас приветствует Archivator v2.0 by Арсений Антонов 9.3! *****\n");
            Console.ResetColor();
            while (cont == true) //сам цикл
            {
                Console.Write("\n Выберите операцию:\n 1) Занести число в память\n 2) Прочитать число с позиции\n 3) Очистить позицию");
                EnterNum:  Console.Write("\n Выполнить операцию: "); //тут заюзана метка, чтобы перевыбрать операцию без навороченных циклов
                opnum = int.Parse(Console.ReadLine());
                switch(opnum)
                {
                    case 1: rar = Write(rar); break;
                    case 2: Read(rar); break;
                    case 3: rar = Clear(rar); break;
                    default: Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n Вы неправильно ввели номер операции! Повторите ввод!\n"); Console.ResetColor(); goto EnterNum;
                }
                Console.Write("\n Введите 1, чтобы продолжить: ");
                contH = int.Parse(Console.ReadLine());
                cont = (contH == 1) ? true : false;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n Спасибо за использование данной программы!\n\n  * Разработчик: Arseny Antonov\n  * Все права защищены (нет)");
            Console.ReadKey();
        }
    }
}