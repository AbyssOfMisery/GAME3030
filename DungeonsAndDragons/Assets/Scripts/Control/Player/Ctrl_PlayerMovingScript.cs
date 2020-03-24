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

        public float FloPlayerAttackMovingSpeed = 10f;
        // Use this for initialization
        void Start()
        {
            //character control
            cc = this.gameObject.GetComponent<CharacterController>();
            //AttackWhileMoving

            StartCoroutine("AttackWhileMoving");
        }

        /// <summary>
        /// AttackWhileMoving
        /// </summary>
        /// <returns></returns>
        IEnumerator AttackWhileMoving()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
                if (Ctrl_PlayerAnimation.Instance.CurrentActionState == PlayerActionState.BasicAttack)
                {
                    Vector3 vec = transform.forward * FloPlayerAttackMovingSpeed * Time.deltaTime;
                    cc.Move(-vec);
                }
            }
        }

        // Wait end of frame to manage charactercontroller, because gravity is managed by virtual controller
        void Update()
        {
            if ((Ctrl_PlayerAnimation.Instance.CurrentActionState == PlayerActionState.Idle ||
       Ctrl_PlayerAnimation.Instance.CurrentActionState == PlayerActionState.Running) && Ctrl_PlayerAnimation.Instance.CurrentActionState != PlayerActionState.MagicTrickB)
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
        }
//#endif
    }

}