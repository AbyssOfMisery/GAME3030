/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: NPC dialog in major city
 *      
 * Description:
 *         drag items into blocks
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
    public class NPC_Dialogs_MajorCity : MonoBehaviour
    {
        public GameObject dialogUI;
        private Image _ImgBGDialogs;

        private CommonTriggerType _ConmmonTriggerType = CommonTriggerType.None;



        
        // Start is called before the first frame update
        void Start()
        {

            _ImgBGDialogs = this.transform.parent.Find("Background").GetComponent<Image>();

            RigisterTriggerDialog();

            RigisterBGImage();

            _ImgBGDialogs.gameObject.SetActive(false);
        }


        #region dialog prepare state

        private void RigisterTriggerDialog()
        {
            TriggerCommonEvents.eveCommonTrigger += StartDialogPrepare;
        }

        /// <summary>
        /// perpare start dialogs
        /// </summary>
        /// <param name="CTT"></param>
        private void StartDialogPrepare(CommonTriggerType CTT)
        {
            switch (CTT)
            {
                case CommonTriggerType.None:
                    break;
                case CommonTriggerType.NPC1_Dialog:
                    ActiveNPC1_Dialog();
                    break;
                case CommonTriggerType.NPC2_Dialog:
                    ActiveNPC2_Dialog();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// active npc1 dialog
        /// </summary>
        private void ActiveNPC1_Dialog()
        {
            LoadNPC1_Texture();

            _ConmmonTriggerType = CommonTriggerType.NPC1_Dialog;

            View_PlayerInfoResponse.Instance.HideET();

            dialogUI.SetActive(true);

            DisplayNextDialog(5);
        }

        /// <summary>
        /// active npc2 dialog
        /// </summary>
        private void ActiveNPC2_Dialog()
        {
            LoadNPC2_Texture();

            _ConmmonTriggerType = CommonTriggerType.NPC2_Dialog;

            View_PlayerInfoResponse.Instance.HideET();

            dialogUI.SetActive(true);

            DisplayNextDialog(6);
        }

        private void LoadNPC1_Texture()
        {
            DialogUIMgr._Instance.SprNPC_Right[0] = ResourceMgr.GetInstance().LoadResource<Sprite>("Texture/UI_MajorCity/NPCTrue_1",true);
            DialogUIMgr._Instance.SprNPC_Right[1] = ResourceMgr.GetInstance().LoadResource<Sprite>("Texture/UI_MajorCity/NPCBW_1", true);
        }

        private void LoadNPC2_Texture()
        {
            DialogUIMgr._Instance.SprNPC_Right[0] = ResourceMgr.GetInstance().LoadResource<Sprite>("Texture/UI_MajorCity/NPCTrue_2", true);
            DialogUIMgr._Instance.SprNPC_Right[1] = ResourceMgr.GetInstance().LoadResource<Sprite>("Texture/UI_MajorCity/NPCBW_2", true);
        }
        #endregion

        #region dialog start

        private void RigisterBGImage()
        {
            if(_ImgBGDialogs)
            {
                EventTriggerListenner.Get(_ImgBGDialogs.gameObject).onClick += DisplayDialogNPC;
            }
        }

        /// <summary>
        /// display npc dialog
        /// </summary>
        /// <param name="go"></param>
        private void DisplayDialogNPC(GameObject go)
        {
            switch (_ConmmonTriggerType)
            {
                case CommonTriggerType.None:
                    break;
                case CommonTriggerType.NPC1_Dialog:
                    DisplayNextDialog(5);
                    break;
                case CommonTriggerType.NPC2_Dialog:
                    DisplayNextDialog(6);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// display next dialog
        /// </summary>
        /// <param name="sectionNum"></param>
        private void DisplayNextDialog(int sectionNum)
        {
            
            bool boolFlag = DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs, sectionNum);
            if (boolFlag)
            {
                //close dialog
                dialogUI.SetActive(false);
                //active easy touch
                View_PlayerInfoResponse.Instance.DisplayET();
            }
        }

        #endregion

    }//class_end

}
