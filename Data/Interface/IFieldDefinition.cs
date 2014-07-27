namespace Data.Interface
{
    public interface IFieldDefinition
    {
        string Name { get; }
        IFieldType Type { get; }
        bool Nullable { get; }
        int MaxLength { get; }
        int Position { get; }
    }
}
