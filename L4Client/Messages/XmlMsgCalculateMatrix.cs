using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Messages
{
    public class XmlMsgRequestCalculateMatrix : XmlMsg
    {
        public List<int> Matrix;

        public XmlMsgRequestCalculateMatrix()
        {
        }

        public XmlMsgRequestCalculateMatrix(List<int> matrix)
        {
            Method = "CalculateMatrix";
            Matrix = matrix;
        }

        public override void GetXmlObject(string s)
        {
            s = s.Replace("\0", "");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlMsgRequestCalculateMatrix));
            using MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(s));
            XmlMsgRequestCalculateMatrix replyData = (XmlMsgRequestCalculateMatrix)xmlSerializer.Deserialize(ms);

            Matrix = replyData.Matrix;
        }

        public override string GetXmlString()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlMsgRequestCalculateMatrix));
            using MemoryStream ms = new MemoryStream();
            xmlSerializer.Serialize(ms, this);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }

    public class XmlMsgReplyCalculateMatrix : XmlMsg
    {
        public List<int> Matrix;
        public int MinNumber;

        public XmlMsgReplyCalculateMatrix()
        {
        }

        public override void GetXmlObject(string s)
        {
            s = s.Replace("\0", "");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlMsgReplyCalculateMatrix));
            using MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(s));
            XmlMsgReplyCalculateMatrix replyData = (XmlMsgReplyCalculateMatrix)xmlSerializer.Deserialize(ms);

            Matrix = replyData.Matrix;
            MinNumber = replyData.MinNumber;
        }

        public override string GetXmlString()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlMsgReplyCalculateMatrix));
            using MemoryStream ms = new MemoryStream();
            xmlSerializer.Serialize(ms, this);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
