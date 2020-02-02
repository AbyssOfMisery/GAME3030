/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: use easy touch to make attack events
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

namespace Control {
    public class Ctrl_PlayerAttackInputByET : BaseControl
    {

        void Update()
        {
            if (ETCInput.GetButton(GlobalParameter.BUTTON_ATTACK))
            {
                // anim.CrossFade("Attack1");
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.BasicAttack);
            }

            if (ETCInput.GetButtonDown(GlobalParameter.BUTTON_MAGIC_A))
            {
                // anim.CrossFade("Attack1");
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.MagicTrickA);
            }

            if (ETCInput.GetButtonDown(GlobalParameter.BUTTON_MAGIC_B))
            {
                // anim.CrossFade("Attack1");
                
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.MagicTrickB);
            }
        }

    }
}

