using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FizzBuzz
{
    public class TDD_FizzBuzzTest
    {
        [Theory]
        [InlineData("Fizz",2)]
        [InlineData("Buzz",4)]
        [InlineData("FizzBuzz",14)]
        public void Start_ShouldReturnProperValueAtExpectedElement(string expected, int element)
        {
            const int input = 120;

            var actual = TDD_FizzBuzz.Start(input);

            Assert.Equal(expected, actual[element]);

        }

        [Fact]
        public void Start_ShouldReturnAListWithGivenRoundLenth()
        {
            const int input = 120;

            var actual = TDD_FizzBuzz.Start(input);

            Assert.Equal(input, actual.Count);
        }

        //[Fact]
        //public void Start_ShouldReturnProperValueAtExpectedIndex_WhenNumberIsDividebleTo3()
        //{
        //    const int input = 120;
        //    const int element = 2;

        //    var actual = TDD_FizzBuzz.Start(input);

        //    Assert.Equal("Fizz", actual[element]);
        //}

        //[Fact]
        //public void Start_ShouldReturnProperValueAtExpectedIndex_WhenNumberIsDividebleTo5()
        //{
        //    const int input = 120;
        //    const int element = 4;

        //    var actual = TDD_FizzBuzz.Start(input);

        //    Assert.Equal("Buzz", actual[element]);
        //}

        //[Fact]
        //public void Start_ShouldReturnProperValueAtExpectedIndex_WhenNumberIsDividebleTo15()
        //{
        //    const int input = 120;
        //    const int element = 14;

        //    var actual = TDD_FizzBuzz.Start(input);

        //    Assert.Equal("FizzBuzz", actual[element]);
        //}

    }
}
