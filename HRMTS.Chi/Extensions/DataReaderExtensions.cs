using HRMTS.Chi.Utilities;
using System;
using System.Data;

namespace HRMTS.Chi.Extensions
{
    /// <summary>
    /// Provides various extension methods for IDataReader
    /// </summary>
    public static class DataReaderExtensions
    {
        /// <summary>
        /// Constant representation of index of a non-existing column.
        /// </summary>
        public const int NonExistingColumnIndex = -1;

        /// <summary>
        /// Checks if the specified column exists in <paramref name="dataReader"/>.
        /// </summary>
        /// <param name="dataReader"><see cref="IDataReader"/> to check the column in.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>Returns <c>true</c> if the column exists, <c>false</c> otherwise</returns>
        /// <remarks>The function does not throw any exceptions.</remarks>
        public static bool ColumnExists(this IDataReader dataReader, string columnName)
        {
            // Note! The methods used in this function are supposed to be the fastest that exist
            // and do not throw exceptions.

            if (dataReader != null && !string.IsNullOrWhiteSpace(columnName))
            {
                for (var ix = 0; ix < dataReader.FieldCount; ix++)
                {
                    if (String.Compare(dataReader.GetName(ix), columnName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        ///// <summary>
        ///// Returns the index of the specified column in the <paramref name="dataReader"/>.
        ///// </summary>
        ///// <param name="dataReader"><see cref="IDataReader"/> to get the column index from.</param>
        ///// <param name="columnName">Name of the column.</param>
        ///// <returns>Returns zero-based index of column if it exists in <paramref name="dataReader"/>, <see cref="NonExistingColumnIndex"/> otherwise.</returns>
        ///// <remarks>The function does not throw any exceptions.</remarks>
        public static int GetColumnIndex(this IDataReader dataReader, string columnName)
        {
            return dataReader.ColumnExists(columnName) ? _GetColumnIndex(dataReader, columnName) : NonExistingColumnIndex;
        }

        ///// <summary>
        ///// Returns the index of the specified column in the <paramref name="dataRecord"/>.
        ///// </summary>
        ///// <param name="dataRecord"><see cref="IDataReader"/> to get the column index from.</param>
        ///// <param name="columnName">Name of the column.</param>
        ///// <returns>Returns zero-based index of column if it exists in <paramref name="dataRecord"/>, <see cref="NonExistingColumnIndex"/> otherwise.</returns>
        ///// <exception cref="NullReferenceException">Thrown when <paramref name="dataRecord"/> is null.</exception>
        ///// <exception cref="IndexOutOfRangeException">Thrown when the <paramref name="columnName"/> does not exist in <see cref="IDataReader"/>.</exception>
        private static int _GetColumnIndex(IDataRecord dataRecord, string columnName)
        {
            return dataRecord.GetOrdinal(columnName);
        }

        ///// <summary>
        ///// Returns the integer representation of the specified column in <see cref="IDataReader"/>.
        ///// </summary>
        ///// <param name="dataReader"><see cref="IDataReader"/> to read the column value from.</param>
        ///// <param name="columnName">Name of the column having the value to be converted.</param>
        ///// <returns>Returns integer representation of <paramref name="columnName"/> or -1 if conversion or reading was not possible.</returns>
        ///// <remarks>The function does not throw any exceptions.</remarks>
        public static int ReadColumnAsInteger(this IDataReader dataReader, string columnName)
        {
            return dataReader.ReadColumnAsInteger(columnName, -1);
        }

        ///// <summary>
        ///// Returns the integer representation of the specified column in <see cref="IDataReader"/>.
        ///// </summary>
        ///// <param name="dataReader"><see cref="IDataReader"/> to read the column value from.</param>
        ///// <param name="columnName">Name of the column having the value to be converted.</param>
        ///// <param name="defaultValue">Default value to return if the specified column does not exist or cannot be converted.</param>
        ///// <returns>Returns integer representation of <paramref name="columnName"/> or <paramref name="defaultValue"/> if conversion or reading was not possible.</returns>
        ///// <remarks>The function does not throw any exceptions.</remarks>
        public static int ReadColumnAsInteger(this IDataReader dataReader, string columnName, int defaultValue)
        {
            if (!dataReader.ColumnExists(columnName))
            {
                return defaultValue;
            }

            var columnIndex = _GetColumnIndex(dataReader, columnName);

            //if (columnIndex.Equals(NonExistingColumnIndex))
            //{
            //    return defaultValue;
            //}

            var value = dataReader[columnIndex];

            return value.Equals(DBNull.Value) ? defaultValue : ConversionUtils.ToInteger(value, defaultValue);
        }
    }
}