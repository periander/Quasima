using System;
using System.Runtime.InteropServices;
using Data.Generic.Concrete;
using Data.Interface;

namespace Data.Generic.Abstract
{
    public abstract class FieldDefinition : IFieldDefinition
    {
        internal FieldDefinition(string name,
            IFieldType type,
            bool nullable,
            int maxLength,
            int position
            )
        {
            Name = name;
            Type = type;
            Nullable = nullable;
            MaxLength = maxLength;
            Position = position;
        }

        public string Name { get; private set; }
        public IFieldType Type { get; private set; }
        public bool Nullable { get; private set; }
        public int MaxLength { get; private set; }
        public int Position { get; private set; }

    }
}
