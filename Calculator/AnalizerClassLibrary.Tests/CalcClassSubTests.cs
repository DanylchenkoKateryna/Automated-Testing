using CalcClassBr;
using System.Threading;
using Xunit;

namespace Tests
{
    public class CalcClassSubTests
    {
        private readonly CalcClass calcClass = new CalcClass();

        [Theory]
        [InlineData(10, 20, -10)]
        [InlineData(20, 10, 10)]
        [InlineData(5, 5, 0)]
        [InlineData(100, 50, 50)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, -1)]
        [InlineData(-10, -20, 10)]
        [InlineData(-20, -10, -10)]
        [InlineData(1000, 500, 500)]
        [InlineData(123, 45, 78)]
        [InlineData(100, 101, -1)]
        [InlineData(50, 25, 25)]
        [InlineData(75, 50, 25)]
        [InlineData(20, 30, -10)]
        [InlineData(200, 100, 100)]
        [InlineData(300, 150, 150)]
        [InlineData(400, 100, 300)]
        [InlineData(10, 5, 5)]
        [InlineData(5, 10, -5)]
        [InlineData(999, 1, 998)]
        [InlineData(1234, 567, 667)]
        [InlineData(2000, 1000, 1000)]
        [InlineData(10000, 5000, 5000)]
        [InlineData(12345, 54321, -41976)]
        [InlineData(100, 99, 1)]
        [InlineData(25, 20, 5)]
        [InlineData(30, 40, -10)]
        [InlineData(60, 30, 30)]
        [InlineData(80, 40, 40)]
        public void Sub_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = calcClass.Sub(a, b);
            Assert.Equal(expected, result);
        }
    }
}
