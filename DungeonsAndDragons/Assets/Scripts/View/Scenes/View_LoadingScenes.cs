/*
 * Title:"Dungoen and dragons"
 *      
 *      visual layer: loading scenes and control
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
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Global;
using Kernal;

namespace View
{
    public class View_LoadingScenes : MonoBehaviour
    {
        public Slider SliLoadingProgress;//Progress component control
        private float _FloProgressNumber; //Progress value
        private AsyncOperation _AsyOper;
        public float s = 10;

        private void OnDisable()
        {
            
        }
        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);

            #region testing codes
            //test xml mgr
            //find file and load file
            //Log.ClearLogFileAndBufferData();
            //XMLDialogsDataAnalysisMgr.GetInstance().SetXMLPathAndRootNodeName(KernalParameter.GetDialogConfigXMLPath(), KernalParameter.GetDialogConfigXMLRootNodeName());
            ////get data from file
            //yield return new WaitForSeconds(0.5f);
            //List<DialogDataFormat> lIDialogsDataArray = XMLDialogsDataAnalysisMgr.GetInstance().GetAllXMLDatas();


            //bool result = DialogDataMgr.GetInstance().LoadAllDialogData(lIDialogsDataArray);
            //if (!result)
            //{
            //    Log.Write(GetType() + "/Start()/LoadFiled");
            //}
            //GlobalParaMgr.NextScenesName = ScenesEnum.LevelOne;

            //StartCoroutine("LoadingScenesProgress");
            #endregion

            StartCoroutine("LoadingScenesProgress");

        }

        //Asynchronous loading
        IEnumerator LoadingScenesProgress()
        {
            //_AsyOper = SceneManager.LoadSceneAsync("2_LogonScenes");
            _AsyOper = SceneManager.LoadSceneAsync(ConvertEnumToString.GetInstance().GetStrByEnumScenes(GlobalParaMgr.NextScenesName));
            _FloProgressNumber = _AsyOper.progress;
            yield return _AsyOper;
        }

        //show progress value
        private void Update()
        {
            
            if (_FloProgressNumber <=1 )
            {
                _FloProgressNumber += 0.01f;
            }
            SliLoadingProgress.value = _FloProgressNumber;
        }
    }
}

