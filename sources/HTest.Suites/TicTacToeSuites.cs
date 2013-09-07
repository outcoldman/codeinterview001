namespace HTest.Suites
{
    using System;

    using NUnit.Framework;

    public class TicTacToeSuites
    {
        [Test]
        public void FindWinner_NullBoard_ThrowsException()
        {
            // Arrange
            char[,] board = null;

            // Act
            TestDelegate act = () => TicTacToe.FindWinner(board);

            // Assert
            Assert.Throws<ArgumentNullException>(act, "FindWinner should throw exception when board is null.");
        }

        [Test]
        public void FindWinner_BoardIsNotSquare_ThrowsException()
        {
            // Arrange
            char[,] board = new char[,] { { TicTacToe.O }, { TicTacToe.X } };

            // Act
            TestDelegate act = () => TicTacToe.FindWinner(board);

            // Assert
            Assert.Throws<ArgumentException>(act, "FindWinner expect board with square dimensions.");
        }
    }
}
