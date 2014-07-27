using System;
using System.Runtime.InteropServices;
using Data.Generic.Concrete;
using Data.Interface;

namespace Data.Generic.Abstract
{
    abstract class FieldDefinition : IFieldDefinition
    {
        internal FieldDefinition(string name, IFieldType type) { Name = name; Type = type; }

        private string _name = string.Empty;
        public string Name { get { return _name; } set { _name = string.IsNullOrEmpty(value) ? string.Empty : value; } }
        public IFieldType Type { get; private set; }
        
    }
}
