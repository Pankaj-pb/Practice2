using HRMTS.Chi.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HRMTS.Chi.Utilities
{
    public static class SqlUtils
    {
        public static int ExecuteNonQuery(string connectionString, string query, List<SqlParameter> sqlParameterList)
        {
            return ExecuteNonQuery(connectionString, query, sqlParameterList, CommandType.Text);
        }
        public static int ExecuteNonQuery(string connectionString, string query, List<SqlParameter> sqlParameterList, CommandType type)
        {
            using (var dbConnection = GetConnection(connectionString))
            {
                try
                {
                    using (var dbCommand = GetDbCommand(dbConnection, type, query, 30))
                    {
                        AddParametersToCommand(dbCommand, _ConvertToDBParameterList(sqlParameterList));
                        return dbCommand.ExecuteNonQuery();
                    }

                }
                finally
                {
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                }
            }

        }

        public static ChiDbDataReader GetDataReader(string connectionString, string query, List<SqlParameter> sqlParameterList)
        {
            return GetDataReader(connectionString, query, sqlParameterList, CommandType.Text);
        }
        public static ChiDbDataReader GetDataReader(string connectionString, string query, List<SqlParameter> sqlParameterList, CommandType type)
        {
            var chiSqlDataReader = new ChiDbDataReader(connectionString, query, type, _ConvertToDBParameterList(sqlParameterList));

            chiSqlDataReader.ExecuterReader();

            return chiSqlDataReader;
        }
        public static void AddParametersToCommand(DbCommand dbCommand, List<DbParameter> dbParamters)
        {
            if (dbCommand == null || dbParamters == null)
            {
                return;
            }
            dbParamters.ForEach(p =>
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
                dbCommand.Parameters.Add(p);
            });
        }
        private static List<DbParameter> _ConvertToDBParameterList(List<SqlParameter> sqlParameterList)
        {
            List<DbParameter> dbParameterList = new List<DbParameter>();
            if (sqlParameterList == null)
            {
                foreach (var parameter in sqlParameterList)
                {
                    var sqlParamter = new SqlParameter(parameter.ParameterName, parameter.SqlDbType) { Value = parameter.Value };
                    dbParameterList.Add(parameter);
                }

            }
            return dbParameterList;
        }
        public static DbCommand GetDbCommand(DbConnection connection, CommandType commandType, string commandText, int commandTimeout)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            var command = connection.CreateCommand();
            if (!string.IsNullOrEmpty(commandText))
            {
                command.CommandText = commandText;
            }
            command.CommandTimeout = commandTimeout;
            command.CommandType = commandType;
            return command;
        }
        public static DbConnection GetConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionstring");
            }

            var connection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();

            if (connection != null)
            {
                connection.ConnectionString = connectionString;

                connection.Open();
            }

            return connection;
        }
    }
}
