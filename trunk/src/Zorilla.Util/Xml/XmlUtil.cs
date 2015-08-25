using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Zorilla.Util.Xml
{
    public static class XmlUtil
    {
        /// <summary>
        /// XML serialize object to string.
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <exception cref="ArgumentNullException">obj must be specified</exception>
        public static string Serialize(object obj) {
            if (obj == null) throw new ArgumentNullException("obj");

            var sb = new StringBuilder();
            var settings = new XmlWriterSettings();

            settings.Indent = true;
            settings.OmitXmlDeclaration = false;

            using (XmlWriter w = XmlWriter.Create(sb, settings)) {
                var serializer = new XmlSerializer(obj.GetType());
                if (w != null) serializer.Serialize(w, obj);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Deserialize XmlNode/XmlDocument to object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(XmlNode xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            T val = (T)serializer.Deserialize(new XmlNodeReader(xml));
            return val;
        }
    }
}