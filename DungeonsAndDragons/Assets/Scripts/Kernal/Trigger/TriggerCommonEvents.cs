/*
 * Title:"Dungoen and dragons"
 *      
 *      kernal layer: common trigger script
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


namespace Kernal
{
    public enum CommonTriggerType
    {
        None,
        NPC1_Dialog,
        NPC2_Dialog,
        NPC3_Dialog,
        NPC4_Dialog,
        NPC5_Dialog,
        Enemy1_Dialog,
        Enemy2_Dialog,
        Enemy3_Dialog,
        SaveDataScenes,
        LoadDataScenes,
        EnableScript1,
        EnableScript2,
        ActiveConfigWindows,
        ActiveDIalogWindows,
    }

    /// <summary>
    /// common trigger
    /// </summary>
    /// <param name="CTT"></param>
    public delegate void del_CommonTrigger(CommonTriggerType CTT);

    public class TriggerCommonEvents : MonoBehaviour
    {
        //register event
        public static event del_CommonTrigger eveCommonTrigger;

        //enum
        public CommonTriggerType triggerType = CommonTriggerType.None;

        //player tag
        public string TagNameByPlayer = "Player";

       
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == TagNameByPlayer)
            {
                if(eveCommonTrigger !=null)
                {
                    eveCommonTrigger(triggerType);
                }
            }
        }

    }

}
