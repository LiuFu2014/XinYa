using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace XinYaPCClientForVisualQCStation
{
    public class XMLHelper
    {
        #region 读取XML某节点的name的InnerText
        /// <summary>
        /// 读取XML某节点的name的InnerText
        /// </summary>
        /// <param name="spath">目录路径</param>
        /// <param name="nodename">节点名称</param>
        /// <param name="strname">节点的Attribute-Name值</param>
        /// <returns>返回InnerText</returns>
        public static string ReadXML(string spath, string singlenode, string nodename)
        {
            string value = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(spath);
            XmlNodeList nodelist = xmldoc.SelectSingleNode(singlenode).ChildNodes;
            foreach (XmlNode xn in nodelist)
            {
                if (xn.Name == nodename)
                {
                    XmlElement xe = (XmlElement)xn;
                    value=xe.InnerText;
                }
            }
            return value;
        }
        #endregion
    }
}
