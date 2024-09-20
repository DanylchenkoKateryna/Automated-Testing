using CalcClassBr;

using FluentAssertions;

using Xunit;

namespace XUnitProject
{
    public class UnitTest1
    {
        private readonly CalcClass _calcClass = new CalcClass();

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(1, 9, 9)]
        [InlineData(10, 0, 0)]
        public void Mult_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = _calcClass.Mult(a, b);
            Assert.Equal(expected, result);
            result.Should().Be(expected);
        }
    }
}
