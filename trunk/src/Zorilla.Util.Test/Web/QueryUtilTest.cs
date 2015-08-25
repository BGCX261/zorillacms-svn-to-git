using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Zorilla.Util.Web;

namespace Zorilla.Util.Test.Web
{
    [TestFixture]
    public class QueryUtilTest
    {
        [Test]
        public void Add_Query_Parameter_Without_Query_Before()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp");
            Assert.AreEqual("http://address.url/path/to/page.asp?added=value",uri.AddQueryParameter("added","value").ToString());
            
        }

        [Test]
        public void Add_Query_Parameter_With_Query_Before()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp?query=value");
            Assert.AreEqual("http://address.url/path/to/page.asp?query=value&added=value", uri.AddQueryParameter("added", "value").ToString());
        }

        [Test,ExpectedException(typeof(ArgumentNullException))]
        public void Add_Parameter_Null_Key()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp?query=value");
            uri.AddQueryParameter(null, "val");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Add_Parameter_Empty_Key()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp?query=value");
            uri.AddQueryParameter("", "val");
        }

        [Test]
        public void Change_Parameter()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp?query=value");
            Uri uri2 = new Uri("http://address.url/path/to/page.asp?query=value2");
            Assert.AreEqual(uri2,uri.AddQueryParameter("query", "value2"));
        }

        [Test]
        public void Remove_Query_Parameter_When_One_Parameter()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp?query=value");
            Assert.AreEqual("http://address.url/path/to/page.asp",uri.RemoveQueryParameter("query").ToString());
        }

        [Test]
        public void Remove_Query_Parameter_When_Two_Query_Parameters()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp?query=value&query2=value2");
            Assert.AreEqual("http://address.url/path/to/page.asp?query2=value2", uri.RemoveQueryParameter("query").ToString());
            Assert.AreEqual("http://address.url/path/to/page.asp?query=value", uri.RemoveQueryParameter("query2").ToString());
            
            Assert.AreEqual("http://address.url/path/to/page.asp", 
                uri.RemoveQueryParameter("query").RemoveQueryParameter("query2").ToString());
        }

        [Test]
        public void Remove_Parameter_That_Does_Not_Exist()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp?query=value&query2=value2");
            Assert.AreEqual(uri,uri.RemoveQueryParameter("badkey"));
        }

        [Test]
        public void Remove_Query_Parameter_When_No_Query_Parameter_Exists()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp");
            Assert.AreEqual(uri, uri.RemoveQueryParameter("badkey"));
        }

        [Test]
        public void Remove_Query_Parameter_With_Empty_Key()
        {
            Uri uri = new Uri("http://address.url/path/to/page.asp");
            Assert.AreEqual(uri, uri.RemoveQueryParameter(null));
            Assert.AreEqual(uri, uri.RemoveQueryParameter(""));
        }
    }
}
