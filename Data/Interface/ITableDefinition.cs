
namespace Data.Interface
{
    public interface ITableDefinition
    {
        string Name { get; }
        IRowDefinition RowDefinition { get; }
    }
}
