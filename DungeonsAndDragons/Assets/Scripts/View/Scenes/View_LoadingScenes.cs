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

namespace View
{
    public class View_LoadingScenes : MonoBehaviour
    {
        public Slider SliLoadingProgress;//Progress component control
        private float _FloProgressNumber; //Progress value
        private AsyncOperation _AsyOper;

        // Start is called before the first frame update
        void Start()
        {
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
            if(_FloProgressNumber <=1 )
            {
                _FloProgressNumber += 0.01f;
            }
            SliLoadingProgress.value = _FloProgressNumber;
        }
    }
}

