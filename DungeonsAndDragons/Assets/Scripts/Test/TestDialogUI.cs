/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: dialog UI testing 
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


namespace View
{
    public class TestDialogUI : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs, 1);
        }

        public void DiaplayNextDialogInfo()
        {
           bool Result = DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs,1);
           if(Result)
            {
                Log.Write(GetType() + "/DiaplayNextDialogInfo()/dialog end");
            }
            Log.SyncLogArrayToFile();
        }
    }

}
