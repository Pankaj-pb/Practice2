using System;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Xml;

namespace HRMTS.Chi.Utilities
{
    /// <summary>
    /// Provides various conversion methods.
    /// </summary>
    public static class ConversionUtils
    {
        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static decimal ToDecimal(object value, decimal defaultValue)
        {
            return value != null
                       ? ToDecimal(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static decimal ToDecimal(string value, decimal defaultValue)
        {
            decimal convertedValue;

            return decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="short"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static short ToShort(object value, short defaultValue)
        {
            return value != null
                       ? ToShort(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="short"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static short ToShort(string value, short defaultValue)
        {
            short convertedValue;

            return short.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="int"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static int ToInteger(object value, int defaultValue)
        {
            return value != null
                       ? ToInteger(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="int"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static int ToInteger(string value, int defaultValue)
        {
            int convertedValue;

            return int.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="long"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static long ToLong(object value, long defaultValue)
        {
            return value != null
                       ? ToLong(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="long"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static long ToLong(string value, long defaultValue)
        {
            long convertedValue;

            return long.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static float ToFloat(object value, float defaultValue)
        {
            return value != null
                       ? ToFloat(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static float ToFloat(string value, float defaultValue)
        {
            float convertedValue;

            return float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static double ToDouble(object value, double defaultValue)
        {
            return value != null
                       ? ToDouble(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static double ToDouble(string value, double defaultValue)
        {
            double convertedValue;

            return double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see>
        ///                                      <cref>int?</cref>
        ///                                    </see> .
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static int? ToIntNullable(object value, int? defaultValue)
        {
            return value != null
                       ? ToIntNullable(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see>
        ///                                      <cref>int?</cref>
        ///                                    </see> .
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static int? ToIntNullable(string value, int? defaultValue)
        {
            int convertedValue;

            return int.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static string ToString(object value, string defaultValue)
        {
            var convertedValue = value != null
                       ? Convert.ToString(value, CultureInfo.InvariantCulture)
                       : string.Empty;

            return !string.IsNullOrWhiteSpace(convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="bool"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static bool ToBoolean(object value, bool defaultValue)
        {
            return value != null
                       ? ToBoolean(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="bool"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static bool ToBoolean(string value, bool defaultValue)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                switch (value.ToUpperInvariant())
                {
                    case "YES":
                    case "TRUE":
                    case "ON":
                    case "ENABLE":
                    case "ENABLED":
                    case "OK":
                    case "1":
                        return true;

                    case "NO":
                    case "FALSE":
                    case "OFF":
                    case "DISABLE":
                    case "DISABLED":
                    case "CANCEL":
                    case "0":
                        return false;
                }
            }

            bool convertedValue;

            return bool.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }


        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="bool?"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static bool? ToBooleanNullable(object value, bool? defaultValue)
        {
            return value != null
                       ? ToBooleanNullable(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="bool?"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static bool? ToBooleanNullable(string value, bool? defaultValue)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                switch (value.ToUpperInvariant())
                {
                    case "YES":
                    case "TRUE":
                    case "ON":
                    case "ENABLE":
                    case "ENABLED":
                    case "OK":
                    case "1":
                        return true;
                }
            }

            bool convertedValue;

            return bool.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static DateTime ToDateTime(object value, DateTime defaultValue)
        {
            return value != null
                       ? ToDateTime(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="DateTime"/>.
        /// </summary>
        ///<param name="value">String value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static DateTime ToDateTime(string value, DateTime defaultValue)
        {
            //DateTime utc = DateTime.SpecifyKind(, DateTimeKind.Utc);
            DateTime convertedValue;

            return DateTime.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="dateTimeKind">Kind of <see cref="DateTime"/> being read. Applies only to <paramref name="value"/> and not to <paramref name="defaultValue"/>.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static DateTime ToDateTime(object value, DateTimeKind dateTimeKind, DateTime defaultValue)
        {
            return value != null
                       ? ToDateTime(value.ToString(), dateTimeKind, defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="DateTime"/>.
        /// </summary>
        ///<param name="value">String value to be converted.</param>
        /// <param name="dateTimeKind">Kind of <see cref="DateTime"/> being read. Applies only to <paramref name="value"/> and not to <paramref name="defaultValue"/>.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static DateTime ToDateTime(string value, DateTimeKind dateTimeKind, DateTime defaultValue)
        {
            DateTime convertedValue;

            return DateTime.TryParse(value, out convertedValue)
                       ? DateTime.SpecifyKind(convertedValue, dateTimeKind)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="formatProvider">Culture-specific formatting information.</param>
        /// <param name="dateTimeStyles">A bit-wise combination of different date time styles.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static DateTime ToDateTime(object value, IFormatProvider formatProvider, DateTimeStyles dateTimeStyles, DateTime defaultValue)
        {
            return value != null
                       ? ToDateTime(value.ToString(), formatProvider, dateTimeStyles, defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="DateTime"/>.
        /// </summary>
        ///<param name="value">String value to be converted.</param>
        /// <param name="formatProvider">Culture-specific formatting information.</param>
        /// <param name="dateTimeStyles">A bit-wise combination of different date time styles.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static DateTime ToDateTime(string value, IFormatProvider formatProvider, DateTimeStyles dateTimeStyles, DateTime defaultValue)
        {
            DateTime convertedValue;

            return DateTime.TryParse(value, formatProvider, dateTimeStyles, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="SqlDateTime"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static SqlDateTime ToSqlDateTime(object value, SqlDateTime defaultValue)
        {
            return value != null
                       ? ToSqlDateTime(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="SqlDateTime"/>.
        /// </summary>
        ///<param name="value">String value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        

        /// <summary>
        /// Converts <paramref name="value"/> to <see>
        ///                                      <cref>DateTime?</cref>
        ///                                    </see> .
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static DateTime? ToDateTimeNullable(object value, DateTime? defaultValue)
        {
            return value != null
                       ? ToDateTimeNullable(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see>
        ///                                      <cref>DateTime?</cref>
        ///                                    </see> .
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static DateTime? ToDateTimeNullable(string value, DateTime? defaultValue)
        {
            DateTime convertedValue;

            return DateTime.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see>
        ///                                      <cref>DateTime?</cref>
        ///                                    </see> .
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="dateTimeKind">Kind type for the datatime.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static DateTime? ToDateTimeNullable(object value, DateTimeKind dateTimeKind, DateTime? defaultValue)
        {
            DateTime? convertedValue;

            convertedValue = ToDateTimeNullable(value, defaultValue);

            if (convertedValue.HasValue)
            {
                convertedValue = DateTime.SpecifyKind(convertedValue.Value, dateTimeKind);
            }

            return convertedValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="value"/>. If <paramref name="formatProvider"/> is null, the thread current culture is used.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static TimeSpan ToTimeSpan(object value, IFormatProvider formatProvider, TimeSpan defaultValue)
        {
            return value != null
                       ? ToTimeSpan(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static TimeSpan ToTimeSpan(object value, TimeSpan defaultValue)
        {
            return value != null
                       ? ToTimeSpan(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="value"/>. If <paramref name="formatProvider"/> is null, the thread current culture is used.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static TimeSpan ToTimeSpan(string value, IFormatProvider formatProvider, TimeSpan defaultValue)
        {
            TimeSpan convertedValue;

            return TimeSpan.TryParse(value, formatProvider, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static TimeSpan ToTimeSpan(string value, TimeSpan defaultValue)
        {
            TimeSpan convertedValue;

            return TimeSpan.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static Guid ToGuid(object value, Guid defaultValue)
        {
            return value != null
                       ? ToGuid(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static Guid ToGuid(string value, Guid defaultValue)
        {
            Guid convertedValue;

            return Guid.TryParse(value, out convertedValue)
                       ? convertedValue
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to array of <see cref="byte"/>.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static byte[] ToByteArray(object value, byte[] defaultValue)
        {
            return value != null
                       ? (byte[])value
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="stream"/> to array of <see cref="byte"/>.
        /// </summary>
        /// <param name="stream"><see cref="Stream"/> to convert.</param>
        /// <param name="defaultValue">Default value to returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="stream"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static byte[] ToByteArray(Stream stream, byte[] defaultValue)
        {
            if (stream == null)
            {
                return defaultValue;
            }

            var buffer = new byte[16 * 1024];

            using (var memoryStream = new MemoryStream())
            {
                int read;

                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, read);
                }

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of enumerator to convert to.</typeparam>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static T ToEnum<T>(object value, T defaultValue) where T : struct
        {
            return value != null
                       ? ToEnum(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of enumerator to convert to.</typeparam>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static T ToEnum<T>(string value, T defaultValue) where T : struct
        {
            T convertedValue;

            if (Enum.TryParse(value, true, out convertedValue))
            {
                if (Enum.IsDefined(typeof(T), convertedValue) | convertedValue.ToString().Contains(","))
                {
                    return convertedValue;
                }

                // If here, then "value" was a number, but it did not match with any enum value.
            }

            // If here, then "value" was some string, but it did not match with any enum name.

            return defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="Enum"/>.
        /// </summary>
        /// <remarks>
        /// Uses explicit try-catch and, therefore, might be a little slower if exception is thrown and caught.
        /// </remarks>
        /// <typeparam name="T">The type of enumerator to convert to.</typeparam>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static T ToEnumEx<T>(object value, T defaultValue)
        {
            return value != null
                       ? ToEnumEx(value.ToString(), defaultValue)
                       : defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="Enum"/>.
        /// </summary>
        /// <remarks>
        /// Uses explicit try-catch and, therefore, might be a little slower if exception is thrown and caught.
        /// </remarks>
        /// <typeparam name="T">The type of enumerator to convert to.</typeparam>
        /// <param name="value">Value to be converted.</param>
        /// <param name="defaultValue">Default value to be returned if conversion fails.</param>
        /// <returns>Returns successful conversion of <paramref name="value"/> or <paramref name="defaultValue"/> if conversion was not possible.</returns>
        public static T ToEnumEx<T>(string value, T defaultValue)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var convertedValue = (T)Enum.Parse(typeof(T), value);

                    if (Enum.IsDefined(typeof(T), convertedValue) | convertedValue.ToString().Contains(","))
                    {
                        return convertedValue;
                    }
                }
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            return defaultValue;
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Base36 <see cref="string"/>.
        /// </summary>
        /// <param name="value">The 64-bit signed integer to be converted.</param>
        /// <returns>Returns Base36 string representation of <paramref name="value"/></returns>
        public static string ToBase36String(long value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value", value, "Value cannot be negative.");
            }

            char[] base36 = { '0','1','2','3','4','5','6','7','8','9','A',
                              'B','C','D','E','F','G','H','I','J','K','L',
                              'M','N','O','P','Q','R','S','T','U','V','W',
                              'X','Y','Z'};

            string encoded = String.Empty;

            do
            {
                encoded = base36[(int)(value % base36.Length)] + encoded;
            } while ((value /= base36.Length) > 0);

            return encoded;
        }

        /// <summary>
        /// Gets a class object and returns the XML representation of its all properties excluding properties with Null values and excluding XML declaration node
        /// <remarks>This will not create xml of sub-objects</remarks>
        /// </summary>
        /// <param name="classObject">Object to be converted to Xml</param>
        /// <returns>Xml string representation of <paramref name="classObject"/></returns>
        public static string ToXml(object classObject)
        {
            return ToXml(classObject, false);
        }

        /// <summary>
        /// Gets a class object and returns the XML representation of its all properties excluding properties with Null values.
        /// <remarks>This will not create xml of sub-objects</remarks>
        /// </summary>
        /// <param name="classObject">Object to be converted to Xml</param>
        /// <param name="includeXmlDeclaration">Whether to include xml declaration node or not</param>
        /// <returns>Xml string representation of <paramref name="classObject"/></returns>
        public static string ToXml(object classObject, bool includeXmlDeclaration)
        {
            var xmlDocument = new XmlDocument();

            var type = classObject.GetType();

            if (includeXmlDeclaration)
            {
                //creates node <?xml version="1.0" encoding="<smthing>"?>
                var xmlDeclaration = xmlDocument.CreateNode(XmlNodeType.XmlDeclaration, null, null);

                xmlDocument.AppendChild(xmlDeclaration);
            }

            var xmlRoot = xmlDocument.CreateElement(type.Name);

            xmlDocument.AppendChild(xmlRoot);

            var properties = type.GetProperties();

            foreach (var pInfo in properties)
            {
                var propertyValue = pInfo.GetValue(classObject, null);

                if (propertyValue != null)
                {
                    var subElement = xmlDocument.CreateElement(pInfo.Name);

                    subElement.InnerText = propertyValue.ToString();

                    xmlRoot.AppendChild(subElement);
                }
            }

            return xmlDocument.OuterXml;
        }
    }
}