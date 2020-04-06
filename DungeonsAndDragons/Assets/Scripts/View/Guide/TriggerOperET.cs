/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: easy touch trigger
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
using Global;
using Kernal;
using UnityEngine.UI;

namespace View
{
    public class TriggerOperET : MonoBehaviour , IGuideTrigger
    {
        public static TriggerOperET Instance; //get instance
        public GameObject goBackground;        //background object
        private bool _IsExistNextDialogsRecorder = false;
        private Image _ImgGuideET;        // ET texture

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //find background image
            _ImgGuideET = transform.parent.Find("ImgET").GetComponent<Image>();

            //register bakcground image
            RigisterGuideET();
        }

        /// <summary>
        /// check trigger condition
        /// </summary>
        public bool CheckCondition()
        {
            Log.Write(GetType() + "/CheckCondition()");
            if(_IsExistNextDialogsRecorder)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// run operation logic
        /// </summary>
        /// <returns></returns>
        public bool RunOperation()
        {
            Log.Write(GetType() + "/RunOperation()");
            _IsExistNextDialogsRecorder = false;
            //hide dialog ui
            goBackground.SetActive(false);
            //hide imgET 
            _ImgGuideET.gameObject.SetActive(false);
            //allow player to active easy touch
            View_PlayerInfoResponse.Instance.DisplayET();
            //resume dialog ui and continue conversation
            StartCoroutine("ResumeDialogs");
            
        
            return true;
        }

        //show ET img
        public void DisplayGuideET()
        {
            _ImgGuideET.gameObject.SetActive(true);
        }

        //rigister guide et image
        private void RigisterGuideET()
        {
            if (_ImgGuideET != null)
            {
                EventTriggerListenner.Get(_ImgGuideET.gameObject).onClick += GuideETOperation;
            }
        }

        /// <summary>
        /// guide et
        /// </summary>
        /// <param name="go"></param>
        private void GuideETOperation(GameObject go)
        {
            if(go == _ImgGuideET.gameObject)
            {
                _IsExistNextDialogsRecorder = true;
            }
        }

        IEnumerator ResumeDialogs()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            //hide ET joystick
            View_PlayerInfoResponse.Instance.HideET();
            //Register dialogs system, continue conversation
            TriggerDialogs.Instance.RegisterDialogs();
            //Run dialog system
            TriggerDialogs.Instance.RunOperation();
            //show dialog UI
            goBackground.SetActive(true);
        }
    }
}

