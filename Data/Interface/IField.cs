
namespace Data.Interface
{
    interface IField
    {
        object Value { get; set; }
        IFieldDefinition FieldDefinition { get; }
    }
}
