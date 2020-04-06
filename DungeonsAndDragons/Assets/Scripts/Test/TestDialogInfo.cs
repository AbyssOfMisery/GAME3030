/*
 * Title:"Dungoen and dragons"
 *      
 *      Common layer: test dialog manager
 *      
 * Description:
 *        just testing
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
using Kernal;

namespace View
{
    public class TestDialogInfo : MonoBehaviour
    {
        public Text TxtSide;
        public Text TxtPersonName;
        public Text TxtPersonContent;

        public void DisplayerNextDialogInfo()
        {
            DialogSide dialogSide = DialogSide.None;
            string strDialogPersonName;
            string strDialogPersonContent;

            bool result = DialogDataMgr.GetInstance().GetNextDialogInfoRecoder(2,out dialogSide, out strDialogPersonName,out strDialogPersonContent);
            
            if(result)
            {
                switch (dialogSide)
                {
                    case DialogSide.None:
                        break;
                    case DialogSide.PlayerSide:
                        TxtSide.text = "player";
                        break;
                    case DialogSide.NPCSide:
                        TxtSide.text = "npc";
                        break;
                    default:
                        break;
                }
                TxtPersonName.text = strDialogPersonName;
                TxtPersonContent.text = strDialogPersonContent;
            }
            else
            {
                TxtPersonName.text = "no output";
                TxtPersonContent.text = "no output";
            }
            Log.SyncLogArrayToFile();
        }
    }

}

