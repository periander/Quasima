
namespace Data.Interface
{
    public interface IField
    {
        object Value { get; set; }
        IFieldDefinition FieldDefinition { get; }
    }
}
