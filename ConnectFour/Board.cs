using System;

namespace ConnectFour
{
    class Board
    {
        private char[,] location;
        public const char empty = ' ';

        public Board()
        {
            location = new char[7, 6];
            Clear();
        }
        public int[] AddCounter(Counter counter, int column)
        {
            int row = FindFirstAvaibleRow(column);
            this.location[column, row] = counter.Symbol;
            int[] addedLocation = { column, row };
            return addedLocation;
        }

        private int FindFirstAvaibleRow(int column)
        {
            for (int y = 0; y < location.GetLength(1); y++)
            {
                if (location[column, y] == empty)
                {
                    return y;
                }
            }
            return -1;

        }

        public bool IsColumnFull(int column)
        {
            if (location[column, location.GetLength(1) - 1] != ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isHorizontalWinCondition(int[] counterLocation, char playerSymbol)
        {
            //Counts players counters in a row right of counter including placed counter
            int count = 0;
            for (int i = counterLocation[0]; i < location.GetLength(0); i++)
            {
                if (this.location[i, counterLocation[1]] == playerSymbol)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            //Counts players counter in row, left of counter

            for (int i = counterLocation[0]; i >= 0; i--)
            {
                if (this.location[i, counterLocation[1]] == playerSymbol)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            //removes double counting of placed counter
            count--;

            if (count >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVerticalWinCondition(int[] counterLocation, char playerSymbol)
        {
            int count = 0;
            for (int i = counterLocation[1]; i < location.GetLength(1); i++)
            {
                if (this.location[counterLocation[0], i] == playerSymbol)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }



            for (int i = counterLocation[1]; i >= 0; i--)
            {
                if (this.location[counterLocation[0], i] == playerSymbol)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            //removes double counting of placed counter
            count--;

            if (count >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsBoardFull()
        {
            for (int y = 0; y < location.GetLength(1); y++)
            {
                for (int x = 0; x < location.GetLength(0); x++)
                {
                    if (location[x, y] == empty)
                    {
                        return false;
                    }

                }
            }
            return true;

        }

        private void Clear()
        {
            for (int y = 0; y < location.GetLength(1); y++)
            {
                for (int x = 0; x < location.GetLength(0); x++)
                {
                    location[x, y] = empty;
                }
            }
        }

        public void Print()
        {
            for (int y = location.GetLength(1) - 1; y >= 0; y--)
            {
                Console.Write("|");
                for (int x = 0; x < location.GetLength(0); x++)
                {
                    Console.Write($"{location[x, y]}|");
                }
                Console.Write("\n");
            }
        }
    }
}
