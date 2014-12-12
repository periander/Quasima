namespace Data.SqlServer2012.FieldTypes
{
    class DateTimeField : Generic.Concrete.FieldTypes.DateTimeFieldType
    {
        public override string DatabaseTypeName { get { return "DATETIME2"; } }
    }
}
