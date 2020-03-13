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

using Kernal;
using Global;
using Model;

namespace Control {
    public class Ctrl_PlayerAttackInputByET : BaseControl
    {
//#if UNITY_ANDROID || UNITY_IPHONE
        public static Ctrl_PlayerAttackInputByET Instance; // instance
        //event player control animation
        public static event del_PlayerControlWithStr evePlayerControl;

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// response to basic attack
        /// </summary>
        public void ResponseATKByBasic()
        {
           evePlayerControl?.Invoke(GlobalParameter.INPUT_MGR_ATTACKNAME_BASIC);
        }
        /// <summary>
        /// response to magic a
        /// </summary>
        public void ResponseATKByMagicA()
        {
           evePlayerControl?.Invoke(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A);
        }
        /// <summary>
        /// response to magic b
        /// </summary>
        public void ResponseATKByMagicB()
        {
           evePlayerControl?.Invoke(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B);
        }

        /// <summary>
        /// response to magic c
        /// </summary>
        public void ResponseATKByMagicC()
        {
            evePlayerControl?.Invoke(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_C);
        }

        /// <summary>
        /// response to magic D
        /// </summary>
        public void ResponseATKByMagicD()
        {
            evePlayerControl?.Invoke(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_D);
        }
//#endif
    }//class end
}

