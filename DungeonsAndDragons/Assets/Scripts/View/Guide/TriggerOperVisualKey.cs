/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: key trigger
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
using UnityEngine.UI;

namespace View {
    public class TriggerOperVisualKey : MonoBehaviour , IGuideTrigger
    {
        public static TriggerOperVisualKey Instance; //get instance
        public GameObject goBackground;        //background object
        private bool _IsExistNextDialogsRecorder = false;
        private Image _ImgGuideVisualKey;        // VisualKey texture

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //find background image
            _ImgGuideVisualKey = transform.parent.Find("ImgVisualKey").GetComponent<Image>();

            //register bakcground image
            RigisterGuideVisualKey();
        }

        /// <summary>
        /// check trigger condition
        /// </summary>
        public bool CheckCondition()
        {
            Log.Write(GetType() + "/CheckCondition()");
            if (_IsExistNextDialogsRecorder)
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
            _ImgGuideVisualKey.gameObject.SetActive(false);
            //allow player to active easy touch
            View_PlayerInfoResponse.Instance.DisplayET();
            //allow player to active visual key
            View_PlayerInfoResponse.Instance.ShowBasicAttack();
            //resume dialog ui and continue conversation
            StartCoroutine("ResumeDialogs");


            return true;
        }

        //show ET img
        public void DisplayGuideVisualKey()
        {
            _ImgGuideVisualKey.gameObject.SetActive(true);
        }

        //rigister guide et image
        private void RigisterGuideVisualKey()
        {
            if (_ImgGuideVisualKey != null)
            {
                EventTriggerListenner.Get(_ImgGuideVisualKey.gameObject).onClick += GuideVisualKeyOperation;
            }
        }

        /// <summary>
        /// guide et
        /// </summary>
        /// <param name="go"></param>
        private void GuideVisualKeyOperation(GameObject go)
        {
            if (go == _ImgGuideVisualKey.gameObject)
            {
                _IsExistNextDialogsRecorder = true;
            }
        }

        IEnumerator ResumeDialogs()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_5);
            //hide et touch
            View_PlayerInfoResponse.Instance.HideET();
            //hide visual key
            View_PlayerInfoResponse.Instance.HideVisualKey();
            //Register dialogs system, continue conversation
            TriggerDialogs.Instance.RegisterDialogs();
            //Run dialog system
            TriggerDialogs.Instance.RunOperation();
            //show dialog UI
            goBackground.SetActive(true);
        }
    }

}

