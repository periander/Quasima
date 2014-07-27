using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using Data.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Generic.Concrete;
using Data.SqlServer2012.FieldTypes;

namespace Data.SqlServer2012
{
    public class Database : IDatabase
    {

        private SqlConnection _connection;

        public bool IsConnected
        {
            get { return _connection != null && _connection.State == ConnectionState.Open; }
        }

        public async Task<bool> Connect(CancellationToken ct, string connectionString = "")
        {
            if(_connection == null || !IsConnected)
            {
                _connection = string.IsNullOrEmpty(connectionString) ? new SqlConnection() : new SqlConnection(connectionString);
                await _connection.OpenAsync(ct);
            }
            return IsConnected;
        }


#pragma warning disable 1998
        public async Task<bool> Disconnect(CancellationToken ct)
#pragma warning restore 1998
        {
            if(_connection != null && IsConnected)
            {
                _connection.Close();
            }
            if(ct.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }
            return !IsConnected;
        }

        private readonly IList<ITableDefinition> _tables = new List<ITableDefinition>();
        private const int TableNameIndex = 2;
        private const int FieldNameIndex = 3;
        private const int FieldPosIndex = 4;
        private const int FieldDefaultValIndex = 5;
        private const int FieldIsNullableIndex = 6;
        private const int FieldDataTypeIndex = 7;
        private const int FieldMaxCharLengthIndex = 8;

#pragma warning disable 1998
        public async Task<IList<ITableDefinition>> GetTables(CancellationToken ct)
#pragma warning restore 1998
        {
            if (!_tables.Any())
            {
                var tables = _connection.GetSchema("Tables");
                foreach(DataRow tableSchemaRow in tables.Rows)
                {
                    if (ct.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }
                    var tableName = tableSchemaRow[TableNameIndex] as string;
                    var restrictions = new string[TableNameIndex + 1];
                    restrictions[TableNameIndex] = tableName;

                    var table = new Generic.Concrete.TableDefinition(tableName);

                    var tableSchema = _connection.GetSchema("Columns", restrictions);
                    foreach(DataRow fieldSchemaRow in tableSchema.Rows)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            throw new TaskCanceledException();
                        }
                        var fieldName = fieldSchemaRow[FieldNameIndex] as string;
                        var fieldPos = (fieldSchemaRow[FieldPosIndex] as int?).GetValueOrDefault();
                        var fieldDefaultVal = fieldSchemaRow[FieldDefaultValIndex];
                        var fieldIsNullable = (fieldSchemaRow[FieldIsNullableIndex] as string) == "YES";
                        var fieldDataTypeStr = fieldSchemaRow[FieldDataTypeIndex] as string;
                        var fieldMaxCharLength = (fieldSchemaRow[FieldMaxCharLengthIndex] as int?).GetValueOrDefault();
                        IFieldType fieldDataType = ValidFieldTypes.FirstOrDefault(fT => String.Equals(fT.DatabaseTypeName, fieldDataTypeStr, StringComparison.OrdinalIgnoreCase));

                        if(fieldDataType == null)
                        {
                            throw new Exception("Field type not supported.");
                        }
                        else
                        {
                            table.RowDefinition.Fields.Add(new FieldDefinition(fieldName, fieldDataType, fieldIsNullable, fieldMaxCharLength, fieldPos));
                        }
                    }

                    _tables.Add(table);
                }
            }
            if (ct.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }
            return _tables;
        }

        private readonly IList<IFieldType> _validFieldTypes = new IFieldType[]
        {
            new Generic.Concrete.FieldTypes.IntegerField(), 
            new Generic.Concrete.FieldTypes.StringField(), 
            new GuidField(), 
            new DoubleField(), 
            new DateTimeField(),
            new BooleanField()
        };
        public IList<IFieldType> ValidFieldTypes { get { return _validFieldTypes; } }
    }
}
