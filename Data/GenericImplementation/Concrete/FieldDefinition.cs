using Data.GenericImplementation.Abstract;
using Data.Interface;

namespace Data.GenericImplementation.Concrete
{
    internal class ConcreteFieldDefinition : AbstractFieldDefinition
    {
        public ConcreteFieldDefinition(string name, IFieldType type) : base(name, type) { }
    }
}
