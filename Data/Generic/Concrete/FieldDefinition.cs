using Data.Generic.Abstract;
using Data.Interface;

namespace Data.Generic.Concrete
{
    internal class FieldDefinition : Abstract.FieldDefinition
    {
        public FieldDefinition(string name, IFieldType type) : base(name, type) { }
    }
}
