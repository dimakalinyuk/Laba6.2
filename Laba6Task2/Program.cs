using System;
using System.IO;

namespace Dima_OOP_6
{
    interface IMarsh
    {
        double Number();
        void Max();
        void Lenght();
    }

    public abstract class Marsh : IMarsh
    {
        public string number1;
        public int interval;
        abstract public double Number();
        abstract public void Max();
        abstract public void Lenght();

        public static void Add()
        {
            Console.WriteLine("Введiть данi");

            Console.Write("Прізвище: ");
            string str = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", str);

            Console.Write("Фах: ");
            string URL1 = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", URL1);

            Console.Write("День: ");
            string ddate = Console.ReadLine();

            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", ddate);

            Console.Write("Зміна: ");
            string host1 = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", host1);

            Console.Write("Кількість відвідувачів: ");
            string down1 = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", down1);

            Output.Write(Program.b);

            Input.Key();

        }

        public static void Remove()
        {
            Console.Write("Про кого видалити дані: ");

            string name = Console.ReadLine();

            bool[] write = new bool[Program.b.Length];

            for (int i = 0; i < Program.b.Length; ++i)
            {
                if (Program.b[i] != null)
                {
                    if (Program.b[i].name == name)
                    {
                        Console.WriteLine("{0,-20} {1, -20} {2, -20} {3, -20}", Program.b[i].number1, Program.b[i].interval, Program.b[i].name, Program.b[i].number);

                        Console.WriteLine("Видалити? (Y/N)\n");

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Y)
                        {

                            Program.b[i] = null;
                            Program.delete[i] = true;
                            Output.Write(Program.b);



                        }
                        else
                        {
                            Program.delete[i] = false;
                        }
                    }
                }
            }
        }

        public static void Edit()
        {
            Console.Write("Назва: ");

            string singer = Console.ReadLine();

            bool[] write = new bool[Program.b.Length];

            for (int i = 0; i < Program.b.Length; ++i)
            {
                if (Program.b[i] != null)
                {
                    if (Program.b[i].name == singer)
                    {
                        Console.WriteLine("{0,-20} {1, -20} {2, -20} {3, -20}", Program.b[i].number1, Program.b[i].interval, Program.b[i].name, Program.b[i].number);
                        Console.WriteLine("Введiть нову iнформацiю");

                        string str = Console.ReadLine();

                        string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        Program.b[i] = new Stop(elements[0], int.Parse(elements[1]), elements[2], int.Parse(elements[3]));
                    }
                }
            }
            Output.Write(Program.b);
        }





        private static void Save(Stop m)
        {
            StreamWriter save = new StreamWriter("text.txt", true);

            save.WriteLine(m.number1);
            save.WriteLine(m.interval);

            save.WriteLine(m.name);
            save.WriteLine(m.number);

            save.Close();
        }

        public static void Parse(string[] elements, bool save)
        {
            int counter = 0;

            while (Program.b[counter] != null)
            {
                ++counter;
            }

            for (int i = 0; i < elements.Length; i += 4)
            {
                Program.b[counter + i / 4] = new Stop(elements[i], int.Parse(elements[i + 1]), elements[i + 2], int.Parse(elements[i + 3]));

                if (save)
                {
                    Save(Program.b[counter + i / 4]);
                }
            }
        }
        public static string[] Read()
        {
            StreamReader fromFile = new StreamReader("text.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }


    }
    class Stop : Marsh
    {

        public string name;
        public int number;
        public Stop(string number1, int interval, string name, int number)
        {
            this.number1 = number1;
            this.interval = interval;

            this.name = name;
            this.number = number;
        }
        public override double Number()
        {
            double n = 0;
            for (int i = 0; i < Program.b.Length; i++)
            {
                if (Program.b[i] != null)
                {
                    n += Program.b[i].number;
                }
            }
            Console.WriteLine("Загальна кількість пасажирів: {0}", n);
            return n;
        }
        public override void Max()
        {
            int max = Program.b[0].number;
            int n = 0;
            for (int i = 0; i < Program.b.Length; i++)
            {
                if (Program.b[i] != null)
                {
                    if (Program.b[i].number < max)
                    {
                        max = Program.b[i].number;
                        n = i;
                    }
                }
            }
            Console.WriteLine("зупинки з найменшою кількістю пасажирів:");
            Console.WriteLine("{0,-20} {1, -20} {2, -20} {3, -20} ", Program.b[n].number1, Program.b[n].interval, Program.b[n].name, Program.b[n].number);

        }
        public override void Lenght()
        {
            int max = Program.b[0].name.Length;
            int index = 0;
            for (int i = 0; i < Program.b.Length; i++)
            {
                if (Program.b[i] != null)
                {
                    if (Program.b[i].name.Length > max)
                    {
                        max = Program.b[i].name.Length;
                        index = i;
                    }

                }


            }
            Console.WriteLine("найдовша назва: {0}", Program.b[index].name);
        }
    }

    class Output
    {
        public static void Write(Stop[] v)
        {
            Console.WriteLine("{0,-20} {1, -20} {2, -20} {3, -20} ", "Номер", "Інтервал хв", "Назва", "Кількість");

            for (int i = 0; i < v.Length; ++i)
            {
                if (v[i] != null)
                {

                    Console.WriteLine("{0,-20} {1, -20} {2, -20} {3, -20}", Program.b[i].number1, Program.b[i].interval, Program.b[i].name, Program.b[i].number);
                }
            }
        }
    }
    class Input
    {


        public static void Key()
        {
            Marsh.Parse(Read(), false);

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Загальна кількість пасажирів: K");
            Console.WriteLine("зупинки з найменшою кількістю пасажирів: F");
            Console.WriteLine("найдовшою назвою: S");
            Console.WriteLine("Виведення записiв: Enter");

            Console.WriteLine("Вихiд: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.OemPlus:
                    Console.WriteLine();
                    Marsh.Add();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine();
                    Marsh.Edit();
                    break;

                case ConsoleKey.OemMinus:
                    Console.WriteLine();
                    Marsh.Remove();
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine();
                    Output.Write(Program.b);
                    Key();
                    break;
                case ConsoleKey.F:
                    Console.WriteLine();
                    Program.b[0].Max();
                    break;
                case ConsoleKey.S:
                    Console.WriteLine();
                    Program.b[0].Lenght();
                    break;
                case ConsoleKey.K:
                    Console.WriteLine();
                    Program.b[0].Number();
                    break;



                case ConsoleKey.Escape:
                    return;
            }
        }
        public static string[] Read()
        {
            StreamReader fromFile = new StreamReader("text.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }
    }



    class Program
    {
        public static Stop[] b = new Stop[1000000];
        public static bool[] delete = new bool[1000000];
        static void Main(string[] args)
        {
            Input.Key();
        }
    }
}
