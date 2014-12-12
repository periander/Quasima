using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.UnitTest.SqlServer2012
{
    [TestClass]
    public class Database : Interface.IDatabase
    {
        public Database()
            : base(factory: new Data.SqlServer2012.DatabaseFactory(),
            validConnectionString: @"Data Source=(localdb)\Projects;Initial Catalog=QuasimaTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False")
        {
        }
    }
}
