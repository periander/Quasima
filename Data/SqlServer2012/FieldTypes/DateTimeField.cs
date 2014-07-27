namespace Data.SqlServer2012.FieldTypes
{
    class DateTimeField : Generic.Concrete.FieldTypes.DateTimeField
    {
        public override string DatabaseTypeName { get { return "DATETIME2"; } }
    }
}
