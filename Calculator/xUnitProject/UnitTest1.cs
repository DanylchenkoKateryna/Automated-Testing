using CalcClassBr;

using FluentAssertions;

using System.Web;
using System.Web.Caching;

using Xunit;

namespace xUnitProject
{
    public class UnitTest1
    {
        private readonly CalcClass calcClass = new CalcClass();
        private readonly Cache cache = HttpRuntime.Cache;

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(1, 9, 9)]
        [InlineData(10, 0, 0)]
        public void Mult_VariousInputs_ReturnsExpectedResults(int a, int b, int expected)
        {
            int result = calcClass.Mult(a, b);
            Assert.Equal(expected, result);
            result.Should().Be(expected);
        }
        
    }
}
