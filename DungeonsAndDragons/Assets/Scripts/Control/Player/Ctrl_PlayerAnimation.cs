/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: Animation control
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
    public class Ctrl_PlayerAnimation : BaseControl   {
        public static Ctrl_PlayerAnimation Instance; //make it instance

        //main character animation
        private PlayerActionState _currentActionState = PlayerActionState.None;

        //define animation clip
        public AnimationClip Ani_idle;         //idle    
        public AnimationClip Ani_Running;      //Running 
        public AnimationClip Ani_BasicAttack1; //basic attack 1
        public AnimationClip Ani_BasicAttack2; //basic attack 2
        public AnimationClip Ani_BasicAttack3; //basic attack 3
        public AnimationClip Ani_MagicTrickA;  //ultimate a
        public AnimationClip Ani_MagicTrickB;  //ultimate b

        //Animation handle
        private Animation _animationHandle;

        //play animation once
        private bool _isSinglePlay = true;

        //animation combo
        private BasicATKCombo _CurATKCombo = BasicATKCombo.BasicATK1;
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            //default animation
            _currentActionState = PlayerActionState.Idle;

            //get animation handle example
            _animationHandle = this.GetComponent<Animation>();

            //Start coroutine, control player animation state
            StartCoroutine("ControlPlayerAnimation");

            //speed up basic attack animation 
            _animationHandle[Ani_BasicAttack1.name].speed = 2.5f;
            _animationHandle[Ani_BasicAttack2.name].speed = 2.5f;
            _animationHandle[Ani_BasicAttack3.name].speed = 2f;

        }

        public void SetCurrentAtionState(PlayerActionState currenActionState)
        {
            //set up current player animation
            _currentActionState = currenActionState;
        }

        /// <summary>
        /// main character animation control
        /// </summary>
        IEnumerator ControlPlayerAnimation()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                switch (_currentActionState)
                {
                    case PlayerActionState.None:

                        break;
                    case PlayerActionState.Idle:
                        _animationHandle.CrossFade(Ani_idle.name);
                        break;
                    case PlayerActionState.Running:
                        _animationHandle.CrossFade(Ani_Running.name);
                        break;
                    case PlayerActionState.BasicAttack:

                        /*attack combo*/
                        switch (_CurATKCombo)
                        {
                            case BasicATKCombo.BasicATK1:
                                if (_isSinglePlay)
                                {
                                    _isSinglePlay = false;
                                    _animationHandle.CrossFade(Ani_BasicAttack1.name);
                                    yield return new WaitForSeconds(Ani_BasicAttack1.length/2.5f);
                                }
                                else
                                {
                                    StartCoroutine("ReturnOriginalAction");
                                }
                                _CurATKCombo = BasicATKCombo.BasicATK2;
                                break;
                            case BasicATKCombo.BasicATK2:
                                if (_isSinglePlay)
                                {
                                    _isSinglePlay = false;
                                    _animationHandle.CrossFade(Ani_BasicAttack2.name);
                                    yield return new WaitForSeconds(Ani_BasicAttack2.length/2.5f);
                                }
                                else
                                {
                                    StartCoroutine("ReturnOriginalAction");
                                }
                                _CurATKCombo = BasicATKCombo.BasicATK3;
                                break;
                            case BasicATKCombo.BasicATK3:
                                if (_isSinglePlay)
                                {
                                    _isSinglePlay = false;
                                    _animationHandle.CrossFade(Ani_BasicAttack3.name);
                                    yield return new WaitForSeconds(Ani_BasicAttack3.length/2f);
                                }
                                else
                                {
                                    StartCoroutine("ReturnOriginalAction");
                                }
                                _CurATKCombo = BasicATKCombo.BasicATK1;
                                break;
                            default:
                                break;
                        }
                       
                        break;
                    case PlayerActionState.MagicTrickA:
                        
                        if (_isSinglePlay)
                        {
                            _isSinglePlay = false;
                            _animationHandle.CrossFade(Ani_MagicTrickA.name);
                            yield return new WaitForSeconds(Ani_MagicTrickA.length);
                        }
                        else
                        {
                            StartCoroutine("ReturnOriginalAction");
                        }
                        break;
                    case PlayerActionState.MagicTrickB:
                      
                        if (_isSinglePlay)
                        {
                            _isSinglePlay = false;
                            _animationHandle.CrossFade(Ani_MagicTrickB.name);
                            yield return new WaitForSeconds(Ani_MagicTrickB.length);
                        }
                        else
                        {
                            StartCoroutine("ReturnOriginalAction");
                        }
                        break;
                    default:
                        break;
                }//Switch end
            }
            
        }

        /// <summary>
        /// make animation playable
        /// </summary>
        IEnumerator ReturnOriginalAction()
        {
            _currentActionState = PlayerActionState.Idle;
            yield return new WaitForSeconds(0.001f);
            _isSinglePlay = true;
        }

        
    }
}

