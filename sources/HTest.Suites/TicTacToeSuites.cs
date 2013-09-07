namespace HTest.Suites
{
    using System;

    using NUnit.Framework;

    public class TicTacToeSuites
    {
        [Test]
        public void TicTacToe_NullBoard_ThrowsException()
        {
            // Arrange
            char[,] board = null;

            // Act
            TestDelegate act = () => new TicTacToe(board);

            // Assert
            Assert.Throws<ArgumentNullException>(act, "TicTacToe constructor should throw exception when board is null.");
        }

        [Test]
        public void TicTacToe_BoardIsNotSquare_ThrowsException()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E}, 
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E}, 
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E}, 
                                };

            // Act
            TestDelegate act = () => new TicTacToe(board);

            // Assert
            var exception = Assert.Throws<ArgumentException>(act, "TicTacToe constructor expect board with square dimensions.");
            Assert.IsTrue(exception.Message.IndexOf(Strings.ErrMsg_TicTacToeBoardShouldBeSquare, StringComparison.CurrentCulture) >= 0, "Error message should match");
        }

        [Test]
        public void TicTacToe_BoardSizeLessThan3_ThrowsException()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.E, TicTacToe.E,}, 
                                    { TicTacToe.E, TicTacToe.E }
                                };

            // Act
            TestDelegate act = () => new TicTacToe(board);

            // Assert
            var exception = Assert.Throws<ArgumentException>(act, "TicTacToe constructor should throw exception when board has less than 3 rows or columns.");
            Assert.IsTrue(exception.Message.IndexOf(Strings.ErrMsg_BoardMinimumSize, StringComparison.CurrentCulture) >= 0, "Error message should match");
        }

        [Test]
        public void TicTacToe_WinnerSizeLessThan3_ThrowsException()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E }, 
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E }, 
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E }, 
                                };

            // Act
            TestDelegate act = () => new TicTacToe(board, winnerRowLength: 2);

            // Assert
            var exception = Assert.Throws<ArgumentException>(act, "TicTacToe constructor expect winner size > 3.");
            Assert.IsTrue(exception.Message.IndexOf(Strings.ErrMsg_WinnerRowLengthMinimum, StringComparison.CurrentCulture) >= 0, "Error message should match");
        }

        [Test]
        public void TicTacToe_WinnerSizeMoreThanBoardSize_ThrowsException()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E }, 
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E }, 
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E }, 
                                };

            // Act
            TestDelegate act = () => new TicTacToe(board, winnerRowLength: 4);

            // Assert
            var exception = Assert.Throws<ArgumentException>(act, "TicTacToe constructor expect winner size < board size.");
            Assert.IsTrue(exception.Message.IndexOf(Strings.ErrMsg_WinnerRowLengthShouldBeLessThanBoardSize, StringComparison.CurrentCulture) >= 0, "Error message should match");
        }

        // ******************************************************************
        // Board 3x3 tests (Winner row length = 3)

        [Test]
        public void FindWinner_EmptyBoard_ReturnsNull()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E }, 
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E }, 
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E }, 
                                };

            // Act
            char? winner = (new TicTacToe(board)).FindWinner();

            // Assert
            Assert.IsNull(winner, "Should return null when no winners");
        }

        [Test]
        public void FindWinner_FullBoardWithoutWinners_ReturnsNull()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X }, 
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.O }, 
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O }, 
                                };

            // Act
            char? winner = (new TicTacToe(board)).FindWinner();

            // Assert
            Assert.IsNull(winner, "Should return null when no winners");
        }

        [Test]
        public void FindWinner_WinnerOnColumn_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X }, 
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.O }, 
                                    { TicTacToe.X, TicTacToe.X, TicTacToe.O }, 
                                };

            // Act
            char? winner = (new TicTacToe(board)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.X, winner, "Should return winner");
        }

        [Test]
        public void FindWinner_WinnerOnRow_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X }, 
                                    { TicTacToe.X, TicTacToe.X, TicTacToe.O }, 
                                    { TicTacToe.O, TicTacToe.O, TicTacToe.O }, 
                                };

            // Act
            char? winner = (new TicTacToe(board)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.O, winner, "Should return winner");
        }

        [Test]
        public void FindWinner_WinnerOnTopLeftToBottonRightDiagonal_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X }, 
                                    { TicTacToe.X, TicTacToe.X, TicTacToe.O }, 
                                    { TicTacToe.O, TicTacToe.O, TicTacToe.X }, 
                                };

            // Act
            char? winner = (new TicTacToe(board)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.X, winner, "Should return winner");
        }

        [Test]
        public void FindWinner_WinnerOnTopRightToBottonLeftDiagonal_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X }, 
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O }, 
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.O }, 
                                };

            // Act
            char? winner = (new TicTacToe(board)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.X, winner, "Should return winner");
        }

        // ******************************************************************
        // Board 5x5 tests (Winner row length = 4)

        [Test]
        public void FindWinner_FullBoard5x5And4WinnerLengthWithoutWinners_ReturnsNull()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O },
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.O, TicTacToe.X, TicTacToe.X },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.X, TicTacToe.O, TicTacToe.O },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.X },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O, TicTacToe.O },
                                };

            // Act
            char? winner = (new TicTacToe(board, winnerRowLength: 4)).FindWinner();

            // Assert
            Assert.IsNull(winner, "Should return null when no winners");
        }

        [Test]
        public void FindWinner_Board5x5And4WinnerLengthWinnerOnColumn_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O },
                                    { TicTacToe.X, TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.X },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.X, TicTacToe.O, TicTacToe.O },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.X },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O, TicTacToe.O },
                                };

            // Act
            char? winner = (new TicTacToe(board, winnerRowLength: 4)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.X, winner, "Should return winner");
        }

        [Test]
        public void FindWinner_Board5x5And4WinnerLengthWinnerOnRow_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O },
                                    { TicTacToe.X, TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.X },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.X, TicTacToe.O, TicTacToe.O },
                                    { TicTacToe.O, TicTacToe.O, TicTacToe.O, TicTacToe.O, TicTacToe.X },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O, TicTacToe.O },
                                };

            // Act
            char? winner = (new TicTacToe(board, winnerRowLength: 4)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.O, winner, "Should return winner");
        }

        [Test]
        public void FindWinner_Board5x5And4WinnerLengthWinnerOnTopLeftToBottonRightDiagonal_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O },
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.O, TicTacToe.X, TicTacToe.X },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.X, TicTacToe.O, TicTacToe.O },
                                    { TicTacToe.O, TicTacToe.O, TicTacToe.O, TicTacToe.X, TicTacToe.O },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O, TicTacToe.O },
                                };

            // Act
            char? winner = (new TicTacToe(board, winnerRowLength: 4)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.O, winner, "Should return winner");
        }

        [Test]
        public void FindWinner_Board5x5And4WinnerLengthWinnerOnTopRightToBottonLeftDiagonal_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.X, TicTacToe.X },
                                    { TicTacToe.X, TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.X },
                                    { TicTacToe.O, TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.X, TicTacToe.O },
                                    { TicTacToe.O, TicTacToe.X, TicTacToe.O, TicTacToe.O, TicTacToe.O },
                                };

            // Act
            char? winner = (new TicTacToe(board, winnerRowLength: 4)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.X, winner, "Should return winner");
        }

        // ******************************************************************
        // Board 5x5 tests (Winner row length = 3)

        [Test]
        public void FindWinner_Board5x5And3WinnerLengthWinnerOnTopLeftToBottonRightDiagonal_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.X, TicTacToe.E, TicTacToe.E },
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.X, TicTacToe.E },
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.X },
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E },
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E },
                                };

            // Act
            char? winner = (new TicTacToe(board, winnerRowLength: 3)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.X, winner, "Should return winner");
        }

        [Test]
        public void FindWinner_Board5x5And3WinnerLengthWinnerOnTopRightToBottonLeftDiagonal_ReturnsWinner()
        {
            // Arrange
            char[,] board = new char[,]
                                {
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E },
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E },
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.X },
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.E, TicTacToe.X, TicTacToe.E },
                                    { TicTacToe.E, TicTacToe.E, TicTacToe.X, TicTacToe.E, TicTacToe.E },
                                };

            // Act
            char? winner = (new TicTacToe(board, winnerRowLength: 3)).FindWinner();

            // Assert
            Assert.AreEqual(TicTacToe.X, winner, "Should return winner");
        }
    }
}
