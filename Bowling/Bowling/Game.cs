namespace Bowling
{
    /// <summary>
    /// Models a bowling game with easy access to it's score.
    /// </summary>
    public class Game
    {
        // 21 explanation: max possible rolls (10 spares + 1 extra roll)
        private readonly int[] rolls = new int[21];
        private int rollIndex = 0;

        /// <summary>
        /// Records the amount of pins fallen this roll.
        /// </summary>
        /// <param name="fallenPinsCount">
        /// The amount of fallen pins.
        /// </param>
        /// <returns>
        /// The same game instance.
        /// </returns>
        public Game Roll (int fallenPinsCount)
        {
            rolls[rollIndex++] = fallenPinsCount;
            return this;
        }

        /// <summary>
        /// Returns the computed score for that game so far.
        /// </summary>
        public int Score
        {
            get
            {
                var score = 0;
                var rollIndex = 0;

                for (var turn = 0; turn < 10; ++turn)
                {
                    if (rolls[rollIndex] == 10)
                    {
                        score += SpareScore (rollIndex);
                        ++rollIndex;
                    }
                    else
                    {
                        if (IsSpare (rollIndex))
                            score += SpareScore (rollIndex);
                        else
                            score += NormalScore (rollIndex);

                        rollIndex += 2;
                    }
                }

                return score;
            }
        }

        private int NormalScore (int rollIndex) => rolls[rollIndex] + rolls[rollIndex + 1];

        private bool IsSpare (int rollIndex) => NormalScore (rollIndex) == 10;

        private int SpareScore (int rollIndex) => NormalScore (rollIndex) + rolls[rollIndex + 2];
    }
}
