using System;
using System.Runtime.InteropServices;
using Data.GenericImplementation.Concrete;
using Data.Interface;

namespace Data.GenericImplementation.Abstract
{
    abstract class AbstractFieldDefinition : IFieldDefinition
    {
        internal AbstractFieldDefinition(string name, IFieldType type) { Name = name; Type = type; }

        public string Name { get; private set; }
        public IFieldType Type { get; private set; }
        
    }
}
