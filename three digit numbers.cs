// Вывести все трехзначные числа, в которых последующий разряд больше предыдущего

using System;

namespace Трёхзначные_1
{
    class threesymbols1
    {
        static void Main(string[] args)
        {
            int n1, n2, n3; //ввод переменных

            for(n1=1; n1<=7; n1++)
            {
                for(n2=n1+1; n2<=8; n2++)
                {
                    for(n3=n2+1; n3<=9; n3++)
                    {
                        Console.WriteLine("{0}{1}{2}", n1, n2, n3);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
