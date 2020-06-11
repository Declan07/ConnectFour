using System;

namespace ConnectFour
{
    class Game
    {
        Player[] players = new Player[2];
        Board board = new Board();

        public Game()
        {
            CreatePlayers();
            SetPlayerColors();

        }
        public void GameLoop()
        {
            bool gameRunning = true;
            int currentPlayer = 0;
            while (gameRunning)
            {
                Counter counter = new Counter(players[currentPlayer].getColor());
                int column = PlayerSelectAColumn(currentPlayer);
                int[] location = board.AddCounter(counter, column);
                board.Print();
                if (IsGameWon(board, location, counter.Symbol))
                {
                    Console.WriteLine($"Congratulations {players[currentPlayer].getName()} you win");
                    gameRunning = false;
                }

                currentPlayer = currentPlayer == 0 ? 1 : 0;
            }
        }

        private bool IsGameWon(Board board, int[] location, char playerSymbol)
        {
            if (board.isHorizontalWinCondition(location, playerSymbol))
            {
                return true;
            }
            else if (board.IsVerticalWinCondition(location, playerSymbol))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsGameDrawn(Board board)
        {
            //Assumes check for win condition has already been performed
            return board.IsBoardFull();
        }

        private int PlayerSelectAColumn(int currentPlayer)
        {
            int column = -1;
            bool columnValid = false;
            while (!columnValid)
            {
                Console.WriteLine($"Your turn {players[currentPlayer].getName()}, choose a column between 0 and 6");
                column = int.Parse(Console.ReadLine());
                if (column < 0 || column > 6)
                {
                    Console.WriteLine("Error. You need to enter an integer between 0 and 6");
                }
                else if (board.IsColumnFull(column))
                {
                    Console.WriteLine("This column is full, choose another column to place your counter");
                }
                else
                {
                    columnValid = true;
                }
            }
            return column;

        }


        private void CreatePlayers()
        {
            Console.WriteLine("Player 0 enter name: ");
            string p0Name = Console.ReadLine();
            players[0] = new Player(p0Name);
            Console.WriteLine("Player 1 enter name: ");
            string p1Name = Console.ReadLine();
            players[1] = new Player(p1Name);
        }

        private void SetPlayerColors()
        {
            string p0Color = "";
            while (p0Color != "red" && p0Color != "yellow")
            {
                Console.WriteLine($"{players[0].getName()} choose a color. Enter 'red' or 'yellow'");
                p0Color = Console.ReadLine().ToLower();
            }

            //Sets player 1 color opposite to player 0 color
            string p1Color = p0Color == "red" ? "yellow" : "red";
            Console.WriteLine($"{players[0].getName()} you will be {p1Color}");

            players[0].setColor(p0Color);
            players[1].setColor(p1Color);

        }
    }
}
