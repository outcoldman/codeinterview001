namespace HTest.Suites
{
    using System;
    using System.Globalization;
    using System.Linq;

    using NUnit.Framework;

    public class Problem1Suites
    {
        [Test]
        public void FindSubsequence_NullArray_ThrowsException()
        {
            // Arrange
            int[] sequence = null;

            // Act
            TestDelegate act = () => Problem1.FindSubsequence(sequence);

            // Assert
            Assert.Throws<ArgumentNullException>(act, "FindSubsequence should throw exception when sequence is null.");
        }

        [Test]
        public void FindSubsequence_EmptyArray_ThrowsException()
        {
            // Arrange
            int[] sequence = new int[0];

            // Act
            TestDelegate act = () => Problem1.FindSubsequence(sequence);

            // Assert
            Assert.Throws<ArgumentException>(act, "FindSubsequence should throw exception when sequence is empty.");
        }

        [Test]
        public void FindSubsequence_OneElement_ReturnsArrayWithOneElement()
        {
            // Arrange
            int[] sequence = new int[] { 1 };

            // Act
            int[] result = Problem1.FindSubsequence(sequence);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(new [] { 1 }, result) , "Result should be [ 1 ], but was [ {0}]", String.Join(", ", result.Select(x => x.ToString(CultureInfo.InvariantCulture))));
        }

        [Test]
        public void FindSubsequence_OneConsecutiveSequence_ReturnsWholeArray()
        {
            // Arrange
            int[] sequence = new int[] { 1, 2, 3, 4 };

            // Act
            int[] result = Problem1.FindSubsequence(sequence);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(new[] { 1, 2, 3, 4 }, result), "Result should be [ 1, 2, 3, 4 ], but was [ {0}]", String.Join(", ", result.Select(x => x.ToString(CultureInfo.InvariantCulture))));
        }

        [Test]
        public void FindSubsequence_TwoConsecutiveSequencesWithTheSameLength_ReturnsFirstSubsequence()
        {
            // Arrange
            int[] sequence = new int[] { 1, 2, 3, 4, 2, 3, 4, 5 };

            // Act
            int[] result = Problem1.FindSubsequence(sequence);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(new[] { 1, 2, 3, 4 }, result), "Result should be [ 1, 2, 3, 4 ], but was [ {0}]", String.Join(", ", result.Select(x => x.ToString(CultureInfo.InvariantCulture))));
        }

        [Test]
        public void FindSubsequence_TwoConsecutiveSequencesWhereSecondHasMoreElements_ReturnsSecondSubsequence()
        {
            // Arrange
            int[] sequence = new int[] { 1, 2, 3, 4, 2, 3, 4, 5, 6 };

            // Act
            int[] result = Problem1.FindSubsequence(sequence);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(new[] { 2, 3, 4, 5, 6 }, result), "Result should be [ 2, 3, 4, 5, 6 ], but was [ {0}]", String.Join(", ", result.Select(x => x.ToString(CultureInfo.InvariantCulture))));
        }

        [Test]
        public void FindSubsequence_ConsecutiveSequenceWithMoreElementsInCenter_ReturnsSubsequence()
        {
            // Arrange
            int[] sequence = new int[] { 1, 2, 3, 4, 2, 3, 4, 5, 6, 1, 2, 3, 4 };

            // Act
            int[] result = Problem1.FindSubsequence(sequence);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(new[] { 2, 3, 4, 5, 6 }, result), "Result should be [ 2, 3, 4, 5, 6 ], but was [ {0}]", String.Join(", ", result.Select(x => x.ToString(CultureInfo.InvariantCulture))));
        }

        [Test]
        public void FindSubsequence_ConsecutiveSequenceWithNegativeElements_ReturnsSubsequence()
        {
            // Arrange
            int[] sequence = new int[] { 1, 2, 3, 4, -2, -1, 0, 1, 2, 1, 2, 3, 4 };

            // Act
            int[] result = Problem1.FindSubsequence(sequence);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(new[] { -2, -1, 0, 1, 2 }, result), "Result should be [ -2, -1, 0, 1, 2 ], but was [ {0}]", String.Join(", ", result.Select(x => x.ToString(CultureInfo.InvariantCulture))));
        }
    }
}
