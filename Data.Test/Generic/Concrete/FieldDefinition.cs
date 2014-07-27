using Data.GenericImplementation.Concrete;
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
                var fd = new ConcreteFieldDefinition(null, new Data.GenericImplementation.Concrete.FieldTypes.StringField());
                Assert.IsNotNull(fd.Name);
            }
        }
    }
}
