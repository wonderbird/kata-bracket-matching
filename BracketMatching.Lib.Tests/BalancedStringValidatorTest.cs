using csharp.Lib;
using Xunit;

namespace BracketMatching.Lib.Tests
{
    public class BalancedStringValidatorTest
    {
        [Fact]
        public void IsBalanced_EmptyString_ReturnsTrue()
        {
            Assert.True("".IsBalanced(""));
        }

        [Theory]
        [InlineData(true, "(Sensei says yes!)", "()")]
        [InlineData(false, "(Sensei says no!", "()")]
        [InlineData(false, "Sensei says no!)", "()")]
        [InlineData(true, "[Sensei says yes!]", "[]")]
        [InlineData(false, "[Sensei says no!", "[]")]
        public void IsBalanced_SingleParentheses_ReturnsExpectedResult(bool expectation, string input,
            string balancingCharacterPairs)
        {
            Assert.Equal(expectation, input.IsBalanced(balancingCharacterPairs));
        }

        [Theory]
        [InlineData(true, "(Sensei [says] yes!)", "()[]")]
        [InlineData(false, "(Sensei [says) no!]", "()[]")]
        [InlineData(true, "Sensei says 'yes'!", "''")]
        [InlineData(false, "Sensei say's no!", "''")]
        public void IsBalanced_DataFromCodeWars_ExpectedResultFromCodewars(bool expectation, string input,
            string balancingCharacterPairs)
        {
            Assert.Equal(expectation, Kata.IsBalanced(input, balancingCharacterPairs));
        }
    }
}
