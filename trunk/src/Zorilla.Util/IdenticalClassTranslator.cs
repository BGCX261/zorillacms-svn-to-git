using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Zorilla.Util
{
    /// <summary>
    /// Util class used to translate identical classes in different namespaces.
    /// 
    /// Especially useful for translating automatically generated classes using XSD or
    /// generated in web-service references, where classes are often identical but placed
    /// in different namespaces.
    /// </summary>
    public class IdenticalClassTranslator
    {
        /// <summary>
        /// Translates the from object into type T
        /// </summary>
        /// <typeparam name="T">Return parameter type</typeparam>
        /// <param name="from">Object to translate</param>
        /// <returns>Translated object</returns>
        public static T Translate<T>(object from) where T : class, new()
        {
            return (T)Translate(from, typeof(T));
        }

        public static T Translate<S, T>(S from) where T : class, new()
        {
            return (T)Translate(from, typeof(T));
        }

        private static object Translate(object from, Type toType)
        {
            if (from == null)
                return null;

            Type fromType = from.GetType();

            if (toType.IsArray)
                return TranslateArray((object[])from, toType);

            if (toType.IsEnum)
            {
                int val = (int)from;
                return val;
            }

            object to = toType.GetConstructor(Type.EmptyTypes).Invoke(null);

            foreach (PropertyInfo pi in fromType.GetProperties())
            {
                MethodInfo get = pi.GetGetMethod();
                MethodInfo set = pi.GetSetMethod();
                if (pi.IsSpecialName || get == null || set == null || !get.IsPublic || !set.IsPublic || get.IsStatic || set.IsStatic) continue;

                PropertyInfo tPi = toType.GetProperty(pi.Name);
                if (tPi == null)
                    throw new ArgumentException(fromType.Name + " is not identical to " + toType.Name);

                if (pi.CanRead && tPi.CanWrite)
                {
                    if (tPi.PropertyType.IsAssignableFrom(pi.PropertyType))
                        tPi.SetValue(to, pi.GetValue(from, null), null);
                    else
                        tPi.SetValue(to, Translate(pi.GetValue(from, null), tPi.PropertyType), null);
                }
            }

            foreach (FieldInfo fi in fromType.GetFields())
            {
                if (fi.IsSpecialName || !fi.IsPublic || fi.IsStatic) continue;

                FieldInfo tFi = toType.GetField(fi.Name);
                if (tFi == null)
                    throw new ArgumentException(fromType.Name + " is not identical to " + toType.Name);

                tFi.SetValue(to, fi.GetValue(from));
            }

            return to;
        }

        public static T[] TranslateArray<T>(object[] from) where T : class, new()
        {
            if (from == null) return null;
            T[] to = new T[from.Length];
            for (int i = 0; i < from.Length; i++)
            {
                to[i] = Translate<T>(from[i]);
            }
            return to;
        }

        public static object TranslateArray(object[] from, Type toType)
        {
            if (from == null) return null;
            var to = (object[])toType.GetConstructor(new[] { typeof(int) }).Invoke(new object[] { from.Length });

            for (int i = 0; i < from.Length; i++)
                to[i] = Translate(from[i], toType.GetElementType());

            return to;
        }

        public static List<T> TranslateList<S, T>(List<S> from) where T : class, new()
        {
            return from.ConvertAll<T>(Translate<S, T>);
        }
    }
}