using System;
using System.Collections;
using System.Text;

namespace Zorilla.Util.Collections
{
    ///<summary>
    ///</summary>
    public class CollectionUtil
    {
        ///<summary>
        /// Convert elements in collection to string, by using
        /// the elements ToString() method.
        ///</summary>
        ///<param name="collection"></param>
        ///<returns></returns>
        public static string ToString(IEnumerable collection)
        {
            if (collection == null) return null;
            StringBuilder sb = new StringBuilder("[");
            foreach (var elem in collection)
            {
                sb.Append(elem.ToString());
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        ///<summary>
        /// Resize array and add element to array.
        ///</summary>
        ///<param name="array"></param>
        ///<param name="newElem"></param>
        ///<typeparam name="T"></typeparam>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        public static T[] Add<T>(T[] array, T newElem)
        {
            if (array == null) throw new ArgumentNullException();
            Array.Resize(ref array,array.Length + 1);
            array[array.Length - 1] = newElem;
            return array;
        }
    }
}