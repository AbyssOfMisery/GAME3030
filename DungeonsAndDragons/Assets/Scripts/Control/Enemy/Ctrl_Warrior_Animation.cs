/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: Enemy Animation
 *      
 * Description:
 *           Enemy Animation
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
    public class Ctrl_Warrior_Animation : BaseControl
    {
        private Ctrl_Warrior_Property _MyProperty;          //self
        private Ctrl_PlayerProperty _PlayerProperty;        //player
        private Animator _Animator;                         //animator
        private bool _IsSingleTimes = true;                 //check if dead animation is played
        
        // Start is called before the first frame update
        void Start()
        {
            _MyProperty = this.gameObject.GetComponent<Ctrl_Warrior_Property>();
            _Animator = this.gameObject.GetComponent<Animator>();
            GameObject goPlayer = GameObject.FindGameObjectWithTag(Tag.Player);

            if(goPlayer)
            {
                _PlayerProperty = goPlayer.GetComponent<Ctrl_PlayerProperty>();
            }

            StartCoroutine("PlayWarriorAnimation_A");

            StartCoroutine("PlayWarriorAnimation_B");
        }

        /// <summary>
        /// Player enemy warrior animation a
        /// </summary>
        /// <returns></returns>
        IEnumerator PlayWarriorAnimation_A()
        {
            yield return new WaitForEndOfFrame();
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
                switch (_MyProperty.CurrentState)
                {
                    case EnemyState.Idle:
                        _Animator.SetFloat("MoveSpeed", 0);
                        _Animator.SetBool("Attack", false);
                        break;
                    case EnemyState.Walking:
                        _Animator.SetFloat("MoveSpeed", 1);
                        _Animator.SetBool("Attack", false);
                        break;
                    case EnemyState.Attack:
                        _Animator.SetFloat("MoveSpeed", 0);
                        _Animator.SetBool("Attack",true);
                        break;
                    default:
                        break;
                }
            }//while end
        }


        /// <summary>
        /// Player enemy warrior animation b
        /// </summary>
        /// <returns></returns>
        IEnumerator PlayWarriorAnimation_B()
        {
            yield return new WaitForEndOfFrame();
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
                switch (_MyProperty.CurrentState)
                {
                    case EnemyState.Hurt:
                        _Animator.SetTrigger("Hurt");
                        break;
                    case EnemyState.Dead:
                        if(_IsSingleTimes)
                        {
                            _IsSingleTimes = false;
                            _Animator.SetTrigger("Dead");
                        }

                        break;
                    default:
                        break;
                }
            }//while end
        }


        /// <summary>
        /// do damage to player(animation event)
        /// </summary>
        public void AttackPlayerByAnimationEvent()
        {
            _PlayerProperty.DecreaseHealthValues(_MyProperty.IntATK);
        }
    }
}

