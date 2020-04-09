/*
 * Title:"Dungoen and dragons"
 *      
 *       Kernal layer: XML conversation data parsing
 *      
 * Description:
 *      1: For dialogue XML, do data parsing
 *      
 * Date:2020
 * 
 * Verstion: 0.1
 * 
 * Modify Recoder;
 *  
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.IO;
using System.Text;
using UnityEngine.Networking;

namespace Kernal
{
    public class XMLDialogsDataAnalysisMgr : MonoBehaviour
    {
        private const float TIMES_DELAY = 0.1f;
        private const string XML_ATTRIBUTE_1 = "DialogSecNum";
        private const string XML_ATTRIBUTE_2 = "DialogSecName";
        private const string XML_ATTRIBUTE_3 = "SectionIndex";
        private const string XML_ATTRIBUTE_4 = "DialogSide";
        private const string XML_ATTRIBUTE_5 = "DialogPerson";
        private const string XML_ATTRIBUTE_6 = "DialogContent";

        private static XMLDialogsDataAnalysisMgr _Instance;
        private List<DialogDataFormat> _DialogData;
        private string _XMLPath;
        private string _XMLRootNodeName;


        private XMLDialogsDataAnalysisMgr()
        {
            _DialogData = new List<DialogDataFormat>();

        }
   
        IEnumerator Start()
        {

           
            yield return new WaitForSeconds(TIMES_DELAY);//wait until the code has find the xml file and xml root nodes
            if (!string.IsNullOrEmpty(_XMLPath) && !string.IsNullOrEmpty(_XMLRootNodeName))
            {
                StartCoroutine("ReadXMLConfigByWWW");
            }
            else
            {
                Debug.LogError(GetType() + "/Start()/_StrXMLPath or _StrXMLRootNodeName is null!,please check!");
            }
        }

        public static XMLDialogsDataAnalysisMgr GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new GameObject("_XMLD").AddComponent<XMLDialogsDataAnalysisMgr>();
            }
            return _Instance;
        }

        public void SetXMLPathAndRootNodeName(string xmlPath, string xmlRootNodeName)
        {
            if (!string.IsNullOrEmpty(xmlPath) && !string.IsNullOrEmpty(xmlRootNodeName))
            {
                _XMLPath = xmlPath;
                _XMLRootNodeName = xmlRootNodeName;
            }
        }

        public List<DialogDataFormat> GetAllXMLDatas()
        {
            if (_DialogData != null && _DialogData.Count >= 1)
            {
                return _DialogData;
            }
            else
            {
                return null;
            }
        }

   

        IEnumerator ReadXMLConfigByWWW()
        {
            UnityWebRequest www = UnityWebRequest.Get(_XMLPath);
            while (!www.isDone)
            {
                yield return www.SendWebRequest();
                InitXMLConfig(www, _XMLRootNodeName);
            }

        }

        private void InitXMLConfig(UnityWebRequest www, string rootNodeName)
        {
            if (_DialogData == null || string.IsNullOrEmpty(www.downloadHandler.text))
            {
                Debug.LogError(GetType() + "/InitXMLConfig()/_DialogDataArray==null or rootNodeName is null!,please check!");
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(www.downloadHandler.text);//this output doesnt show chinese correctly in cellphones

            //System.IO.StringReader stringReader = new StringReader(www.downloadHandler.text);
            //stringReader.Read();
            //System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);
            //reader.Close();
            //xmlDoc.LoadXml(stringReader.ReadToEnd());

            String stringReader = www.downloadHandler.text;
            xmlDoc.LoadXml(@stringReader);

            XmlNodeList nodes = xmlDoc.SelectSingleNode(_XMLRootNodeName).ChildNodes;     
            foreach (XmlElement xe in nodes)
            {
                //Instantiate, xml parsing instance class
                DialogDataFormat data = new DialogDataFormat();
                //Dialogue paragraph number
                data.DialogSecNumber = Convert.ToInt32(xe.GetAttribute(XML_ATTRIBUTE_1));
                //Dialogue paragraph name
                data.DialogSecName = Convert.ToString(xe.GetAttribute(XML_ATTRIBUTE_2));
                // paragraph number 
                data.SectionIndex = Convert.ToInt32(xe.GetAttribute(XML_ATTRIBUTE_3));
                // Dialogue parties
                data.DialogSide = Convert.ToString(xe.GetAttribute(XML_ATTRIBUTE_4));
                // dialog person name
                data.DialogPerson = Convert.ToString(xe.GetAttribute(XML_ATTRIBUTE_5));
                // dialog
                data.DialogContent = Convert.ToString(xe.GetAttribute(XML_ATTRIBUTE_6));
            
                _DialogData.Add(data);
            }//foreach end
            
        }//InitXMLConfig end

    }
}

