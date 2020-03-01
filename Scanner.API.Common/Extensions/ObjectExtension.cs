using System;
using System.Globalization;

namespace Scanner.API.Common.Extensions {
    public static class ObjectExtension {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NullCheck(this object obj, string message) {
            if (obj == null)
                throw new ArgumentNullException(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentException"></exception>
        public static void TypeCheck<T>(this object obj, string message) {
            if (obj.GetType() != typeof(T))
                throw new ArgumentException(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToStringSafe(this object obj) {
            return obj == null ? string.Empty : obj.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeSafe(this object obj) {
            DateTime tryParseDate;
            DateTime.TryParse(obj.ToStringSafe(), out tryParseDate);
            return tryParseDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeSafe(this object obj, IFormatProvider format) {
            DateTime tryParseDate;
            DateTime.TryParse(obj.ToStringSafe(), format, DateTimeStyles.None, out tryParseDate);
            return tryParseDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="formats"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeSafe(this object obj, string[] formats) {
            DateTime tryParseDate;
            DateTime.TryParseExact(obj.ToStringSafe(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out tryParseDate);
            return tryParseDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime FromOaDateSafe(this object obj) {
            var oleDateTime = obj.ToDoubleSafe();

            if (oleDateTime <= 0) {
                return DateTime.MinValue;
            }

            // Get the converted date from the OLE automation date.
            var tryParseDate = DateTime.FromOADate(oleDateTime);

            return tryParseDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDoubleSafe(this object obj) {
            double tryParseVal;
            double.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimalSafe(this object obj) {
            decimal tryParseVal;
            decimal.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ToLongSafe(this object obj) {
            long tryParseVal;
            long.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToIntSafe(this object obj) {
            int tryParseVal;
            int.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt16Safe(this object obj) {
            short tryParseVal;
            short.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBoolSafe(this object obj) {
            bool tryParseVal;
            bool.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        public static Guid ToGuidSafe(this object obj) {
            Guid tryParseVal;
            Guid.TryParse(obj.ToStringSafe(), out tryParseVal);
            return tryParseVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T? ToNullableValue<T>(this object obj) where T : struct {
            try {
                return (T)Convert.ChangeType(obj, typeof(T));
            } catch {
                return null;
            }
        }
    }
}
