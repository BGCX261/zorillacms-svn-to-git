using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Zorilla.Util
{
    public static class NullableUtil {

        /// <summary>
        /// Returns the nullable conversion where the default value is converted to null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T? ToNullable<T>(this T t) where T : struct {
            return t.Equals(default(T)) ? new T?() : t;
        }
    }
}