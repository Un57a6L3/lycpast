// Нахождение НОД (двумя методами) и НОК

using System;
namespace std
{
    class nodnok
    {
        static int EuklidMethodMinus(int a, int b)
        {
            int a1, b1;
            if (a > b) { a1 = a; b1 = b; }
            else { a1 = b; b1 = a; }
            while (a1 != b1)
            {
                if (a1 > b1) a1 -= b1;
                else b1 -= a1;
            }
            return a1;
        }
        static int EuklidMethodDivide(int a, int b)
        {
            int a1, b1;
            if (a > b) { a1 = a; b1 = b; }
            else { a1 = b; b1 = a; }
            while (a1 % b1 != 0 && b1 % a1 != 0)
            {
                if (a1 > b1) a1 %= b1;
                else b1 %= a1;
            }
            if (a1 > b1) return b1;
            else return a1;
        }
        static int LeastMulti(int a, int b, int nod)
        {
            return a * b / nod;
        }
        static void Main(string[] args)
        {
            int a = 0, b = 0, fn, nod = 0, nok;
            bool cont = true;
            while (cont == true)
            {
                Console.Write("\n1) НОК методом Евклида через разность");
                Console.Write("\n2) НОК методом Евклида через остаток от деления");
                Console.Write("\n3) НОД через НОК");
                Console.Write("\nВыберите функцию: ");
                fn = int.Parse(Console.ReadLine());
                switch (fn)
                {
                    case 1:
                        Console.Write("\nВведите a: ");
                        a = int.Parse(Console.ReadLine());
                        Console.Write("Введите b: ");
                        b = int.Parse(Console.ReadLine());
                        nod = EuklidMethodMinus(a, b);
                        Console.Write("\nНОД чисел {0} и {1} = {2}", a, b, nod);
                        Console.Write("\nПродолжить? Введите 1: ");
                        if (int.Parse(Console.ReadLine()) == 1) cont = true;
                        else cont = false;
                        break;
                    case 2:
                        Console.Write("\nВведите a: ");
                        a = int.Parse(Console.ReadLine());
                        Console.Write("Введите b: ");
                        b = int.Parse(Console.ReadLine());
                        nod = EuklidMethodDivide(a, b);
                        Console.Write("\nНОД чисел {0} и {1} = {2}", a, b, nod);
                        Console.Write("\nПродолжить? Введите 1: ");
                        if (int.Parse(Console.ReadLine()) == 1) cont = true;
                        else cont = false;
                        break;
                    case 3:
                        if (nod == 0)
                        {
                            Console.Write("\nСначала вычислите НОД функцией 1 или 2!\n");
                            cont = true;
                            Console.Write("\nПродолжить? Введите 1: ");
                            if (int.Parse(Console.ReadLine()) == 1) cont = true;
                            else cont = false;
                            break;
                        }
                        else
                        {
                            nok = LeastMulti(a, b, nod);
                            Console.Write("\nНОК чисел {0} и {1} равен {2}", a, b, nok);
                            Console.Write("\nПродолжить? Введите 1: ");
                            if (int.Parse(Console.ReadLine()) == 1) cont = true;
                            else cont = false;
                            break;
                        }
                }
            }
            Console.ReadKey();
        }
    }
}