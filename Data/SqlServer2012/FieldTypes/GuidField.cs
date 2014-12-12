namespace Data.SqlServer2012.FieldTypes
{
    class GuidField : Generic.Concrete.FieldTypes.GuidFieldType
    {
        public override string DatabaseTypeName { get { return "UNIQUEIDENTIFIER"; } }
    }
}
