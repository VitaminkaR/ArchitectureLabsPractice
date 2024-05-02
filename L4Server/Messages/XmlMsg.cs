using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Messages
{
    public abstract class XmlMsg
    {
        public string Method;

        public abstract string GetXmlString();
        public abstract void GetXmlObject(string s);
        static public string GetMethod(string s)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(s);
            XmlElement? xRoot = xmlDocument.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    if(xnode.Name == "Method")
                        return xnode.InnerText;
                }
            }
            return "NoneMethod";
        }
    }
}
