using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Chart.Core
{
    public class Config
    {
        public static string ConfigFile = "base.xml";

        public static string GetValue(string appNode, string appKey)
        {       
            XmlDocument xDoc;
            XmlNodeList xNodeList;
            string fileName, value;
            value = "";
            foreach (DefaultConfig dc in defaultConfig)
            {
                if (dc.Node == appNode &&
                    dc.Child == appKey)
                {
                    value = dc.Value;
                }
            }

            try
            {
                xDoc = new XmlDocument();
                fileName = ConfigFile;
                xDoc.Load(fileName);
                xNodeList = xDoc.GetElementsByTagName(appNode);
                foreach (XmlNode child in xNodeList.Item(0).ChildNodes)
                {
                    if (child.Name == appKey)
                    {
                        return child.InnerText.Length > 0 ? child.InnerText : value;
                    }
                }

                InsertNode(appNode, appKey, value);
                return value;
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(ConfigFile));
                return GetValue(appNode, appKey);
            }
            catch (FileNotFoundException)
            {   //配置文件丢失
                CreateXml();
                GetValue(appNode, appKey);
            }
            catch (XmlException)
            {   //配置文件遭破坏
                CreateXml();
                GetValue(appNode, appKey);
            }
            catch (Exception)
            {   //其他异常
                InsertNode(appNode);
                InsertNode(appNode, appKey, value);
            }
            return value;
        }

        public static void SetValue(string appNode, string appKey, object value)
        {
            SetValue(appNode, appKey, value.ToString());
        }

        /// <summary>
        /// 设置配置文件相应节点中相应元素的值
        /// </summary>
        /// <param name="appNode">相应节</param>
        /// <param name="appKey">相应元素</param>
        /// <param name="value">新值</param>
        public static void SetValue(string appNode, string appKey, string value)
        {
            int index;
            bool bFind;
            XmlNode node;
            string fileName;
            XmlDocument xDoc;
            XmlNodeList xNodeList;

            fileName = ConfigFile;
            xDoc = new XmlDocument();

            try
            {
                bFind = false;
                xDoc.Load(fileName);
                xNodeList = xDoc.GetElementsByTagName(appNode);
                foreach (XmlNode child in xNodeList.Item(0).ChildNodes)
                {
                    if (child.Name == appKey)
                    {
                        bFind = true;
                        child.InnerText = value;
                        break;
                    }
                }
                xDoc.Save(fileName);

                if (bFind)
                {
                    xDoc.Save(fileName);
                }
                else
                {
                    for (index = 1; index < xNodeList.Count; index++)
                    {
                        node = xNodeList.Item(index);
                        node.ParentNode.RemoveChild(node);
                    }

                    if (index > 1)
                    {
                        xDoc.Save(fileName);
                    }
                    throw new Exception();
                }
            }
            catch
            {
                GetValue(appNode, appKey);
                SetValue(appNode, appKey, value);
            }
        }

        /// <summary>
        /// 查询某一类节点的所有值
        /// </summary>
        /// <param name="appNode"></param>
        /// <returns></returns>
        public static XmlNodeList SelectXml(string appNode)
        {
            XmlDocument xDoc;
            XmlNodeList xNodeList;
            string fileName;

            fileName = ConfigFile;
            xDoc = new XmlDocument();

            try
            {
                xDoc.Load(fileName);
                xNodeList = xDoc.GetElementsByTagName(appNode);

                return xNodeList;
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(ConfigFile));
                return SelectXml(appNode);
            }
            catch (FileNotFoundException)
            {
                CreateXml();
                return SelectXml(appNode);
            }
            catch (XmlException)
            {
                CreateXml();
                return SelectXml(appNode);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void DeleteNode(string appNode)
        {
            string fileName;
            XmlDocument xDoc;
            XmlNodeList xNodeList;

            fileName = ConfigFile;
            xDoc = new XmlDocument();

            try
            {
                xDoc.Load(fileName);
                xNodeList = xDoc.GetElementsByTagName(appNode);
                for (int index = 0; index < xNodeList.Count; )
                {
                    XmlNode node = xNodeList[index];
                    node.ParentNode.RemoveChild(node);
                }
                xDoc.Save(fileName);
            }
            catch
            { }
        }

        /// <summary>
        /// 删除名称为“appNode”并且子结点名称为“name”的节点
        /// </summary>
        /// <param name="appNode"></param>
        /// <param name="name"></param>
        public static void DeleteNode(string appNode, string name)
        {
            string fileName;
            XmlDocument xDoc;
            XmlNodeList xNodeList;

            fileName = ConfigFile;
            xDoc = new XmlDocument();

            try
            {
                xDoc.Load(fileName);
                xNodeList = xDoc.GetElementsByTagName(appNode);

                for (int index = 0; index < xNodeList.Count; )
                {
                    XmlNode node = xNodeList[index];
                    node.ParentNode.RemoveChild(node);
                }
                xDoc.Save(fileName);
            }
            catch
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appNode"></param>
        /// <param name="attributeValue"></param>
        public static void DeleteNodeByAttribute(string appNode, string attribute, string Value)
        {
            string fileName;
            XmlDocument xDoc;
            XmlNodeList xNodeList;

            fileName = ConfigFile;
            xDoc = new XmlDocument();

            try
            {
                xDoc.Load(fileName);
                xNodeList = xDoc.GetElementsByTagName(appNode);

                for (int index = 0; index < xNodeList.Count; )
                {
                    XmlNode node = xNodeList[index];
                    XmlElement xe = (XmlElement)node;
                    if (xe.GetAttribute(attribute) == Value)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                    else
                    {
                        index++;
                    }
                }
                xDoc.Save(fileName);
            }
            catch
            { }
        }

        /// <summary>
        /// 在配置文件中插入一个节点“appNode”
        /// </summary>
        /// <param name="appNode"></param>
        public static void InsertNode(string appNode)
        {
            XmlNode node;
            string fileName;
            XmlElement xElem;
            XmlDocument xDoc;

            fileName = ConfigFile;
            xDoc = new XmlDocument();

            try
            {
                xDoc.Load(fileName);
                xElem = xDoc.DocumentElement;
                node = xDoc.CreateElement(appNode);
                xElem.AppendChild(node);

                xDoc.Save(fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(ConfigFile));
                InsertNode(appNode);
            }
            catch (FileNotFoundException)
            {
                //配置文件丢失
                CreateXml();
                InsertNode(appNode);
            }
            catch (XmlException)
            {
                CreateXml();
                InsertNode(appNode);
            }
            catch (Exception)
            { }
        }

        public static void InsertNodeWithAttri(string appNode, List<string> attributes, List<string> values)
        {
            XmlNode node;
            string fileName;
            XmlElement xElem;
            XmlDocument xDoc;

            fileName = ConfigFile;
            xDoc = new XmlDocument();

            try
            {
                xDoc.Load(fileName);
                xElem = xDoc.DocumentElement;
                node = xDoc.CreateElement(appNode);
                XmlElement xe = (XmlElement)node;
                for (int index = 0; index < attributes.Count; index++)
                {
                    xe.SetAttribute(attributes[index], values[index]);
                }
                xElem.AppendChild(node);

                xDoc.Save(fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(ConfigFile));
                InsertNodeWithAttri(appNode, attributes, values);
            }
            catch (FileNotFoundException)
            {
                //配置文件丢失
                CreateXml();
                InsertNodeWithAttri(appNode, attributes, values);
            }
            catch (XmlException)
            {
                CreateXml();
                InsertNodeWithAttri(appNode, attributes, values);
            }
            catch (Exception)
            { }
        }

        public static void InsertNode(string appNode, string child, Object value)
        {
            InsertNode(appNode, child, value.ToString());
        }
        /// <summary>
        /// 在配置文件的appNode节点中插入值为value的子节点child
        /// </summary>
        /// <param name="appNode"></param>
        /// <param name="child"></param>
        /// <param name="value"></param>
        public static void InsertNode(string appNode, string child, string value)
        {
            XmlNode node;
            string fileName;
            XmlDocument xDoc;
            XmlNodeList xNodeList;

            foreach (DefaultConfig dc in defaultConfig)
            {
                if (dc.Node == appNode &&
                    dc.Child == child)
                {
                    value = dc.Value;
                    break;
                }
            }

            try
            {
                fileName = ConfigFile;
                xDoc = new XmlDocument();
                xDoc.Load(fileName);
                xNodeList = xDoc.GetElementsByTagName(appNode);

                node = xDoc.CreateElement(child);
                node.InnerText = value;
                xNodeList.Item(xNodeList.Count - 1).AppendChild(node);

                xDoc.Save(fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(ConfigFile));
                InsertNode(appNode, child, value);
            }
            catch (FileNotFoundException)
            {
                //配置文件丢失
                CreateXml();
                InsertNode(appNode, child, value);
            }
            catch (XmlException)
            {
                CreateXml();
                InsertNode(appNode, child, value);
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// 在配置文件的appNode节点中插入值为value的子节点child
        /// </summary>
        /// <param name="appNode"></param>
        /// <param name="child"></param>
        /// <param name="value"></param>
        public static void InsertNode(string appNode, string child, string attribute, string attriValue)
        {
            XmlNode node;
            string fileName;
            XmlDocument xDoc;
            XmlNodeList xNodeList;

            foreach (DefaultConfig dc in defaultConfig)
            {
                if (dc.Node == appNode &&
                    dc.Child == child)
                {
                    break;
                }
            }

            try
            {
                fileName = ConfigFile;
                xDoc = new XmlDocument();
                xDoc.Load(fileName);
                xNodeList = xDoc.GetElementsByTagName(appNode);

                node = xDoc.CreateElement(child);
                XmlElement xe = (XmlElement)node;
                xe.SetAttribute(attribute, attriValue);
                xNodeList.Item(xNodeList.Count - 1).AppendChild(node);

                xDoc.Save(fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(ConfigFile));
            }
            catch (FileNotFoundException)
            {
                //配置文件丢失
                CreateXml();
            }
            catch (XmlException)
            {
                CreateXml();
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// 修改配置文件中某一节点的子节点的值
        /// </summary>
        /// <param name="appNode"></param>
        /// <param name="name"></param>
        /// <param name="appKey"></param>
        /// <param name="value"></param>
        public static void UpdateNode(
            string appNode,
            string name,
            string appKey,
            string value)
        {
            string fileName;
            XmlDocument xDoc;
            XmlNodeList xNodeList;

            fileName = ConfigFile;
            xDoc = new XmlDocument();

            try
            {
                xDoc.Load(fileName);
                xNodeList = xDoc.GetElementsByTagName(appNode);

                foreach (XmlNode node in xNodeList)
                {
                    if (node.FirstChild.InnerText == name)
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == appKey)
                            {
                                child.InnerText = value;
                                xDoc.Save(fileName);
                                break;
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(ConfigFile));
                UpdateNode(appNode, name, appKey, value);
            }
            catch (FileNotFoundException)
            {   //配置文件丢失
                CreateXml();
                UpdateNode(appNode, name, appKey, value);
            }
            catch (XmlException)
            {
                CreateXml();
                UpdateNode(appNode, name, appKey, value);
            }
            catch (Exception)
            { }
        }
        /// <summary>
        /// 在配置文件中增加一个节点“appNode”以及若干个子节点
        /// </summary>
        /// <param name="appNode"></param>
        /// <param name="child"></param>
        public static void AddNode(string appNode, params string[] child)
        {
            XmlNode node, subNode;
            string fileName;
            XmlElement xElem;
            XmlDocument xDoc;

            fileName = ConfigFile;
            xDoc = new XmlDocument();

            try
            {
                xDoc.Load(fileName);
                xElem = xDoc.DocumentElement;
                node = xDoc.CreateElement(appNode);
                xElem.AppendChild(node);
                for (int i = 0; i < child.Length; i = i + 2)
                {
                    subNode = xDoc.CreateElement(child[i]);
                    subNode.InnerText = child[i + 1];
                    node.AppendChild(subNode);
                }
                xDoc.Save(fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(ConfigFile));
                AddNode(appNode, child);
            }
            catch (FileNotFoundException)
            {
                //配置文件丢失
                CreateXml();
                AddNode(appNode, child);
            }
            catch (XmlException)
            {
                CreateXml();
                AddNode(appNode, child);
            }
            catch (Exception)
            { }
        }
        /// <summary>
        /// 再生配置文件
        /// </summary>
        private static void CreateXml()
        {
            XmlTextWriter xmlWriter;
            FileStream fileStream;

            fileStream = new FileStream(ConfigFile, FileMode.Create);
            xmlWriter = new XmlTextWriter(fileStream, Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;

            xmlWriter.WriteStartDocument(true);
            xmlWriter.WriteStartElement("NCIAE");
            xmlWriter.WriteAttributeString("CompanyName", "NCIAE");
            xmlWriter.WriteAttributeString("ProductName", "XML配置工具");
            xmlWriter.WriteAttributeString("version", "v1.0");
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        private struct DefaultConfig
        {
            string node;
            string child;
            string value;
            public DefaultConfig(string node, string child, string value)
            {
                this.node = node;
                this.child = child;
                this.value = value;
            }

            public string Node
            {
                get
                {
                    return node;
                }
            }
            public string Child
            {
                get
                {
                    return child;
                }
            }
            public string Value
            {
                get
                {
                    return value;
                }
            }
        }
        private static DefaultConfig[] defaultConfig = new DefaultConfig[]
        {
            new DefaultConfig("NET", "Port", "8000"),
        };
    }
}
