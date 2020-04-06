/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: dialog trigger to active beginner guide
 *      
 * Description:
 *      
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

using Global;
using Kernal;

namespace View
{
    public class TriggerDialogs : MonoBehaviour , IGuideTrigger
    {
        public enum DialogStateStep
        {
            None,
            Step1_TwoPeopleDialog,
            Step2_AliceSpeakET,
            Step3_AliceSpeakVisualKey,
            Step4_AliceSpeakEnd
        }


        public static TriggerDialogs Instance; //get instance
        public GameObject goBackground;        //background object
        private bool _IsExistNextDialogsRecorder = false;
        private Image _ImgBGDialogs;        // background texture
        private DialogStateStep dialogState = DialogStateStep.None;


        void Awake()
        {
            Instance = this;
        }
        
        void Start()
        {
            Log.Write(GetType() +"/Start");

            dialogState = DialogStateStep.Step1_TwoPeopleDialog;

            //find background image
            _ImgBGDialogs = transform.parent.Find("Background").GetComponent<Image>();

            //register bakcground image
            RegisterDialogs();

            DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs,1);

        }

        //register bakcground image
        public void RegisterDialogs()
        {
            if(_ImgBGDialogs!=null)
            {
                EventTriggerListenner.Get(_ImgBGDialogs.gameObject).onClick += DisplayNextDialogRecord;
            }
        }

        private void UnRegisterDialogs()
        {
            if (_ImgBGDialogs != null)
            {
                EventTriggerListenner.Get(_ImgBGDialogs.gameObject).onClick -= DisplayNextDialogRecord;
            }
        }

        /// <summary>
        /// show next dialog
        /// </summary>
        /// <param name="go">target object</param>
        private void DisplayNextDialogRecord(GameObject go)
        {
            Log.Write(GetType()+ "/DisplayNextDialogRecord");
            if(go == _ImgBGDialogs.gameObject)
            {
                _IsExistNextDialogsRecorder = true;
            }
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

            bool boolResult = false;                    //check is this function end
            bool boolCurrentDialogResult = false;       //check is this dialog end
            _IsExistNextDialogsRecorder = false;

            switch (dialogState)
            {
                case DialogStateStep.None:
                    break;

                case DialogStateStep.Step1_TwoPeopleDialog:
                    boolCurrentDialogResult=DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs, 1);
                    break;

                case DialogStateStep.Step2_AliceSpeakET:
                   
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 2);
                    break;

                case DialogStateStep.Step3_AliceSpeakVisualKey:
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 3);
                    break;

                case DialogStateStep.Step4_AliceSpeakEnd:
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 4);
                    break;

                default:
                    break;
            }

            //doing some check when end of current conversation 
            if (boolCurrentDialogResult)
            {
                switch (dialogState)
                {
                    case DialogStateStep.None:
                        break;

                    case DialogStateStep.Step1_TwoPeopleDialog:
     
                        break;

                    case DialogStateStep.Step2_AliceSpeakET:
                        //show et image
                        TriggerOperET.Instance.DisplayGuideET();
                        //pause dialog
                        UnRegisterDialogs();
                        break;

                    case DialogStateStep.Step3_AliceSpeakVisualKey:
                        //show visual key image
                        TriggerOperVisualKey.Instance.DisplayGuideVisualKey();
                        //disable dialog
                        UnRegisterDialogs();

                        break;

                    case DialogStateStep.Step4_AliceSpeakEnd:
                        //show et joystick
                        View_PlayerInfoResponse.Instance.DisplayET();
                        //show all visual key
                        View_PlayerInfoResponse.Instance.DisplayVisualKey();
                        //show player UI Info
                        View_PlayerInfoResponse.Instance.DisplayPlayerUIInfo();

                        //allow enemy spawn
                        GameObject.Find("_GameManager/_ScenesControl").GetComponent<View_LevelOneScenes>().enabled = true;
                        GameObject.Find("_GameManager/_ScenesControl").GetComponent<Control.Ctrl_LevelOneScenes>().enabled = true;
                        //disable dialog
                        goBackground.SetActive(false);
                        //condition check
                        boolResult = true;

                        break;

                    default:
                        break;
                }
                //go to next step
                EnterNextState();
            }
            return boolResult;
        }//if_end

        private void EnterNextState()
        {
            switch (dialogState)
            {
                case DialogStateStep.None:
                    break;
                case DialogStateStep.Step1_TwoPeopleDialog:
                    dialogState = DialogStateStep.Step2_AliceSpeakET;
                    break;
                case DialogStateStep.Step2_AliceSpeakET:
                    dialogState = DialogStateStep.Step3_AliceSpeakVisualKey;
                    break;
                case DialogStateStep.Step3_AliceSpeakVisualKey:
                    dialogState = DialogStateStep.Step4_AliceSpeakEnd;
                    break;
                case DialogStateStep.Step4_AliceSpeakEnd:
                    dialogState = DialogStateStep.None;
                    break;
                default:
                    break;
            }
        }


    }//class_end
}

