using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.UnitTest
{
    [TestClass]
    public abstract class Database
    {
        private readonly IDatabaseFactory databaseFactory;
        private IDatabase database { get; set; }
        private readonly string connectionString;
        private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        protected Database(IDatabaseFactory factory, string validConnectionString)
        {
            databaseFactory = factory;
            connectionString = validConnectionString;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            cancelTokenSource = new CancellationTokenSource();
            database = databaseFactory.CreateDatabase();
        }


        #region ConnectAsync

        [TestMethod]
        public void ConnectAsync_CanConnect()
        {
            Assert.IsTrue(database.Connect(cancelTokenSource.Token, connectionString).Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void ConnectAsync_InvalidConnStringFails()
        {
            Assert.IsFalse(!database.Connect(cancelTokenSource.Token, "some invalid string").Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void ConnectAsync_EmptyConnStringFails()
        {
            Assert.IsFalse(!database.Connect(cancelTokenSource.Token, string.Empty).Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void ConnectAsync_EmptyConnStringFails2()
        {
            Assert.IsFalse(!database.Connect(cancelTokenSource.Token).Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void ConnectAsync_CanCancel()
        {
            var t = Task.Factory.StartNew(() => database.Connect(cancelTokenSource.Token, connectionString), cancelTokenSource.Token);
            cancelTokenSource.Cancel();
            //t.Wait();
            Assert.IsFalse(t.Result.Result);
        }

        #endregion


        #region DisconnectAsync

        [TestMethod]
        public void DisconnectAsync_CanDisconnect()
        {
            if (database.Connect(cancelTokenSource.Token, connectionString).Result)
            {
                Assert.IsTrue(database.Disconnect(cancelTokenSource.Token).Result);
            }
            else
            {
                throw new AssertFailedException("Database did not connect (this is unexpected if the CanConnect test passed).");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DisconnectAsync_CanCancel()
        {
            var t = Task.Factory.StartNew(() => database.Disconnect(cancelTokenSource.Token), cancelTokenSource.Token);
            cancelTokenSource.Cancel();
            //t.Wait();
            Assert.IsFalse(t.Result.Result);
        }

        #endregion

        #region GetTables

        [TestMethod]
        public void GetTables_CanGetTables()
        {
            if (database.Connect(cancelTokenSource.Token, connectionString).Result)
            {
                Assert.IsTrue(database.GetTables(cancelTokenSource.Token).Result.Any());


            }
            else
            {
                throw new AssertFailedException("Database did not connect (this is unexpected if the CanConnect test passed).");
            }
        }

        #endregion

    }
}
