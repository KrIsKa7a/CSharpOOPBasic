using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] field;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            field = new char[n][];
            InitializeAndFillTheField(n);

            var moves = Console.ReadLine().ToCharArray();

            int[] samPosition = new int[2];
            FindSamPosition(samPosition);

            foreach (var move in moves)
            {
                MakeATurn(samPosition, move);
            }
        }

        private static void MakeATurn(int[] samPosition, char move)
        {
            MoveEnemies();

            int[] enemyCoordinates = new int[2];

            GetEnemyCoordinates(samPosition, enemyCoordinates);
            CheckIfSamIsKilled(samPosition, enemyCoordinates);

            MoveSam(samPosition, move);

            GetEnemyCoordinates(samPosition, enemyCoordinates);

            if (field[enemyCoordinates[0]][enemyCoordinates[1]] == 'N' && samPosition[0] == enemyCoordinates[0])
            {
                MarkNikolazdeAsKilled(enemyCoordinates);
            }
        }

        private static void MarkNikolazdeAsKilled(int[] enemyCoordinates)
        {
            field[enemyCoordinates[0]][enemyCoordinates[1]] = 'X';
            Console.WriteLine("Nikoladze killed!");
            PrintField();
            Environment.Exit(0);
        }

        private static void MoveSam(int[] samPosition, char move)
        {
            field[samPosition[0]][samPosition[1]] = '.';

            switch (move)
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
            field[samPosition[0]][samPosition[1]] = 'S';
        }

        private static void CheckIfSamIsKilled(int[] samPosition, int[] enemyCoordinates)
        {
            if (samPosition[1] < enemyCoordinates[1] && field[enemyCoordinates[0]][enemyCoordinates[1]] == 'd' && enemyCoordinates[0] == samPosition[0])
            {
                MarkSamAsDead(samPosition);
            }
            else if (enemyCoordinates[1] < samPosition[1] && field[enemyCoordinates[0]][enemyCoordinates[1]] == 'b' && enemyCoordinates[0] == samPosition[0])
            {
                MarkSamAsDead(samPosition);
            }
        }

        private static void MarkSamAsDead(int[] samPosition)
        {
            field[samPosition[0]][samPosition[1]] = 'X';
            PrintResult(samPosition);
            Environment.Exit(0);
        }

        private static void PrintResult(int[] samPosition)
        {
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            PrintField();
        }

        private static void PrintField()
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void GetEnemyCoordinates(int[] samPosition, int[] getEnemy)
        {
            for (int j = 0; j < field[samPosition[0]].Length; j++)
            {
                if (field[samPosition[0]][j] != '.' && field[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'b')
                    {
                        MoveRight(row, ref col);
                    }
                    else if (field[row][col] == 'd')
                    {
                        MoveLeft(row, col);
                    }
                }
            }
        }

        private static void MoveLeft(int row, int col)
        {
            if (row >= 0 && row < field.Length && col - 1 >= 0 && col - 1 < field[row].Length)
            {
                field[row][col] = '.';
                field[row][col - 1] = 'd';
            }
            else
            {
                field[row][col] = 'b';
            }
        }

        private static void MoveRight(int row, ref int col)
        {
            if (row >= 0 && row < field.Length && col + 1 >= 0 && col + 1 < field[row].Length)
            {
                field[row][col] = '.';
                field[row][col + 1] = 'b';
                col++;
            }
            else
            {
                field[row][col] = 'd';
            }
        }

        private static void FindSamPosition(int[] samPosition)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static void InitializeAndFillTheField(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var inputRow = Console.ReadLine().ToCharArray();
                field[row] = inputRow;
            }
        }
    }
}
