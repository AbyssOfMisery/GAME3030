/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer:us keyboard to make player attack
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
            //event 1
            if(Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL))
            {
                if(evePlayerControl != null)
                {
                    evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL);
                }
            }
            //event 2
            else if(Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A))
            {

                if (evePlayerControl != null)
                {
                    evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A);
                    print(evePlayerControl.ToString());
                }
            }
            //event 3
            else if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B))
            {
                if (evePlayerControl != null)
                {
                    evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B);
                }
            }
        }//update end
    }//class end
}

