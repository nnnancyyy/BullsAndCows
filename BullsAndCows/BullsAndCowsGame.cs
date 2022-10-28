using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var countBulls = CountBulls(guess);
            return $"{countBulls}A0B";
        }

        private int CountBulls(string guess)
        {
            var gussDigits = guess.Split(" ");
            var secretDigits = secret.Split(" ");
            return secretDigits.Where((t, index) => gussDigits[index] == t).Count();
        }
    }
}