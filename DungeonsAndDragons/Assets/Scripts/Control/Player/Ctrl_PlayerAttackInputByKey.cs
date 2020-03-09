/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer:use keyboard to make player attack
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

namespace Control
{
    public class Ctrl_PlayerAttackInputByKey : BaseControl
    {
        public static event del_PlayerControlWithStr evePlayerControl;

   
        // Update is called once per frame
        void Update()
        {
            //Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL);
            //event 1
            if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_BASIC))
            {
                evePlayerControl?.Invoke(GlobalParameter.INPUT_MGR_ATTACKNAME_BASIC);
            }
            //event 2
            else if(Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A))
            {
                evePlayerControl?.Invoke(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A);
            }
            //event 3
            else if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B))
            {
                evePlayerControl?.Invoke(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B);
            }
        }//update end
    }//class end
}

