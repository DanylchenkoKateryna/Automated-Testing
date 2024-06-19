using AnalaizerClassLibrary;
using CalcClassBr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Xunit;

namespace Tests
{
    public class AnalizerClassIsOperatorTests
    {
        private readonly CalcClass calcClass=new CalcClass();

        [Fact]
        public void Add_10And20_Return30()
        {
            int a = 10;
            int b = 20;
            int expected = 30;

            int result = calcClass.Add(a, b);

            Xunit.Assert.Equal(expected, result);
        }
    }
}
