using System.Collections.Generic;

namespace Data.Interface
{
    public interface IRowDefinition
    {
        IList<IFieldDefinition> Fields { get; }
    }
}
