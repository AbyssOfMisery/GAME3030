/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: player attack
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

namespace Control {
    public class Ctrl_PlayerAttack : BaseControl
    {
        private void Awake()
        {
            //register event(Multicast delegation) : player attack inputs
            Ctrl_PlayerAttackInputByKey.evePlayerControl += ResponseBasicAttack;
            Ctrl_PlayerAttackInputByKey.evePlayerControl += ResponseMagicTrickA;
            Ctrl_PlayerAttackInputByKey.evePlayerControl += ResponseMagicTrickB;
        }
        /// <summary>
        /// responding basic attack
        /// </summary>
        public void ResponseBasicAttack(string controlType)
        {
            if(controlType == "BasicAttack")
            {
                //play basic attack animation
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.BasicAttack);
                //Deal damage to specific enemies
            }
        }

        /// <summary>
        /// responding magic trick a
        /// </summary>
        public void ResponseMagicTrickA(string controlType)
        {
            if (controlType == "MagicTrickA")
            {
                //play MagicTrickA attack animation
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.MagicTrickA);
                //Deal damage to specific enemies
            }
        }


        /// <summary>
        /// responding magic trick b
        /// </summary>
        public void ResponseMagicTrickB(string controlType)
        {
            if (controlType == "MagicTrickB")
            {
                //play MagicTrickB attack animation
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.MagicTrickB);
                //Deal damage to specific enemies
            }
        }

    }
}


