/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: logon scenes
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

using Kernal;
using Global;

namespace Control
{
    public class Ctrl_LoadingScenes : BaseControl
    {
        IEnumerator Start()
        {
            Log.Write(GetType()+"/Start()");
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            //level perloaded
            StartCoroutine("ScenesPreProgressing");

            //recycle useless prefabs
            StartCoroutine("HandleGC");
        }

        /// <summary>
        /// level perloaded
        /// </summary>
        /// <returns></returns>
        IEnumerator ScenesPreProgressing()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            switch (GlobalParaMgr.NextScenesName)
            {
                case ScenesEnum.TestScenes:
                    break;
                case ScenesEnum.StartScenes:
                    break;
                case ScenesEnum.LoadingScenes:
                    break;
                case ScenesEnum.LogonScenes:
                    break;
                case ScenesEnum.LevelOne:
                    StartCoroutine("ScenesPreProgressing_LeveOne");
                    break;
                case ScenesEnum.LevelTwo:
                    break;
                case ScenesEnum.BaseScenes:
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// preload level one
        /// </summary>
        /// <returns></returns>
        IEnumerator ScenesPreProgressing_LeveOne()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);

            Log.ClearLogFileAndBufferData();
            XMLDialogsDataAnalysisMgr.GetInstance().SetXMLPathAndRootNodeName(KernalParameter.GetDialogConfigXMLPath(), KernalParameter.GetDialogConfigXMLRootNodeName());
            //get data from file
            yield return new WaitForSeconds(0.5f);
            List<DialogDataFormat> lIDialogsDataArray = XMLDialogsDataAnalysisMgr.GetInstance().GetAllXMLDatas();


            bool result = DialogDataMgr.GetInstance().LoadAllDialogData(lIDialogsDataArray);
            if (!result)
            {
                Log.Write(GetType() + "/Start()/LoadFiled",Log.Level.High);
            }

        }


        /// <summary>
        /// recycle unused assets
        /// </summary>
        /// <returns></returns>
        IEnumerator HandleGC()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);

            //unload unused assets
            Resources.UnloadUnusedAssets();
            //forced to recycle unused assets
            System.GC.Collect();

        }


    }

}
