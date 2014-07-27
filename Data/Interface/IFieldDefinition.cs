namespace Data.Interface
{
    interface IFieldDefinition
    {
        string Name { get; }
        IFieldType Type { get; }
    }
}
