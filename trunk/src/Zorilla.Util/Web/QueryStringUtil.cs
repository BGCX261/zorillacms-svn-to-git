using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Zorilla.Util.Strings;
using Hashtable=System.Collections.Hashtable;

namespace Zorilla.Util.Web
{
    public static class QueryStringUtil
    {
        public static Uri AddQueryParameter(this Uri uri, string key, string value)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (key == string.Empty) throw new ArgumentException("Key must have a value","key");

            uri = uri.RemoveQueryParameter(key);

            string s = uri.ToString();
            if (uri.Query.IsNullOrEmpty()) s += "?";
            else s += "&";

            return new Uri(s + key + "=" + value);
        }

        public static Uri RemoveQueryParameter(this Uri uri, string key)
        {
            UriBuilder builder = new UriBuilder(uri);
            builder.Query = null;
            Dictionary<string, string> query = ParseQueryString(uri.Query);
            if (key != null) query.Remove(key);
            builder.Query = QueryDictToString(query);
            return builder.Uri;
        }

        public static Dictionary<string, string> ParseQueryString(string qstring)
        {
            //simplify our task
            qstring = qstring + "&";
            //if (qstring.FirstChar() == '?') qstring = qstring.RemoveFirstChar();

            var outc = new Dictionary<string, string>();

            Regex r = new Regex(@"(?<name>[^=&]+)=(?<value>[^&]+)&", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            IEnumerator _enum = r.Matches(qstring).GetEnumerator();
            while (_enum.MoveNext() && _enum.Current != null)
            {
                string key = ((Match)_enum.Current).Result("${name}");
                if (key.First() == '?') key = key.RemoveFirstChar();
                outc.Add(key,((Match)_enum.Current).Result("${value}"));
            }

            return outc;
        }

        public static string QueryDictToString(Dictionary<string,string> dict)
        {
            string s = "";
            foreach (var k in dict.Keys)
            {
                s += k + "=" + dict[k] + "&";
            }
            return s.RemoveLastChar();
        }
    }
}