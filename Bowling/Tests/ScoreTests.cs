using Bowling;
using System;
using Xunit;

namespace Tests
{
    public class ScoreTests
    {

        Partie partie = new Partie();

        [Fact]
        public void PartieAvecStrikeFinal()
        {
            partie.Lancer(9)
                    .Lancer(1)
                    .Lancer(4)
                    .Lancer(5)
                    .Lancer(7)
                    .Lancer(2)
                    .Lancer(4)
                    .Lancer(6)
                    .Lancer(5)
                    .Lancer(5)
                    .Lancer(10)
                    .Lancer(5)
                    .Lancer(3)
                    .Lancer(6)
                    .Lancer(2)
                    .Lancer(10)
                    .Lancer(10)
                    .Lancer(10)
                    .Lancer(10);

            Assert.Equal(161, partie.CalculerScore());
        }

        [Fact]
        public void PartieSansStrikeFinal()
        {
            partie.Lancer(4)
                    .Lancer(2)
                    .Lancer(4)
                    .Lancer(5)
                    .Lancer(3)
                    .Lancer(5)
                    .Lancer(3)
                    .Lancer(2)
                    .Lancer(4)
                    .Lancer(5)
                    .Lancer(3)
                    .Lancer(5)
                    .Lancer(4)
                    .Lancer(6)
                    .Lancer(10)
                    .Lancer(2)
                    .Lancer(8)
                    .Lancer(6)
                    .Lancer(3);

            Assert.Equal(110, partie.CalculerScore());
        }
    }
}
