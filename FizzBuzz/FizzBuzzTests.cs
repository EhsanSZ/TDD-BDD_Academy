using Xunit;

namespace FizzBuzz
{
    public class FizzBuzzTests
    {
        [Fact]
        public void Start_ShouldReturnAListWithGivenRoundsLength()
        {
            const int rounds = 100;

            var actual = FizzBuzz.Start(rounds);

            Assert.Equal(rounds, actual.Count);
        }

        [Theory]
        [InlineData("Fizz", 2)]
        [InlineData("Buzz", 4)]
        [InlineData("FizzBuzz", 29)]
        public void Start_ShouldReturnAListWithProperValuesAtGivenElements(string expected, int element)
        {
            const int rounds = 100;

            var actual = FizzBuzz.Start(rounds);

            Assert.Equal(expected, actual[element]);
        }

    }
}