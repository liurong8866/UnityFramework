using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Framework
{
    public class XmlSerializUtility<T>
    {
        /// <summary>
        /// 载入数据
        /// </summary>
        /// <param name="filePath">unity3D当前project的路径名</param>
        /// <returns></returns>
        public object LoadData(string filePath)
        {
            object result = null;

            if (File.Exists(filePath))
            {
                StreamReader r = File.OpenText(filePath);

                string data = r.ReadToEnd();

                result = DeserializeObject(data);

                r.Close();
            }
            return result;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="eventInfo"></param>
        /// <param name="filePath">unity3D当前project的路径名</param>
        public void SaveData(T eventInfo, string filePath)
        {
            StreamWriter writer;
            FileInfo t = new FileInfo(filePath);
            t.Delete();
            writer = t.CreateText();
            string data = SerializeObject(eventInfo);//序列化这组数据  
            writer.WriteLine(data);//写入xml  
            writer.Close();
        }

        private String UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        private byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        private String SerializeObject(object data)
        {
            String XmlizedString = "";
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(T));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            xs.Serialize(xmlTextWriter, data);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream; // (MemoryStream)  
            XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
            return XmlizedString;
        }

        private object DeserializeObject(String pXmlizedString)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return xs.Deserialize(memoryStream);
        }

    }
}
