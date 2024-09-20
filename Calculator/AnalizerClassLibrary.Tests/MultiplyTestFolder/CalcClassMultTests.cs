using CalcClassBr;

using Xunit;

namespace Tests.MultiplyTestFolder
{
    public class CalcClassMultTests
    {
        private readonly CalcClass _calcClass = new CalcClass();

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 4)]
        [InlineData(3, 3, 9)]
        [InlineData(4, 5, 20)]
        [InlineData(6, 7, 42)]
        [InlineData(8, 9, 72)]
        [InlineData(10, 10, 100)]
        [InlineData(-1, 1, -1)]
        [InlineData(-2, -2, 4)]
        [InlineData(3, -3, -9)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 5, 0)]
        [InlineData(10, 0, 0)]
        [InlineData(100, 100, 10000)]
        [InlineData(-10, 10, -100)]
        [InlineData(5, -5, -25)]
        [InlineData(6, 6, 36)]
        [InlineData(7, 8, 56)]
        [InlineData(9, 9, 81)]
        [InlineData(-5, -5, 25)]
        [InlineData(20, 30, 600)]
        [InlineData(-20, -30, 600)]
        [InlineData(15, -15, -225)]
        [InlineData(25, 25, 625)]
        [InlineData(50, 2, 100)]
        [InlineData(-50, 2, -100)]
        [InlineData(0, 100, 0)]
        [InlineData(1000, 1000, 1000000)]
        [InlineData(-1000, -1000, 1000000)]
        [InlineData(1000, -1000, -1000000)]
        public void Mult_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = _calcClass.Mult(a, b);
            Assert.Equal(expected, result);
        }
    }
}
