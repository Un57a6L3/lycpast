// какая-то практика со строками

using System;
namespace std
{
    class Program
    {
        static int Sum(string x1, string x2, string oprt)
        {
            int res;
            switch(oprt)
            {
                case "+":
                    res = int.Parse(x1) + int.Parse(x2);
                    break;
                case "-":
                    res = int.Parse(x1) - int.Parse(x2);
                    break;
                default:
                    return -1;
            }
            return res;
        }
        static string ShortestSubstring(string str)
        {
            int slen, i;
            string temp;
            bool flag = true;
            for(slen = 1; slen <= str.Length; slen++)
            {
                i = 1;
                temp = str.Substring(0, slen);
                while (str.Length - slen * i > slen)
                {
                    if (str.Substring(slen * i, slen) != temp) { flag = false; break; }
                    else { i++; flag = true; }
                }
                if (str.Length % slen != 0 && flag == true)
                    if (str.Substring(str.Length - slen * i) == temp.Remove(str.Length - slen * i)) return temp;
                if (str.Length % slen == 0 && flag == true) return temp;
            }
            return str;
        }
        static void Main(string[] args)
        {
            Console.Write("Which function to operate? ");
            int sw = int.Parse(Console.ReadLine());
            switch(sw)
            {
                case 1:
                    Console.Write("Enter 2 numbers and + or -\n");
                    string x1 = Console.ReadLine();
                    string x2 = Console.ReadLine();
                    string oprt = Console.ReadLine();
                    int res = Sum(x1, x2, oprt);
                    Console.Write("Result: {0}", res);
                    break;
                case 2:
                    string S, str;
                    str = Console.ReadLine();
                    S = ShortestSubstring(str);
                    Console.Write("Result: {0}", S);
                    break;
                default:
                    Console.Write("Error: no function with such number found");
                    break;
            }
            Console.ReadKey();
        }
    }
}
