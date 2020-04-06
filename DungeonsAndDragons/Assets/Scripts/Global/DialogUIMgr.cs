/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: dialog UI manager 
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
using UnityEngine.UI;

namespace Global
{

    /// <summary>
    /// dialog type
    /// </summary>
    public enum DialogType
    {
        None,
        DoubleDialogs,
        SingleDialogs
    }


    public class DialogUIMgr : MonoBehaviour
    {
        public static DialogUIMgr _Instance; //instance

        //UI objects
        public GameObject goPlayer;
        public GameObject goNPC_Left;
        public GameObject goNPC_Right;
        public GameObject goSingleDialogArea;
        public GameObject goDoubleDialogArea;

        //dialog UI
        public Text TxtPersonName;
        public Text TxtDoubleDialogContent;
        public Text TxtSingleDialogContent;

        //sprite image array
        public Sprite[] SprPlayer;
        public Sprite[] SprNPC_Left;
        public Sprite[] SprNPC_Right;



        private void Awake()
        {
            _Instance = this;
        }


        /// <summary>
        /// show next dialog
        /// </summary>
        /// <param name="diaType">dialog type</param>
        /// <param name="dialogSectionNum">dialog section number</param>
        /// <returns></returns>
        public bool DisplayNextDialog(DialogType diaType, int dialogSectionNum)
        {
            bool isDialogEnd = false;
            DialogSide dialogSide = DialogSide.None;        //he who talks(player or npc)
            string strPersonName;       //person name
            string strDialogContent;    //dialog info

            //change dialog type
            ChangeDialogType(diaType);

            //get dialog info data
            bool boolFlag = DialogDataMgr.GetInstance().GetNextDialogInfoRecoder(dialogSectionNum, out dialogSide, out strPersonName, out strDialogContent);

            if (boolFlag)
            {
                DisplayDialogInfo(diaType, dialogSide, strPersonName, strDialogContent);
            }
            else
            {
                isDialogEnd = true;
            }

            return isDialogEnd;
        }

        /// <summary>
        /// change dialog type(showing two person or one person or none)
        /// </summary>
        /// <param name="diaType">dialog type</param>
        private void ChangeDialogType(DialogType diaType)
        {
            switch (diaType)
            {
                case DialogType.None:
                    goPlayer.SetActive(false);
                    goNPC_Left.SetActive(false);
                    goNPC_Right.SetActive(false);
                    goSingleDialogArea.SetActive(false);
                    goDoubleDialogArea.SetActive(false);
                    break;
                case DialogType.DoubleDialogs:
                    goPlayer.SetActive(true);
                    goNPC_Left.SetActive(false);
                    goNPC_Right.SetActive(true);
                    goSingleDialogArea.SetActive(false);
                    goDoubleDialogArea.SetActive(true);
                    break;
                case DialogType.SingleDialogs:
                    goPlayer.SetActive(false);
                    goNPC_Left.SetActive(true);
                    goNPC_Right.SetActive(false);
                    goSingleDialogArea.SetActive(true);
                    goDoubleDialogArea.SetActive(false);
                    break;
                default:
                    goPlayer.SetActive(false);
                    goNPC_Left.SetActive(false);
                    goNPC_Right.SetActive(false);
                    goSingleDialogArea.SetActive(false);
                    goDoubleDialogArea.SetActive(false);
                    break;
            }
        }

        /// <summary>
        /// showing dialog info
        /// </summary>
        /// <param name="diaType">dialog type</param>
        /// <param name="dialogSide">dialog side</param>
        /// <param name="strPersonName">person name</param>
        /// <param name="strDialogContent">dialog content</param>
        private void DisplayDialogInfo(DialogType diaType, DialogSide diaSide, string PersonName, string DialogContent)
        {
            switch (diaType)
            {
                case DialogType.None:
                    break;
                case DialogType.DoubleDialogs:
                    //showing person name and dialog content
                    if(!string.IsNullOrEmpty(PersonName)&&!string.IsNullOrEmpty(DialogContent))
                    {
                        if(diaSide == DialogSide.PlayerSide)
                        {
                            TxtPersonName.text = GlobalParaMgr.PlayerName;
                        }
                        else
                        {
                            TxtPersonName.text = PersonName;
                        }
                        TxtDoubleDialogContent.text = DialogContent;

                    }

                    //showing sprites(Player and NPC)
                    switch (diaSide)
                    {
                        case DialogSide.None:
                            break;
                        case DialogSide.PlayerSide:
                            goPlayer.GetComponent<Image>().overrideSprite = SprPlayer[0];       //0 showing color image
                            goNPC_Right.GetComponent<Image>().overrideSprite = SprNPC_Right[1];//1 showing black and white image
                            break;
                        case DialogSide.NPCSide:
                            goPlayer.GetComponent<Image>().overrideSprite = SprPlayer[1];       //0 showing color image
                            goNPC_Right.GetComponent<Image>().overrideSprite = SprNPC_Right[0];// 1 showing black and white image
                            break;
                        default:
                            break;
                    }
                    break;
                case DialogType.SingleDialogs:
                    //showing peroson name and dialog content
                    TxtSingleDialogContent.text = DialogContent;
                    //showing sprite
                    goNPC_Left.GetComponent<Image>().overrideSprite = SprNPC_Left[0];
                    break;
                default:
                    break;
            }
        }
    }
}

