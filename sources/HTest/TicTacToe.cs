namespace HTest
{
    using System;

    public static class TicTacToe
    {
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
        public const char Empty = 'e';

        /// <summary>
        /// Find winner on tic-tac-toe board.
        /// </summary>
        /// <param name="table">The tic-tac-toe board.</param>
        /// <returns><value>null</value> if no winners or winner's char <see cref="X"/> or <see cref="O"/>.</returns>
        public static char? FindWinner(char[,] table)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }

            if (table.Length != table.GetLength(1))
            {
                throw new ArgumentException(Strings.ErrMsg_TicTacToeBoardShouldBeSquare, "table");
            }

            return null;
        }
    }
}
