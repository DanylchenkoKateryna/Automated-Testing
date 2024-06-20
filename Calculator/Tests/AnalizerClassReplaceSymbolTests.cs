using AnalaizerClassLibrary;
using CalcClassBr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Xunit;

namespace Tests
{
    public class AnalizerClassReplaceSymbolTests
    {
        private readonly CalcClass calcClass = new CalcClass();

        [Fact]
        public void Add_10And20_ReturnWrongResult()
        {
            int a = 10;
            int b = 20;
            int expected = 30;

            int result = calcClass.Add(a, b);

            Xunit.Assert.Equal(expected, result);
        }
    }
    
}
