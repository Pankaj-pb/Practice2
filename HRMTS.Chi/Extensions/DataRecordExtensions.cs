using HRMTS.Chi.Utilities;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Xml;

namespace HRMTS.Chi.Extensions
{
    /// <summary>
    /// Provides various extension methods for IDataReader
    /// </summary>
    public static class DataRecordExtensions
    {
        /// <summary>
        /// Constant indicating the column index that does not exists.
        /// </summary>
        public const int NonExistingColumnIndex = -1;

        /// <summary>
        /// Gets index of column in dataRecord column list.
        /// </summary>
        /// <param name="dataRecord">DataRecord</param>
        /// <param name="columnName">Name of column to be search in schema of <paramref name="dataRecord"/>.</param>
        /// <returns>Returns zero based index of colum if exists in reader schema. Returns -1 otherwise.</returns>
        public static int GetColumnIndex(this IDataRecord dataRecord, string columnName)
        {
            try
            {
                if (dataRecord != null)
                {
                    return dataRecord.GetOrdinal(columnName);
                }
            }
            catch (IndexOutOfRangeException)
            {
            }

            return NonExistingColumnIndex;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into integer.
        /// </summary>
        /// <remarks>Use this if required to throw exception on column name not found in <paramref name="dataRecord"/>.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name to having value to be converted to Integer.</param>
        /// <returns>Returns the integer representation of value in <paramref name="columnName"/>. Returns -1 if reading as integer was not possible.</returns>
        public static int ReadColumnAsInteger(this IDataRecord dataRecord, string columnName)
        {
            return dataRecord != null ? dataRecord.ReadColumnAsInteger(columnName, -1) : -1;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into integer.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to Integer.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the integer representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to integer was not possible.</returns>
        public static int ReadColumnAsInteger(this IDataRecord dataRecord, string columnName, int defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //  if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToInteger(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into long.
        /// </summary>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name to having value to be converted to long.</param>
        /// <returns>Returns the long representation of value in <paramref name="columnName"/>. Returns -1 if reading as long was not possible.</returns>
        public static long ReadColumnAsLong(this IDataRecord dataRecord, string columnName)
        {
            return dataRecord != null ? dataRecord.ReadColumnAsLong(columnName, -1) : -1;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into long.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to long.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the long representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to integer was not possible.</returns>
        public static long ReadColumnAsLong(this IDataRecord dataRecord, string columnName, long defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToLong(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into double.
        /// </summary>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to double.</param>
        /// <returns>Returns the double representation of value in <paramref name="columnName"/>. Returns -1 if reading as double was not possible.</returns>
        public static double ReadColumnAsDouble(this IDataRecord dataRecord, string columnName)
        {
            return dataRecord != null ? dataRecord.ReadColumnAsDouble(columnName, -1) : -1;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into double.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name to having value to be converted to double.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the double representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to integer was not possible.</returns>
        public static double ReadColumnAsDouble(this IDataRecord dataRecord, string columnName, double defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToDouble(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }


        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into byte[].
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to byte[].</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the byte[] representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to byte[] was not possible.</returns>
        public static byte[] ReadColumnAsByteArray(this IDataRecord dataRecord, string columnName, byte[] defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                int columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToByteArray(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into nullable integer.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to nullable integer.</param>
        /// <returns>Returns the nullable integer representation of value in <paramref name="columnName"/>. Returns null if reading as integer was not possible.</returns>
        public static int? ReadColumnAsIntegerNullable(this IDataRecord dataRecord, string columnName)
        {
            return dataRecord != null ? dataRecord.ReadColumnAsIntegerNullable(columnName, null) : null;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into nullable integer.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to nullable integer.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the nullable integer representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to integer was not possible.</returns>
        public static int? ReadColumnAsIntegerNullable(this IDataRecord dataRecord, string columnName, int? defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToIntNullable(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into nullable string.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to string.</param>
        /// <returns>Returns the string representation of value in <paramref name="columnName"/>. Returns EmptyString if reading as string was not possible.</returns>
        public static string ReadColumnAsString(this IDataRecord dataRecord, string columnName)
        {
            return dataRecord != null ? dataRecord.ReadColumnAsString(columnName, string.Empty) : string.Empty;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into string.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name to having value to be converted to string.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the string representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to string was not possible.</returns>
        public static string ReadColumnAsString(this IDataRecord dataRecord, string columnName, string defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToString(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into boolean.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to booolean.</param>
        /// <returns>Returns the boolean representation of value in <paramref name="columnName"/>. Returns false if reading as boolean was not possible.</returns>
        public static bool ReadColumnAsBoolean(this IDataRecord dataRecord, string columnName)
        {
            return dataRecord != null && dataRecord.ReadColumnAsBoolean(columnName, false);
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into boolean
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name to having value to be converted to boolean.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the boolean representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to boolean was not possible.</returns>
        public static bool ReadColumnAsBoolean(this IDataRecord dataRecord, string columnName, bool defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToBoolean(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into nullable boolean.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to boolean.</param>
        /// <returns>Returns the nullable boolean representation of value in <paramref name="columnName"/>. Returns null if reading as boolean was not possible.</returns>
        public static bool? ReadColumnAsBooleanNullable(this IDataRecord dataRecord, string columnName)
        {
            return dataRecord != null ? dataRecord.ReadColumnAsBooleanNullable(columnName, null) : null;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into nullable boolean
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name to having value to be converted to nullable boolean.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the nullable boolean representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to boolean was not possible.</returns>
        public static bool? ReadColumnAsBooleanNullable(this IDataRecord dataRecord, string columnName,
            bool? defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToBooleanNullable(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into datetime.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to datetime.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the datetime representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to datetime was not possible.</returns>
        public static DateTime ReadColumnAsDateTime(this IDataRecord dataRecord, string columnName,
            DateTime defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToDateTime(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into datetime.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to datetime.</param>
        /// <param name="dateTimeKind">Kind of <see cref="DateTime"/> being read. Applies only to the column being read and not to <paramref name="defaultValue"/>.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the datetime representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to datetime was not possible.</returns>
        public static DateTime ReadColumnAsDateTime(this IDataRecord dataRecord, string columnName,
            DateTimeKind dateTimeKind, DateTime defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToDateTime(value, dateTimeKind, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Reads the value in <paramref name="columnName"/> as <see cref="SqlDateTime"/>.
        /// </summary>
        /// <param name="dataRecord"><see cref="IDataRecord"/> to read the value from.</param>
        /// <param name="columnName">Name of the column to read.</param>
        /// <param name="defaultValue">Default value to return if column cannot be read.</param>
        /// <returns>Returns the column value as <see cref="SqlDateTime"/> or <paramref name="defaultValue"/> if column cannot be read.</returns>
        public static SqlDateTime ReadColumnAsSqlDateTime(this IDataRecord dataRecord, string columnName,
            SqlDateTime defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);

                if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];

                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToSqlDateTime(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into nullable datetime.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to datetime.</param>
        /// <returns>Returns the datetime representation of value in <paramref name="columnName"/>. Returns null if reading as datetime was not possible.</returns>
        public static DateTime? ReadColumnAsDateTimeNullable(this IDataRecord dataRecord, string columnName)
        {
            return dataRecord != null ? dataRecord.ReadColumnAsDateTimeNullable(columnName, null) : null;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into nullable datetime.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to datetime.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the datetime representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to datetime was not possible.</returns>
        public static DateTime? ReadColumnAsDateTimeNullable(this IDataRecord dataRecord, string columnName,
            DateTime? defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToDateTimeNullable(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into nullable datetime.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to datetime.</param>
        /// <param name="dateTimeKind">Kind type for the datatime.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the datetime representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to datetime was not possible.</returns>
        public static DateTime? ReadColumnAsDateTimeNullable(this IDataRecord dataRecord, string columnName, DateTimeKind dateTimeKind, DateTime? defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToDateTimeNullable(value, dateTimeKind, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into Guid.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having value to be converted to Guid.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the Guid representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to Guid was not possible.</returns>
        public static Guid ReadColumnAsGuid(this IDataRecord dataRecord, string columnName, Guid defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        return ConversionUtils.ToGuid(value, defaultValue);
                    }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into <see cref="XmlDocument"/>.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having xml value to be converted to XmlDocument.</param>        
        /// <returns>Returns the xml representation of value in <paramref name="columnName"/>. Returns null otherwise</returns>
        public static XmlDocument ReadColumnAsXml(this IDataRecord dataRecord, string columnName)
        {
            return dataRecord != null ? dataRecord.ReadColumnAsXml(columnName, null) : null;
        }

        /// <summary>
        /// Converts the given <paramref name="columnName"/> value into <see cref="XmlDocument"/>.
        /// </summary>
        /// <remarks>No exception is thrown.</remarks>
        /// <param name="dataRecord">System.Data.IDataRecord.</param>
        /// <param name="columnName">Column name having xml value to be converted to XmlDocument.</param>
        /// <param name="defaultValue">Default value returned if reading column value was not possible.</param>
        /// <returns>Returns the xml representation of value in <paramref name="columnName"/>. Returns <paramref name="defaultValue"/> if converting to xml was not possible.</returns>
        public static XmlDocument ReadColumnAsXml(this IDataRecord dataRecord, string columnName,
            XmlDocument defaultValue)
        {
            if (dataRecord != null && !string.IsNullOrWhiteSpace(columnName))
            {
                var columnIndex = dataRecord.GetColumnIndex(columnName);
                //  if (!columnIndex.Equals(NonExistingColumnIndex))
                {
                    var value = dataRecord[columnIndex];
                    if (value != DBNull.Value)
                    {
                        try
                        {
                            var xmlDocument = new XmlDocument();

                            xmlDocument.LoadXml(value.ToString());

                            return xmlDocument;
                        }
                        catch //overhead :(
                        {
                            return defaultValue;
                        }
                        
                    }
                }
            }

            return defaultValue;
        }
    }
}