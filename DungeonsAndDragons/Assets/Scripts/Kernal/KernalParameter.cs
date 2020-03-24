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

#if UNITY_STANDALONE_WIN
        //log path
        internal static readonly string SystemConfigInfo_LogPath= "file://"+Application.dataPath + "/StreamingAssets/SystemConfigInfo.xml";
            //xml root node name
        internal static readonly string SystemConfigInfo_LogRootNodeName="SystemConfigInfo";
#elif UNITY_ANDROID
            //log path
        internal static readonly string SystemConfigInfo_LogPath=Application.dataPath + "!/Assets/SystemConfigInfo.xml";
            //xml root node name
        internal static readonly string SystemConfigInfo_LogRootNodeName="SystemConfigInfo";
#elif UNITY_IPHONE
                    //log path
        internal static readonly string SystemConfigInfo_LogPath=Application.dataPath + "/Raw/SystemConfigInfo.xml";
            //xml root node name
        internal static readonly string SystemConfigInfo_LogRootNodeName="SystemConfigInfo";
#endif

    }

}

