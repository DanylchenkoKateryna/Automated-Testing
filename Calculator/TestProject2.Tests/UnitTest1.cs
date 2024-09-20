using CalcClassBr;

using System;

using Xunit;

namespace TestProject2.Tests
{
    public class UnitTest1
    {
        private readonly CalcClass _calcClass = new CalcClass();

        [Theory]
        [InlineData(6, 7, 13)]
        [InlineData(8, 9, 17)]
        [InlineData(10, 11, 21)]
        public void Add_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = _calcClass.Add(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Div_DivideByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calcClass.Div(a, b));
        }

        [Theory]
        [InlineData(6, 7, 13)]
        [InlineData(8, 9, 17)]
        [InlineData(10, 11, 21)]
        public void Add1_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = _calcClass.Add1(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, 7, 13)]
        [InlineData(8, 9, 17)]
        [InlineData(10, 11, 21)]
        public void Add2_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = _calcClass.Add2(a, b);
            Assert.Equal(expected, result);
        }
    }
}
