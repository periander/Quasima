using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Interface;

namespace Data.SqlServer2012.Test
{
    [TestClass]
    public class Database
    {
        private static IDatabaseFactory Factory { get { return new DatabaseFactory(); } }
        private static IDatabase Db { get { return Factory.GetDatabase(); } }

        [TestClass]
        public class ConnectAsync
        {
            private const string ValidConnString = @"Data Source=(localdb)\Projects;Initial Catalog=QuasimaTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            private const string InvalidConnString = "invalid";

            [TestMethod]
            public void CanConnect()
            {
                Assert.IsTrue(Db.ConnectAsync(ValidConnString).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void InvalidConnStringFails()
            {
                Assert.IsFalse(!Db.ConnectAsync(InvalidConnString).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void EmptyConnStringFails()
            {
                Assert.IsFalse(!Db.ConnectAsync(string.Empty).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void EmptyConnStringFails2()
            {
                Assert.IsFalse(!Db.ConnectAsync().Result);
            }
        }

    }
}
