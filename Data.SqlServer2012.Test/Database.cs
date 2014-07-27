using System.Reflection;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.SqlServer2012.Test
{
    [TestClass]
    public class Database
    {
        [TestClass]
        public class ConnectAsync
        {
            [TestMethod]
            public void CanConnect()
            {
                var factory = new DatabaseFactory();
                var db = factory.GetDatabase();
                var ret = db.ConnectAsync(@"Data Source=(localdb)\Projects;Initial Catalog=QuasimaTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                Assert.IsTrue(ret.Result);
            }
        }
    }
}
