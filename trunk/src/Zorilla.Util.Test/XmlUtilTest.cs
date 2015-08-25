using System;
using NUnit.Framework;
using Zorilla.Util.Xml;

namespace Zorilla.Util.Test
{
    [TestFixture]
    public class XmlUtilTest
    {
        public class MyClass {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        [Test]
        public void SerializeEntity() {
            string s = XmlUtil.Serialize(new MyClass {Name = "name", Value = 3});
            string xml =
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>" + "\n" +
                "<MyClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n" +
                "  <Name>name</Name>\n" +
                "  <Value>3</Value>\n" +
                "</MyClass>";
            Assert.AreEqual(xml,s.Replace("\r",""),"Xml should match");
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void SerializeEntityWhenNull()
        {
            XmlUtil.Serialize(null);
        }

    }
}