using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.SqlServer2012.Test
{
    [TestClass]
    public class Database
    {
        private static SqlServer2012.Database Db { get { return new SqlServer2012.Database(); } }

        [TestClass]
        public class ConnectAsync
        {
            private const string ValidConnString = @"Data Source=(localdb)\Projects;Initial Catalog=QuasimaTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            private const string InvalidConnString = "invalid";

            [TestMethod]
            public void CanConnect()
            {
                Assert.IsTrue(Db.Connect(ValidConnString).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void InvalidConnStringFails()
            {
                Assert.IsFalse(!Db.Connect(InvalidConnString).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void EmptyConnStringFails()
            {
                Assert.IsFalse(!Db.Connect(string.Empty).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void EmptyConnStringFails2()
            {
                Assert.IsFalse(!Db.Connect().Result);
            }
        }

    }
}
