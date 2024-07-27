using CalcClassBr;
using Xunit;

namespace TestProject3.Tests
{
    public class UnitTest1
    {
        private readonly CalcClass calcClass = new CalcClass();

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(9, 9, 0)]
        [InlineData(15, 11, 4)]
        public void Sub_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = calcClass.Sub(a, b);
            Assert.Equal(expected, result);
        }
    }
}
