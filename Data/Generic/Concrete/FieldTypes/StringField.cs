using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    public class StringField : FieldType<string>
    {
        public override string DatabaseTypeName { get { return "VARCHAR"; } }
    }
}
