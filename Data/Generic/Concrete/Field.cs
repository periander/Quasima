
using System;
using System.IO;
using Data.Interface;

namespace Data.Generic.Concrete
{
    public class Field : IField
    {
        private object _value;
        private readonly IFieldDefinition _fieldDefinition;

        private Type LogicalFieldType
        {
            get
            {
                return _fieldDefinition.Type.LogicalTypeType;
            }
        }

        private object NewInstanceOfLogicalFieldType
        {
            get
            {
                if (LogicalFieldType == typeof(string))
                {
                    return string.Empty;
                }
                else
                {
                    return Activator.CreateInstance(LogicalFieldType);
                }
            }
        }

        public Field(IFieldDefinition fieldDefinition = null) // We make this an optional paramter - but really it's not, this is just so we can throw a relevant argument null exception in case someone uses the default constructor when we don't want them to.
        {
            if(fieldDefinition == null)
            {
                throw new ArgumentNullException("fieldDefinition", "Field cannot be instantiated without field definition parameter.");
            }
            _fieldDefinition = fieldDefinition;
            _value = this.NewInstanceOfLogicalFieldType;
        }

        public object Value
        {
            get
            {
                return _value;    
            }
            set
            {
                if(value == null)
                {
                    if (!_fieldDefinition.Nullable)
                    {
                        throw new ArgumentNullException("value", "Value cannot be null for field " + _fieldDefinition.Name + ".");
                    }
                    else
                    {
                        _value = null;
                    }
                }
                else
                {
                    if (value.GetType() != LogicalFieldType)
                    {
                        throw new ArgumentException("Value of " + value + " is not valid for field " + _fieldDefinition.Name + ".", "value");
                    }
                    else
                    {
                        _value = value;
                    }
                }
            }
        }

        /// <summary>
        /// For testing only.
        /// </summary>
        /// <param name="value"></param>
        internal void SetValueNoErrorChecking(object value)
        {
            _value = value;
        }


        public IFieldDefinition FieldDefinition
        {
            get { return _fieldDefinition; }
        }
    }
}
