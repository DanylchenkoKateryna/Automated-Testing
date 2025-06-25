using CalcClassBr;

using System;

using Xunit;

namespace Tests.DivideTestFolder
{
    public class CalcClassDivTests
    {
        private readonly CalcClass _calcClass = new CalcClass();


        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(20, 4, 5)]
        [InlineData(100, 10, 10)]
        [InlineData(50, 5, 10)]
        [InlineData(0, 1, 0)]
        [InlineData(-10, 2, -5)]
        [InlineData(10, -2, -5)]
        [InlineData(-20, -4, 5)]
        [InlineData(9, 3, 3)]
        [InlineData(25, 5, 5)]
        [InlineData(100, 25, 4)]
        [InlineData(144, 12, 12)]
        [InlineData(81, 9, 9)]
        [InlineData(1, 1, 1)]
        [InlineData(123, 1, 123)]
        [InlineData(1000, 10, 100)]
        [InlineData(200, 2, 100)]
        [InlineData(400, 4, 100)]
        [InlineData(800, 8, 100)]
        [InlineData(150, 5, 30)]
        [InlineData(121, 11, 11)]
        [InlineData(242, 22, 11)]
        [InlineData(484, 22, 22)]
        [InlineData(600, 50, 12)]
        [InlineData(360, 30, 12)]
        [InlineData(72, 6, 12)]
        [InlineData(108, 9, 12)]
        [InlineData(55, 5, 11)]
        [InlineData(110, 10, 11)]
        [InlineData(990, 90, 11)]
        public void Div_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = _calcClass.Div(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Div_DivisionByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calcClass.Div(10, 0));
        }
    }
}
