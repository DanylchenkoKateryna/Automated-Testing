using AnalaizerClassLibrary;
using CalcClassBr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Tests
{
    [TestClass]
    public class AnalizerClassReplaceSymbolTests
    {
        private readonly CalcClass calcClass = new CalcClass();

        [TestMethod]
        public void Add_10And20_ReturnWrongResult()
        {
            int a = 10;
            int b = 20;
            int expected = 50;

            int result = calcClass.Add(a, b);

            Assert.AreEqual(expected, result);
        }
    }
    
}
