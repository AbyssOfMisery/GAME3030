/*
 * Title:"Dungoen and dragons"
 *      
 *      kernal layer: loading scenes and control
 *      
 * Description:
 * 
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

namespace Kernal {
    public class KernalParameter
    {

//#if UNITY_STANDALONE_WIN
//        //系统配置信息_日志路径
//        internal static readonly string SystemConfigInfo_LogPath = "file://" + Application.dataPath + "/StreamingAssets/SystemConfigInfo.xml";
//        //系统配置信息_日志根节点名称
//        internal static readonly string SystemConfigInfo_LogRootNodeName = "SystemConfigInfo";
//
//        //对话系统XML路径
//        internal static readonly string DialogsXMLConfig_XmlPath ="file://" + Application.dataPath + "/StreamingAssets/SystemDialogsInfo.xml";
//        //对话系统XML根节点名称
//        internal static readonly string DialogsXMLConfig_XmlRootNodeName = "Dialogs_ENG";
//
//#elif UNITY_ANDROID
//        //系统配置信息_日志路径
//        internal static readonly string SystemConfigInfo_LogPath = Application.dataPath + "!/Assets/SystemConfigInfo.xml";
//        //系统配置信息_日志根节点名称
//        internal static readonly string SystemConfigInfo_LogRootNodeName = "SystemConfigInfo";
//
//        //对话系统XML路径
//        internal static readonly string DialogsXMLConfig_XmlPath = Application.dataPath + "!/Assets/SystemDialogsInfo.xml";
//        //对话系统XML根节点名称
//        internal static readonly string DialogsXMLConfig_XmlRootNodeName = "Dialogs_ENG";
//#elif UNITY_IPHONE
//        //系统配置信息_日志路径
//        internal static readonly string SystemConfigInfo_LogPath = Application.dataPath + "/Raw/SystemConfigInfo.xml";
//        //系统配置信息_日志根节点名称
//        internal static readonly string SystemConfigInfo_LogRootNodeName = "SystemConfigInfo";
//
//        //对话系统XML路径
//        internal static readonly string DialogsXMLConfig_XmlPath = Application.dataPath + "/Raw/SystemDialogsInfo.xml";
//        //对话系统XML根节点名称
//        internal static readonly string DialogsXMLConfig_XmlRootNodeName = "Dialogs_ENG";
//#endif

        /// <summary>
        /// get log path
        /// </summary>
        /// <returns></returns>
        public static string GetLogPath()
        {
            string logPath = null;

            //android or iphone environment
            if(Application.platform ==RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                logPath = Application.streamingAssetsPath + "/SystemConfigInfo.xml";
            }
            //windows environment
            else
            {
                logPath = "file://" + Application.streamingAssetsPath + "/SystemConfigInfo.xml";
            }

            return logPath;
        }

        /// <summary>
        /// get log root node name
        /// </summary>
        /// <returns></returns>
        public static string GetLogRootNodeName()
        {
            string LogRootNodeName = null;

            LogRootNodeName = "SystemConfigInfo";

            return LogRootNodeName;
        }

        /// <summary>
        /// get xml file path
        /// </summary>
        /// <returns></returns>
        public static string GetDialogConfigXMLPath()
        {
            string DialogPath = null;

            //android or iphone environment
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                DialogPath = Application.streamingAssetsPath + "/SystemDialogsInfo.xml";
            }
            //windows environment
            else
            {
                DialogPath = "file://" + Application.streamingAssetsPath + "/SystemDialogsInfo.xml";
            }

            return DialogPath;
        }

        /// <summary>
        /// get xml root node name
        /// </summary>
        /// <returns></returns>
        public static string GetDialogConfigXMLRootNodeName()
        {
            string DialogRootNodeName = null;

            DialogRootNodeName = "Dialogs_ENG";

            return DialogRootNodeName;
        }
    }

}

