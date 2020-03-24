/*
 * Title:"Dungoen and dragons"
 *      
 *      Kernal layer: Configuration Manager
 *      
 * Description:
 *        -load system core xml configuration
 * Date:2020
 * 
 * Verstion: 0.1
 * 
 * Modify Recoder;
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq; //XDocument name
using System.IO;

namespace Kernal
{
    public class ConfigManager : IConfigManager
    {
        private static Dictionary<string, string> _AppSetting; //define app settings

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logPath">log path </param>
        /// <param name="xmlRootNodeName">root node name</param>
        public ConfigManager(string logPath, string xmlRootNodeName)
        {
            _AppSetting = new Dictionary<string, string>();
            InitAndAnalysisXml(logPath,xmlRootNodeName);
        }

        /// <summary>
        /// init load xml date into Dictionary<Appsetting>
        /// </summary>
        /// <param name="logPath">log path</param>
        /// <param name="xmlRootNodeName">root node name</param>
        private void InitAndAnalysisXml (string logPath,string xmlRootNodeName)
        {   
            //data check
            if(string.IsNullOrEmpty(logPath) || string.IsNullOrEmpty(xmlRootNodeName))
            {
                return;
            }
            //
            XDocument xmlDoc;       //xml file
            XmlReader xmlReader;    //xml reader

            try
            {
                xmlDoc = XDocument.Load(logPath);   //load file path
                xmlReader = XmlReader.Create(new StringReader(xmlDoc.ToString()));  //create xml reader
            }
            catch
            {
                //need improve later
                throw new XMLAnalysisException(GetType() + "/InitAndAnalysisXml()/XML Analysis Exception! , Please Check!");
            }

            //a loop function to load xml file
            while(xmlReader.Read())
            {
                //XML reader start load root name and looping until end
                if(xmlReader.IsStartElement() && xmlReader.LocalName == xmlRootNodeName)
                {
                    using (XmlReader xmlReaderItem = xmlReader.ReadSubtree())
                    {
                        while(xmlReaderItem.Read())
                        {
                            //if this is root element
                            if(xmlReaderItem.NodeType == XmlNodeType.Element)
                            {
                                //root element
                                string strNode = xmlReaderItem.Name;

                                //next row infomation or next row root name
                                xmlReaderItem.Read();
                                //is this is xml root text
                                if(xmlReaderItem.NodeType == XmlNodeType.Text)
                                {
                                    //XML file, copy current row key vaule  
                                    _AppSetting[strNode] = xmlReaderItem.Value;
                                }
                            }
                        }
                    }//using_end

                }//if_end

            }//while_end


        }//InitAndAnalysisXml_end

        /// <summary>
        /// setting
        /// </summary>
        public Dictionary<string, string> AppSetting
        {
            get{ return _AppSetting; }
        }

        /// <summary>
        /// get max settings
        /// </summary>
        /// <returns></returns>
        public int GetAppSettingMaxNumber()
        {
            if(_AppSetting!=null && _AppSetting.Count>=1)
            {
                return _AppSetting.Count;
            }
            else
            {
                return 0;
            }
        }


    }

}
