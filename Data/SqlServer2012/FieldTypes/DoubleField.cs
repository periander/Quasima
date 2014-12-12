namespace Data.SqlServer2012.FieldTypes
{
    class DoubleField : Generic.Concrete.FieldTypes.DoubleFieldType
    {
        public override string DatabaseTypeName { get { return "FLOAT"; } }
    }
}
