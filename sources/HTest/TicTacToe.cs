namespace HTest
{
    using System;

    /// <summary>
    /// Class has helper methods to find winners on tic-tac-toe board.
    /// </summary>
    /// <remarks>
    /// Tic-Tac-Toe rules http://boardgames.about.com/od/paperpencil/a/tic_tac_toe.htm.
    /// </remarks>
    public class TicTacToe
    {
        private readonly char[,] board;

        private readonly int winnerRowLength;

        /// <summary>
        /// Player X.
        /// </summary>
        public const char X = 'x';

        /// <summary>
        /// Player O.
        /// </summary>
        public const char O = 'o';

        /// <summary>
        /// Empty cell.
        /// </summary>
        public const char E = 'e';

        /// <summary>
        /// Initialize new instance of <see cref="TicTacToe"/> class.
        /// </summary>
        /// <param name="board">The playing board.</param>
        /// <param name="winnerRowLength">Winer row length.</param>
        /// <exception cref="ArgumentException">If <paramref name="winnerRowLength"/> less than 3.</exception>
        public TicTacToe(char[,] board, int winnerRowLength)
        {
            TicTacToe.ValidateBoard(board);

            if (winnerRowLength < 3)
            {
                throw new ArgumentException(Strings.ErrMsg_WinnerRowLengthMinimum);
            }

            if (winnerRowLength > board.GetLength(0))
            {
                throw new ArgumentException(Strings.ErrMsg_WinnerRowLengthShouldBeLessThanBoardSize);
            }

            this.board = board;
            this.winnerRowLength = winnerRowLength;
        }

        /// <summary>
        /// Initialize new instance of <see cref="TicTacToe"/> class, where winner's row should be the same size as a board.
        /// </summary>
        /// <param name="board">The playing board.</param>
        public TicTacToe(char[,] board)
        {
            TicTacToe.ValidateBoard(board);

            this.board = board;
            this.winnerRowLength = this.board.GetLength(0);
        }

        /// <summary>
        /// Find winner on tic-tac-toe board.
        /// </summary>
        /// <returns><value>null</value> if no winners or winner's char <see cref="X"/> or <see cref="O"/>.</returns>
        /// <remarks>
        /// This method does not validate board, so if it is contains two different winners - this method will return first winner it finds.
        /// </remarks>
        public char? FindWinner()
        {
            int length = this.board.GetLength(0);

            // Check winners on rows
            for (int row = 0; row < length; row++)
            {
                int winnerLength = 1;

                for (int column = 1; column < length; column++)
                {
                    if (this.board[row, column] != TicTacToe.E
                        && this.board[row, column] == this.board[row, column - 1])
                    {
                        winnerLength++;

                        if (winnerLength >= this.winnerRowLength)
                        {
                            return this.board[row, column];
                        }
                    }
                    else
                    {
                        winnerLength = 1;
                    }
                }
            }

            // Check winners on columns
            for (int column = 0; column < length; column++)
            {
                int winnerLength = 1;

                for (int row = 1; row < length; row++)
                {
                    if (this.board[row, column] != TicTacToe.E
                        && this.board[row, column] == this.board[row - 1, column])
                    {
                        winnerLength++;

                        if (winnerLength >= this.winnerRowLength)
                        {
                            return this.board[row, column];
                        }
                    }
                    else
                    {
                        winnerLength = 1;
                    }
                }
            }

            // Check winner on top-left to bottom-right diagonal rows
            for (int d = -(length - this.winnerRowLength); d <= (length - this.winnerRowLength); d++)
            {
                int winnerLength = 1;
                for (int row = 1 + Math.Max(-d, 0), column = 1 + Math.Max(d, 0);
                    row < length && column < length;
                    row++, column++)
                {
                    if (this.board[row, column] != TicTacToe.E 
                        && this.board[row - 1, column - 1] == this.board[row, column])
                    {
                        winnerLength++;

                        if (winnerLength >= this.winnerRowLength)
                        {
                            return this.board[row, column];
                        }
                    }
                    else
                    {
                        winnerLength = 1;
                    }
                }
            }

            // Check winner on top-right to bottom-left diagonal rows
            for (int d = -(length - this.winnerRowLength); d <= (length - this.winnerRowLength); d++)
            {
                int winnerLength = 1;
                for (int row = 1 + Math.Max(-d, 0), column = (length - 2 - Math.Max(d, 0)); row < length && column >= 0; row++, column--)
                {
                    if (this.board[row, column] != TicTacToe.E
                        && this.board[row - 1, column + 1] == this.board[row, column])
                    {
                        winnerLength++;

                        if (winnerLength >= this.winnerRowLength)
                        {
                            return this.board[row, column];
                        }
                    }
                    else
                    {
                        winnerLength = 1;
                    }
                }
            }

            return null;
        }

        private static void ValidateBoard(char[,] board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            if (board.GetLength(0) != board.GetLength(1))
            {
                throw new ArgumentException(Strings.ErrMsg_TicTacToeBoardShouldBeSquare, "board");
            }

            if (board.GetLength(0) < 3)
            {
                throw new ArgumentException(Strings.ErrMsg_BoardMinimumSize);
            }
        }
    }
}
