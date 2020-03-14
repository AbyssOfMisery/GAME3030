/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: player movement control scripts
 *      
 * Description:
 *         Using easytouch plugin to control player
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
    public class Ctrl_PlayerMovingScript : BaseControl
    {
//#if UNITY_ANDROID || UNITY_IPHONE
        private CharacterController cc; //character controller 

        // Use this for initialization
        void Start()
        {

            cc = this.gameObject.GetComponent<CharacterController>();
        }


        // Wait end of frame to manage charactercontroller, because gravity is managed by virtual controller
        void Update()
        {

                if ((ETCInput.GetAxis("Vertical") != 0 || ETCInput.GetAxis("Horizontal") != 0) && (Ctrl_PlayerAnimation.Instance.CurrentActionState == PlayerActionState.Idle ||
                Ctrl_PlayerAnimation.Instance.CurrentActionState == PlayerActionState.Running))
                {
                    //anim.CrossFade("Run");
                    if (UnityHelper.GetInstance().GetSmallTime(GlobalParameter.INTERVAL_TIME_0DOT3))
                    {
                        Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.Running);
                    }
                }

                else if ((ETCInput.GetAxis("Vertical") == 0 && ETCInput.GetAxis("Horizontal") == 0))
                {
                    //anim.CrossFade("Idle");
                    if (UnityHelper.GetInstance().GetSmallTime(GlobalParameter.INTERVAL_TIME_0DOT3))
                    {
                        Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.Idle);
                    }
                }

           
        }
//#endif
    }

}