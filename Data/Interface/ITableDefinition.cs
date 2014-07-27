﻿using System.Collections.Generic;

namespace Data.Interface
{
    public interface ITableDefinition
    {
        string Name { get; }
        IRowDefinition RowDefinitions { get; }
    }
}
