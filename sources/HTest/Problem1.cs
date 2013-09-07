namespace HTest
{
    using System;

    public class Problem1
    {
        /// <summary>
        /// Find the longest consecutive sub-sequence of increasing numbers.
        /// </summary>
        /// <param name="sequence">Array of integers.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="sequence"/> is null.</exception>
        /// <exception cref="ArgumentException">If <paramref name="sequence"/> is empty.</exception>
        /// <returns>Array of sub-sequence.</returns>
        public static int[] FindSubsequence(int[] sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }

            if (sequence.Length == 0)
            {
                throw new ArgumentException(Strings.ErrMsg_SequenceShouldNotBeEmpty, "sequence");
            }

            int maxSequenceIndex = 0;
            int maxSequenceLength = 1;

            int sequenceIndex = 0;
            int sequenceLength = 1;

            // Searching for longest consecutive sub-sequence

            int index = 1;
            while (index < sequence.Length) 
            {
                bool consecutive = (sequence[index] - sequence[index - 1]) == 1;

                if (consecutive)
                {
                    if (sequenceIndex + sequenceLength == index)
                    {
                        sequenceLength++;
                    }
                    else
                    {
                        sequenceIndex = index - 1;
                        sequenceLength = 2;
                    }
                }

                index++;

                if (consecutive == false || index == sequence.Length)
                {
                    if (sequenceLength > maxSequenceLength)
                    {
                        maxSequenceIndex = sequenceIndex;
                        maxSequenceLength = sequenceLength;
                    }
                }
            }

            // Reserve array for sub-sequence
            int[] result = new int[maxSequenceLength];
            for (int i = 0; i < maxSequenceLength; i++)
            {
                result[i] = sequence[maxSequenceIndex + i];
            }

            return result;
        }
    }
}
