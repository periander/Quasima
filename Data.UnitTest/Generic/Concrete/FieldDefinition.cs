using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Test.Generic.Concrete
{
    [TestClass]
    public class FieldDefinition
    {
        [TestClass]
        public class NameProperty
        {
            [TestMethod]
            public void CannotBeNull()
            {
                var fd = new Data.Generic.Concrete.FieldDefinition(null, new Data.Generic.Concrete.FieldTypes.StringField(), false, 50, 0);
                Assert.IsNotNull(fd.Name);
            }
        }
    }
}
