using Bowling;

using Xunit;

namespace Tests
{
    public class ScoreTests
    {
        [Fact (DisplayName = "No rolled game score is 0", Skip = "Redundant with only fail test")]
        public void NoRolledGameScoreIsZero () => Assert.Equal (0, new Game ().Score);

        [Fact (DisplayName = "Only failed roll game score is 0")]
        public void OnlyFailedRollGameScoreIsZero()
        {
            var game = new Game ();

            // 20 explanation: 10 turns with 2 roll each
            SameRoll (game, 0, 20);

            Assert.Equal (0, game.Score);
        }

        [Fact (DisplayName = "Only 1 pin each roll game score is 20")]
        public void OnlyOnePinEachRollGameScoreIsTwenty()
        {
            var game = new Game ();

            // 20 explanation: 10 turns with 2 roll each
            SameRoll (game, 1, 20);

            Assert.Equal (20, game.Score);
        }

        [Fact (DisplayName = "Starting spare followed by 7 game score is 24")]
        public void StartingSpareFollowedbySevenGameScoreIsTwentyFour()
        {
            var game = new Game ()
                .Roll (8)
                .Roll (2)
                .Roll (7);

            SameRoll (game, 0, 17);

            Assert.Equal (24, game.Score);
        }

        [Fact (Skip = "todo later in kata")]
        public void FinalStrikeGame ()
        {
            var game = new Game ()
                .Roll (9)
                .Roll (1)
                .Roll (4)
                .Roll (5)
                .Roll (7)
                .Roll (2)
                .Roll (4)
                .Roll (6)
                .Roll (5)
                .Roll (5)
                .Roll (10)
                .Roll (5)
                .Roll (3)
                .Roll (6)
                .Roll (2)
                .Roll (10)
                .Roll (10)
                .Roll (10)
                .Roll (10);

            Assert.Equal (161, game.Score);
        }

        [Fact (Skip = "todo later in kata")]
        public void NoFinalStrikeGame ()
        {
            var game = new Game ()
                .Roll (4)
                .Roll (2)
                .Roll (4)
                .Roll (5)
                .Roll (3)
                .Roll (5)
                .Roll (3)
                .Roll (2)
                .Roll (4)
                .Roll (5)
                .Roll (3)
                .Roll (5)
                .Roll (4)
                .Roll (6)
                .Roll (10)
                .Roll (2)
                .Roll (8)
                .Roll (6)
                .Roll (3);

            Assert.Equal (110, game.Score);
        }

        private Game SameRoll(Game game, int fallenPinsCount, int howManyTimes)
        {
            for (var i = 0; i < howManyTimes; ++i)
                game.Roll (fallenPinsCount);

            return game;
        }
    }
}
