namespace Data.SqlServer2012.FieldTypes
{
    class BooleanField : Generic.Concrete.FieldTypes.BooleanFieldType
    {
        public override string DatabaseTypeName { get { return "BIT"; } }
    }
}
