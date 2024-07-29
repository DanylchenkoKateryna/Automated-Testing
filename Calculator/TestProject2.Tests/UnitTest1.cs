using CalcClassBr;
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

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(9, 9, 0)]
        [InlineData(15, 11, 4)]
        public void Sub_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = calcClass.Sub(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(9, 9, 0)]
        [InlineData(15, 11, 4)]
        public void Sub1_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = calcClass.Sub1(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(10, 5, 2)]
        [InlineData(15, 5, 3)]
        public void Div_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = calcClass.Div(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, 7, 13)]
        [InlineData(8, 9, 17)]
        [InlineData(10, 11, 21)]
        public void Add1_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = calcClass.Add1(a, b);
            Assert.Equal(expected, result);
        }
    }
}
