using System;
using Data.Generic.Concrete;
using Data.Generic.Concrete.FieldTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.UnitTest.Generic.Concrete
{
    [TestClass]
    public class Field
    {

        private const string BasicStringValue = "BASICSTRINGVALUE";
        private const int BasicIntValue = 123;
        private readonly FieldDefinition _basicStringFieldDefinition = new FieldDefinition("BASICSTRINGFIELD", new StringFieldType(), true, 10, 0);
        private readonly FieldDefinition _nonNullableStringFieldDefinition = new FieldDefinition("NULLABLESTRINGFIELD", new StringFieldType(), false, 10, 0);

        [TestInitialize]
        public void TestInitialize()
        {
        }

        #region Constructor

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NoParameter()
        {
            new Data.Generic.Concrete.Field();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullParameter()
        {
            new Data.Generic.Concrete.Field(null);
        }

        #endregion

        #region Value

        [TestMethod]
        public void GetValue_BasicString()
        {
            var stringField = new Data.Generic.Concrete.Field(this._basicStringFieldDefinition);
            stringField.SetValueNoErrorChecking(BasicStringValue);
            Assert.IsTrue(BasicStringValue == (string)stringField.Value);
        }

        [TestMethod]
        public void SetValue_BasicString()
        {
            var stringField = new Data.Generic.Concrete.Field(this._basicStringFieldDefinition);
            stringField.Value = BasicStringValue;
            Assert.IsTrue(BasicStringValue == (string)stringField.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetValue_InvalidValueType()
        {
            var stringField = new Data.Generic.Concrete.Field(this._basicStringFieldDefinition);
            stringField.Value = BasicIntValue;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetValue_NullValueForNonNullableField()
        {
            var stringField = new Data.Generic.Concrete.Field(this._nonNullableStringFieldDefinition);
            stringField.Value = null;
        }

        #endregion
    }
}
