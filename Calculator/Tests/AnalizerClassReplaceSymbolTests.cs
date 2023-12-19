using AnalaizerClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Tests
{
    [TestClass]
    public class AnalizerClassReplaceSymbolTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("System.Data.SqlClient", "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TestData;" +
            "Integrated Security=True","ReplaceSymbolData", DataAccessMethod.Sequential)]

        [TestMethod]
        public void ReplaceSymbol_FromDB_AreEqual()
        {
            //arrange

            string expected = (string)TestContext.DataRow["Result"];
            string a = (string)TestContext.DataRow["Symbol"];

            Type type= typeof(AnalaizerClass);
            MethodInfo method = type.GetMethod("ReplaceSymbol", BindingFlags.NonPublic | BindingFlags.Static);

            object[] parameterValues =
            {
                (string)TestContext.DataRow["Input"],
                char.Parse(a),
                (int)TestContext.DataRow["Position"]
            };

            //act

            string result = (string)method.Invoke("ReplaceSymbol", parameterValues);

            //assert

            Assert.AreEqual(expected, result);
        }
    }
}
