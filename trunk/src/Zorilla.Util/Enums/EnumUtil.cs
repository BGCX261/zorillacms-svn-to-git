using System;

namespace Zorilla.Util.Enums
{
    public static class EnumUtil 
    {

        /// <summary>
        /// Parses the specified enumeration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumAsString"></param>
        /// <returns></returns>
        public static T Parse<T>(this string enumAsString) where T : struct, IComparable, IFormattable, IConvertible 
        {
            return Parse<T>(enumAsString, true);
        }

        /// <summary>
        /// Parses the specified enumeration with the option to ignore case.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumAsString"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T Parse<T>(this string enumAsString, bool ignoreCase) where T : struct, IComparable, IFormattable, IConvertible 
        {
            try {
                return (T) Enum.Parse(typeof (T), enumAsString, ignoreCase);
            }
            catch (Exception e) {
                throw new ArgumentException(
                    "Unable to parse \"" + enumAsString + "\" as enum type \"" + typeof (T) + "\" (ignoreCase=" +
                    ignoreCase + ").", e);
            }
        }

        /// <summary>
        /// Parses the specified enumeration. If value cannot be parsed, the default enumaration value is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumAsString"></param>
        /// <returns></returns>
        public static T ParseOrDefault<T>(this string enumAsString) where T : struct, IComparable, IFormattable, IConvertible 
        {
            return enumAsString != null && Enum.IsDefined(typeof(T), enumAsString) ? Parse<T>(enumAsString) : default(T);
        }
    }
}