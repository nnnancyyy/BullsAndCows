using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_4A0B_when_is_the_same_with_secret()
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(x => x.GenerateSecret()).Returns("1 2 3 4");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess("1 2 3 4");
            //then
            Assert.Equal("4A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 2 5 6")]
        [InlineData("1 2 3 4", "5 2 3 6")]
        [InlineData("1 2 3 4", "5 6 3 4")]
        public void Should_return_2A0B(string secret, string guessDigits)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(x => x.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guessDigits);
            //then
            Assert.Equal("2A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 5 2 6")]
        [InlineData("1 2 3 4", "5 2 6 3")]
        [InlineData("1 2 3 4", "5 3 6 4")]
        public void Should_return_1A1B(string secret, string guessDigits)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(x => x.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guessDigits);
            //then
            Assert.Equal("1A1B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 3 2 4")]
        [InlineData("1 2 3 4", "4 2 3 1")]
        public void Should_return_2A2B(string secret, string guessDigits)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(x => x.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guessDigits);
            //then
            Assert.Equal("2A2B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "4 3 2 1")]
        [InlineData("1 2 3 4", "4 1 2 3")]
        public void Should_return_0A4B(string secret, string guessDigits)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(x => x.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guessDigits);
            //then
            Assert.Equal("0A4B", guessResult);
        }
    }
}
