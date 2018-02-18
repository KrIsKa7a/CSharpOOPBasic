using System;
using System.Text;

namespace _01.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                PrintRow(i,n);
            }

            for (int i = n; i > 0; i--)
            {
                PrintRow(i, n);
            }
        }

        private static void PrintRow(int i, int n)
        {
            var row = new StringBuilder();

            row.Append(new string(' ', n - i));
            for (int j = 0; j < i; j++)
            {
                row.Append("* ");
            }
            Console.WriteLine(row.ToString().TrimEnd());
        }
    }
}
