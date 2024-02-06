using System;
using System.Collections.Generic;

namespace Kształty
{
    class Program
    {
        static void Main(string[] args)
        {
            RysujKształty();
            Console.ReadKey();
        }

        public static void RysujKształty()
        {
            Kształt kształt = null;
            List<Kształt> kształty = new List<Kształt>();

            do
            {
                Console.Clear();
                Console.WriteLine("[1] Trójkąt");
                Console.WriteLine("[2] Koło");
                Console.WriteLine("[3] Prostokąt");
                Console.WriteLine("[4] Wszystkie");

                ConsoleKey input = Console.ReadKey().Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        kształt = new Trójkąt();
                        break;
                    case ConsoleKey.D2:
                        kształt = new Koło();
                        break;
                    case ConsoleKey.D3:
                        kształt = new Prostokąt();
                        break;
                    case ConsoleKey.D4:
                        kształty.Add(new Trójkąt());
                        kształty.Add(new Koło());
                        kształty.Add(new Prostokąt());
                        break;
                }

                kształt?.Rysuj();
            }
            while (Console.ReadKey().Key != ConsoleKey.Spacebar);
        }
    }

    public class Kształt
    {
        public virtual void Rysuj()
        {
            var kształty = new List<Kształt>
            {
                new Prostokąt(),
                new Koło(),
                new Trójkąt()
            };

            foreach (Kształt kształt in kształty)
            {
                Console.WriteLine();

                kształt.Rysuj();
            }
        }
    }

    public class Trójkąt : Kształt
    {
        public override void Rysuj()
        {
            int n = 9;

            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                for (int x = i; x <= n; x++)
                {
                    Console.Write(" ");

                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("^" + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Prostokąt : Kształt
    {
        private int _szerokość;
        private int _wysokość;
        private int _położenieX;
        private int _położenieY;

        private ConsoleColor _kolorRamki;

        public Prostokąt()
        {
            _szerokość = 40;
            _wysokość = 10;
            _położenieX = 1;
            _położenieY = 5;
            _kolorRamki = ConsoleColor.Yellow;
        }

        public override void Rysuj()
        {
            Console.ForegroundColor = _kolorRamki;
            Console.CursorTop = _położenieY;
            Console.CursorLeft = _położenieX;

            string s = "╔";
            string spacja = new string(' ', _szerokość);
            string temp = new string(' ', _położenieX);

            for (int i = 0; i < _szerokość; i++)
            {
                s += "═";
            }

            s += "╗" + "\n";

            for (int i = 0; i < _wysokość; i++)
            {
                s += temp + "║" + spacja + "║" + "\n";
            }

            s += temp + "╚";

            for (int i = 0; i < _szerokość; i++)
            {
                s += "═";
            }

            s += "╝" + "\n";

            Console.Write(s);
            Console.ResetColor();
        }
    }

    public class Koło : Kształt
    {
        public override void Rysuj()
        {
            double radius;
            double thickness = 0.4;
            ConsoleColor borderColor = ConsoleColor.Red;
            Console.ForegroundColor = borderColor;
            char symbol = '*';

            radius = 15;

            Console.WriteLine();
            double rln = radius - thickness, rOut = radius + thickness;

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rln * rln && value <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
