// второй проект, надо сделать в консоли тип игру в домино
// я его так и не сдал, там какой-то баг, который я не нашел ахаха

using System;
using static System.Console;
namespace Project
{
    class Domino
    {
        // Две стороны костяшки
        private int side1;
        private int side2;

        // Коструктор с параметрами
        // Будет использоваться при создании массива костяшек
        public Domino(int side1, int side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }

        // Статический метод для создания массива костяшек
        // (Уже перемешанного)
        public static Domino[] Pack(int M)
        {
            int temp = 0, rndmax, ind = 0;
            for (int i = M + 1; i > 0; i--)
                temp += i;
            Domino[] Pack = new Domino[temp];
            for (int i = 0; i < temp; i++)
                Pack[i] = null;
            rndmax = temp;
            for (int i = 0; i <= M; i++)
                for (int j = i; j <= M; j++)
                {
                    temp = Program.rnd.Next(0, rndmax--);
                    ind = temp;
                    for (int k = 0; k <= temp; k++)
                    {
                        if (Pack[k] != null) ind++;
                    }
                    Pack[ind] = new Domino(i, j);
                }
            return Pack;
        }

        // Свойства
        public int Side1
        {
            get
            {
                return side1;
            }
        }
        public int Side2
        {
            get
            {
                return side2;
            }
        }
    }
    class Player
    {
        // Имя игрока
        private string name;

        // "Рука" игрока (т.е. его костяшки)
        Domino[] Deck;

        // Коструктор
        public Player(string name, Domino[] Deck)
        {
            this.name = name;
            this.Deck = Deck;
        }

        // Автоматический ход
        public int Autoturn(int Edge)
        {
            for (int i = 0; i < Deck.Length; i++)
            {
                if (Deck[i] == null) return -1;
                if (Deck[i].Side1 == Edge)
                {
                    WriteLine("{0} кладет костяшку [{1}|{2}]", name, Deck[i].Side1, Deck[i].Side2);
                    Edge = Deck[i].Side2;
                    Remove(i);
                    return Edge;
                }
                if (Deck[i].Side2 == Edge)
                {
                    WriteLine("{0} кладет костяшку [{1}|{2}]", name, Deck[i].Side2, Deck[i].Side1);
                    Edge = Deck[i].Side1;
                    Remove(i);
                    return Edge;
                }              
            }
            return -1;
        }

        // Удаление костяшки из руки
        public void Remove(int Index)
        {
            Domino[] temp = new Domino[Deck.Length - 1];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i < Index) temp[i] = Deck[i];
                else temp[i] = Deck[i + 1];
            }
            Deck = temp;
        }

        // Свойство
        public string Name
        {
            get
            {
                return name;
            }
        }
    }
    class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            // Чтобы игроки получили поровну костяшек домино,
            // Их должно быть четное кол-во, а оно равно
            // Сумме всех натуральных чисел до M+1
            int M = 0, temp = 1, count = 0;
            string Name;
            bool GameOver = false;
            while (temp % 2 != 0)
            {
                temp = 0;
                Write("Введите M: ");
                M = int.Parse(ReadLine());
                for (int i = M + 1; i > 0; i--)
                    temp += i;
            }
            Domino[] Deck = Domino.Pack(M);
            temp = Deck.Length / 2;
            Domino[] deck = new Domino[temp];
            for (int i = 0; i < temp; i++)
                deck[i] = Deck[i];
            Write("Введите ваше имя: ");
            Name = ReadLine();
            Player You = new Player(Name, deck);
            for (int i = 0; i < temp; i++)
                deck[i] = Deck[i + temp];
            Player PC = new Player("Компьютер", deck);

            // Игра начинается
            WriteLine("Игра началась!");
            temp = rnd.Next(0, M + 1);

            while (!GameOver)
            {
                if (count % 2 == 0)
                    temp = You.Autoturn(temp);
                else
                    temp = PC.Autoturn(temp);
                if (temp == -1)
                {
                    GameOver = true;
                    if (count % 2 == 0) WriteLine("Победил {0}", PC.Name);
                    else WriteLine("Победил {0}", You.Name);
                }                    
                else
                    count++;
            }
            WriteLine("Игра завершилась после {0} ходов", count);
            ReadKey();  
        }
    }
}
