using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace Data.SqlServer2012.Test
{
    [TestClass]
    public class Database
    {
        private const string ValidConnString = @"Data Source=(localdb)\Projects;Initial Catalog=QuasimaTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        private const string InvalidConnString = "invalid conn str";
        
        private static SqlServer2012.Database Db { get { return new SqlServer2012.Database(); } }
        private static readonly CancellationTokenSource doNotCancelThisTokenSource = new CancellationTokenSource();



        [TestClass]
        public class ConnectAsync
        {

            [TestMethod]
            public void CanConnect()
            {
                Assert.IsTrue(Db.Connect(doNotCancelThisTokenSource.Token, ValidConnString).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void InvalidConnStringFails()
            {
                Assert.IsFalse(!Db.Connect(doNotCancelThisTokenSource.Token, InvalidConnString).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void EmptyConnStringFails()
            {
                Assert.IsFalse(!Db.Connect(doNotCancelThisTokenSource.Token, string.Empty).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void EmptyConnStringFails2()
            {
                Assert.IsFalse(!Db.Connect(doNotCancelThisTokenSource.Token).Result);
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void CanCancel()
            {
                var cts = new CancellationTokenSource();
                var t = Task.Factory.StartNew(() => Db.Connect(cts.Token, ValidConnString), cts.Token);
                cts.Cancel();
                t.Wait();
                Assert.IsFalse(t.Result.Result);
            }


        }

        [TestClass]
        public class DisconnectAsync
        {
            [TestMethod]
            public void CanDisconnect()
            {
                if (Db.Connect(doNotCancelThisTokenSource.Token, ValidConnString).Result)
                {
                    Assert.IsTrue(Db.Disconnect(doNotCancelThisTokenSource.Token).Result);
                }
                else
                {
                    throw new AssertFailedException("Database did not connect (this is unexpected).");
                }
            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void CanCancel()
            {
                var cts = new CancellationTokenSource();
                var t = Task.Factory.StartNew(() => Db.Disconnect(cts.Token), cts.Token);
                cts.Cancel();
                t.Wait();
                Assert.IsFalse(t.Result.Result);
            }
        }

        [TestClass]
        public class GetTables
        {
            [TestMethod]
            public void CanGetTables()
            {
                
            }
        }
    }
}
