using HRMTS.Chi.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace HRMTS.Chi.Tools
{
    public class ChiDbDataReader : ChiDisposable
    {
        private readonly DbConnection _connection;

        private readonly DbCommand _command;

        public DbDataReader Reader { get; private set; }

        public ChiDbDataReader(string connectionString, string query, List<DbParameter> parameterList)
            : this(connectionString, query, CommandType.Text, parameterList)
        { }
        public ChiDbDataReader(string connectionString, string query, CommandType commandType, List<DbParameter> parameterList)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("connectionString");
            }

            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException("query");
            }

            _connection = SqlUtils.GetConnection(connectionString);

            _command = SqlUtils.GetDbCommand(_connection, commandType, query, 30);

            SqlUtils.AddParametersToCommand(_command, parameterList);

            Reader = null;
        }
        public void ExecuterReader()
        {
            _command.ExecuteReader();
        }

        public bool Read()
        {
            return Reader != null && Reader.Read();
        }

        public bool NextResul()
        {
            return Reader != null && Reader.NextResult();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                return;
            }
            if (Reader != null)
            {
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                Reader.Dispose();
            }
            if (_command != null)
            {
                _command.Dispose();
            }
            if (_connection != null)
            {
                if (_connection.State != System.Data.ConnectionState.Closed)
                {
                    _connection.Close();
                }

                _connection.Dispose();
            }
        }
    }
}
