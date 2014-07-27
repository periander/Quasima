﻿using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interface;

namespace Data.Generic.Concrete
{
    class RowDefinition : IRowDefinition
    {
        private readonly IList<IFieldDefinition> _fields = new List<IFieldDefinition>();
        public IList<IFieldDefinition> Fields { get { return _fields; } }
    }
}
