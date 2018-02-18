using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = InitializeAndFillMatrix(dimestions);

            long sum = 0;

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                DoTurn(matrix, ref sum, ref command);
            }

            Console.WriteLine(sum);
        }

        private static void DoTurn(int[,] matrix, ref long sum, ref string command)
        {
            int[] ivoCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] evilCoordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            MoveEvilAndDestroyStars(matrix, evilCoordinates);
            MoveIvoAndCollectStars(matrix, ref sum, ivoCoordinates);

            command = Console.ReadLine();
        }

        private static void MoveIvoAndCollectStars(int[,] matrix, ref long sum, int[] ivoCoordinates)
        {
            int ivoX = ivoCoordinates[0];
            int ivoY = ivoCoordinates[1];

            while (ivoX >= 0 && ivoY < matrix.GetLength(1))
            {
                if (ivoX >= 0 && ivoX < matrix.GetLength(0) && ivoY >= 0 && ivoY < matrix.GetLength(1))
                {
                    sum += matrix[ivoX, ivoY];
                }

                ivoY++;
                ivoX--;
            }
        }

        private static void MoveEvilAndDestroyStars(int[,] matrix, int[] evilCoordinates)
        {
            int evilX = evilCoordinates[0];
            int evilY = evilCoordinates[1];

            while (evilX >= 0 && evilY >= 0)
            {
                if (evilX >= 0 && evilX < matrix.GetLength(0) && evilY >= 0 && evilY < matrix.GetLength(1))
                {
                    matrix[evilX, evilY] = 0;
                }

                evilX--;
                evilY--;
            }
        }

        private static int[,] InitializeAndFillMatrix(int[] dimestions)
        {
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int valueCounter = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = valueCounter++;
                }
            }

            return matrix;
        }
    }
}
