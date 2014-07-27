namespace Data.SqlServer2012.FieldTypes
{
    class DoubleField : Generic.Concrete.FieldTypes.DoubleField
    {
        public override string DatabaseTypeName { get { return "FLOAT"; } }
    }
}
