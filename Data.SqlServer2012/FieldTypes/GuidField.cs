namespace Data.SqlServer2012.FieldTypes
{
    class GuidField : Generic.Concrete.FieldTypes.GuidField
    {
        public override string DatabaseTypeName { get { return "UNIQUEIDENTIFIER"; } }
    }
}
