using AnalaizerClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Tests
{
    [TestClass]
    public class AnalizerClassIsOperatorTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("System.Data.SqlClient", "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TestData;" +
            "Integrated Security=True", "IsOperatorData", DataAccessMethod.Sequential)]
        
        [TestMethod]
        public void IsOperator_FromDB()
        {
            //arrange 

            bool expected = (bool)TestContext.DataRow["Result"];

            Type type = typeof(AnalaizerClass);
            MethodInfo method = type.GetMethod("IsOperator", BindingFlags.NonPublic | BindingFlags.Static);

            object[] parameterValues =
            {
                (string)TestContext.DataRow["Symbol"]
            };

            //act

            bool result = (bool)method.Invoke("IsOperator", parameterValues);

            //assert

            Assert.AreEqual(expected, result);
        }
    }
}
