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

        private string _name = string.Empty;
        public string Name { get { return _name; } set { _name = string.IsNullOrEmpty(value) ? string.Empty : value; } }
        public IFieldType Type { get; private set; }
        public bool Nullable { get; private set; }
        public int MaxLength { get; private set; }
        public int Position { get; private set; }

    }
}
