using BullsAndCows;
using Moq;
using Xunit;

namespace SecretGeneratorTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_return_4digits_when_given_4_numbers()
        {
            //given
            var secretGenerator = new SecretGenerator();
            //when
            var secret = secretGenerator.GenerateSecret();
            //then
            Assert.Equal(4, secret.Split(" ").Length);
        }
    }
}
