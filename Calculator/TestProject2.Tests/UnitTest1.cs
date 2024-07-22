using CalcClassBr;
using Xunit;

namespace TestProject2.Tests
{
    public class UnitTest1
    {
        private readonly CalcClass calcClass = new CalcClass();

        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(1, 2, 3)]
        [InlineData(-5, 5, 0)]
        [InlineData(100, 200, 300)]
        [InlineData(7, 3, 10)]
        [InlineData(0, 0, 0)]
        [InlineData(123, 456, 579)]
        [InlineData(-10, -20, -30)]
        [InlineData(500, 500, 1000)]
        [InlineData(99, 1, 100)]
        [InlineData(-1, 1, 0)]
        [InlineData(1000, 2000, 3000)]
        [InlineData(25, 25, 50)]
        [InlineData(11, 22, 33)]
        [InlineData(50, 50, 100)]
        [InlineData(33, 66, 99)]
        [InlineData(-100, 100, 0)]
        [InlineData(1234, 5678, 6912)]
        [InlineData(100, 250, 350)]
        [InlineData(111, 222, 333)]
        [InlineData(15, 30, 45)]
        [InlineData(77, 88, 165)]
        [InlineData(123, 321, 444)]
        [InlineData(200, 300, 500)]
        [InlineData(1, 99, 100)]
        [InlineData(2, 3, 5)]
        [InlineData(4, 5, 9)]
        [InlineData(6, 7, 13)]
        [InlineData(8, 9, 17)]
        [InlineData(10, 11, 21)]
        public void Add_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = calcClass.Add(a, b);
            Assert.Equal(expected, result);
        }
    }
}
