namespace Bowling
{
    /// <summary>
    /// Models a bowling game with easy access to it's score.
    /// </summary>
    public class Game
    {
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
            Score += fallenPinsCount;
            return this;
        }

        /// <summary>
        /// Returns the computed score for that game so far.
        /// </summary>
        public int Score { get; private set; }
    }
}
