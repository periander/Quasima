using System;
using Data.Generic.Abstract;

namespace Data.Generic.Concrete.FieldTypes
{
    class DateTimeField : FieldType<DateTime>
    {
        /// <summary>
        /// Note this is just a generic implementation. For example, SQL Server 2008 onwards should use DATETIME2.
        /// </summary>
        public override string DatabaseTypeName { get { return "DATETIME"; } }
    }
}
