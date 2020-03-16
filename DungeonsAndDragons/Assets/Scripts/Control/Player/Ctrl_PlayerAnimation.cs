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

        //running audio clip
        public AudioClip AcPlayerRunning;

        //Animation handle
        private Animation _animationHandle;

        //animation combo
        private BasicATKCombo _CurATKCombo = BasicATKCombo.BasicATK1;

        public PlayerActionState CurrentActionState {
            get => _currentActionState;
          }

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
                switch (CurrentActionState)
                {

                    case PlayerActionState.BasicAttack:

                        /*attack combo*/
                        switch (_CurATKCombo)
                        {
                            case BasicATKCombo.BasicATK1:
                                _CurATKCombo = BasicATKCombo.BasicATK2;
                                _animationHandle.CrossFade(Ani_BasicAttack1.name);
                                AudioManager.PlayAudioEffectA("BeiJi_DaoJian_3");
                                yield return new WaitForSecondsRealtime(Ani_BasicAttack1.length / 2.5f);
                                _currentActionState = PlayerActionState.Idle;
                          

                                break;
                            case BasicATKCombo.BasicATK2:
                                _CurATKCombo = BasicATKCombo.BasicATK3;
                                _animationHandle.CrossFade(Ani_BasicAttack2.name);
                                AudioManager.PlayAudioEffectA("BeiJi_DaoJian_2");
                                yield return new WaitForSecondsRealtime(Ani_BasicAttack2.length / 2.5f);
                                _currentActionState = PlayerActionState.Idle;
              
                                break;
                            case BasicATKCombo.BasicATK3:
                                _CurATKCombo = BasicATKCombo.BasicATK1;
                                _animationHandle.CrossFade(Ani_BasicAttack3.name);
                                AudioManager.PlayAudioEffectA("BeiJi_DaoJian_1");
                                yield return new WaitForSecondsRealtime(Ani_BasicAttack3.length / 2f);
                                _currentActionState = PlayerActionState.Idle;

                                break;
                            default:
                                break;
                        }
                       
                        break;
                    case PlayerActionState.MagicTrickA:
                        _animationHandle.CrossFade(Ani_MagicTrickA.name);
                        AudioManager.PlayAudioEffectA("Player_MagicA");
                        yield return new WaitForSecondsRealtime(Ani_MagicTrickA.length);
                        _currentActionState = PlayerActionState.Idle;
                        break;
                    case PlayerActionState.MagicTrickB:
                        _animationHandle.CrossFade(Ani_MagicTrickB.name);
                        AudioManager.PlayAudioEffectA("Player_MagicB");
                        yield return new WaitForSecondsRealtime(Ani_MagicTrickB.length);
                        _currentActionState = PlayerActionState.Idle;
                        break;
                    case PlayerActionState.None:

                        break;
                    case PlayerActionState.Idle:
                        _animationHandle.CrossFade(Ani_idle.name);
                        break;
                    case PlayerActionState.Running:
                        _animationHandle.CrossFade(Ani_Running.name);

                        //running audio effect
                        AudioManager.PlayAudioEffectB(AcPlayerRunning);
                        yield return new WaitForSeconds(AcPlayerRunning.length);
                        break;
                    default:
                        break;
                }//Switch end
            }
            
        }


        /// <summary>
        /// partical effect magic A
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_PlayerMagicA()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            GameObject goMagicA = ResourceMgr.GetInstance().LoadAsset("ParticleProps/Player_MagicA(bruceSkill)", true,this.transform);

            //play audio clip

        }

        /// <summary>
        /// partical effect magic B
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_PlayerMagicB()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            GameObject goMagicA = ResourceMgr.GetInstance().LoadAsset("ParticleProps/Player_MagicB(groundBrokeRed)", true, this.transform);
            goMagicA.transform.position = transform.position + transform.TransformDirection(new Vector3(0f, 0f, 5f));
            //play audio clip

        }

    }
}

