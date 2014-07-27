using Data.Generic.Abstract;
using Data.Interface;

namespace Data.Generic.Concrete
{
    public class FieldDefinition : Abstract.FieldDefinition
    {
        public FieldDefinition(string name,
            IFieldType type,
            bool nullable,
            int maxLength,
            int position)
            : base(name, type, nullable, maxLength, position)
        {

        }
    }
}
