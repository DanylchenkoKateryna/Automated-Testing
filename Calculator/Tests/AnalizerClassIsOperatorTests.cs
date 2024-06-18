using AnalaizerClassLibrary;
using CalcClassBr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Tests
{
    [TestClass]
    public class AnalizerClassIsOperatorTests
    {
        private readonly CalcClass calcClass=new CalcClass();

        [TestMethod]
        public void Add_10And20_retyrn30()
        {
            int a = 10;
            int b = 20;
            int expected = 30;

            int result = calcClass.Add(a, b);

            Assert.AreEqual(expected, result);
        }
    }
}
