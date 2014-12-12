using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.UnitTest.Interface
{
    /// <summary>
    /// This is actually abstract but is analoguous to Data.Interface.IDatabase.
    /// </summary>
    [TestClass]
    public abstract class IDatabase
    {
        private readonly IDatabaseFactory _databaseFactory;
        private Data.Interface.IDatabase _database { get; set; }
        private readonly string _connectionString;
        private CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();
        protected IDatabase(IDatabaseFactory factory, string validConnectionString)
        {
            _databaseFactory = factory;
            _connectionString = validConnectionString;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _cancelTokenSource = new CancellationTokenSource();
            _database = _databaseFactory.CreateDatabase();
        }


        #region ConnectAsync

        [TestMethod]
        public void ConnectAsync_CanConnect()
        {
            Assert.IsTrue(_database.Connect(_cancelTokenSource.Token, _connectionString).Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void ConnectAsync_InvalidConnStringFails()
        {
            Assert.IsFalse(!_database.Connect(_cancelTokenSource.Token, "some invalid string").Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void ConnectAsync_EmptyConnStringFails()
        {
            Assert.IsFalse(!_database.Connect(_cancelTokenSource.Token, string.Empty).Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void ConnectAsync_EmptyConnStringFails2()
        {
            Assert.IsFalse(!_database.Connect(_cancelTokenSource.Token).Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void ConnectAsync_CanCancel()
        {
            var t = Task.Factory.StartNew(() => _database.Connect(_cancelTokenSource.Token, _connectionString), _cancelTokenSource.Token);
            _cancelTokenSource.Cancel();
            //t.Wait();
            Assert.IsFalse(t.Result.Result);
        }

        #endregion


        #region DisconnectAsync

        [TestMethod]
        public void DisconnectAsync_CanDisconnect()
        {
            if (_database.Connect(_cancelTokenSource.Token, _connectionString).Result)
            {
                Assert.IsTrue(_database.Disconnect(_cancelTokenSource.Token).Result);
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
            var t = Task.Factory.StartNew(() => _database.Disconnect(_cancelTokenSource.Token), _cancelTokenSource.Token);
            _cancelTokenSource.Cancel();
            //t.Wait();
            Assert.IsFalse(t.Result.Result);
        }

        #endregion

        #region GetTables

        [TestMethod]
        public void GetTables_CanGetTables()
        {
            if (_database.Connect(_cancelTokenSource.Token, _connectionString).Result)
            {
                Assert.IsTrue(_database.GetTables(_cancelTokenSource.Token).Result.Any());


            }
            else
            {
                throw new AssertFailedException("Database did not connect (this is unexpected if the CanConnect test passed).");
            }
        }

        #endregion

        #region GetTable

        [TestMethod]
        public void GetTable_ValidTableName()
        {
            if (_database.Connect(_cancelTokenSource.Token, _connectionString).Result)
            {
                Assert.IsTrue(_database.GetTable(_cancelTokenSource.Token, "Patient").Result != null);


            }
            else
            {
                throw new AssertFailedException("Database did not connect (this is unexpected if the CanConnect test passed).");
            }
            
        }



        [TestMethod]
        public void GetTable_InvalidTableName()
        {
            if (_database.Connect(_cancelTokenSource.Token, _connectionString).Result)
            {
                Assert.IsTrue(_database.GetTable(_cancelTokenSource.Token, "FAKE_TABLE_NAME").Result == null);


            }
            else
            {
                throw new AssertFailedException("Database did not connect (this is unexpected if the CanConnect test passed).");
            }

        }

        #endregion

    }
}
