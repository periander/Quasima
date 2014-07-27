namespace Data.Interface
{
    public interface IFieldDefinition
    {
        string Name { get; }
        IFieldType Type { get; }
    }
}
