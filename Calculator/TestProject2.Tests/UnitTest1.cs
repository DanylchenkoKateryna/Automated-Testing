using CalcClassBr;
using System;
using Xunit;

namespace TestProject2.Tests
{
    public class UnitTest1
    {
        private readonly CalcClass calcClass = new CalcClass();

        [Theory]
        [InlineData(6, 7, 13)]
        [InlineData(8, 9, 17)]
        [InlineData(10, 11, 21)]
        public void Add_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = calcClass.Add(a, b);
            Assert.Equal(expected, result);
        }

       
        [Fact]
        public void Div_DivideByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calcClass.Div(a, b));
        } 

    }
}
