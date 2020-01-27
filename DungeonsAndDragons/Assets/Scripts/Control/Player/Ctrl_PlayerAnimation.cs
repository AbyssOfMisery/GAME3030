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

        }

        // Update is called once per frame
        void Update()
        {
            //main character animation control
            ControlPlayerAnimation(_currentActionState);
        }

        public void SetCurrentAtionState(PlayerActionState currenActionState)
        {
            //set up current player animation
            _currentActionState = currenActionState;
        }

        /// <summary>
        /// main character animation control
        /// </summary>
        private void ControlPlayerAnimation(PlayerActionState currentActionState)
        {
            switch (currentActionState)
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
                   //print(GetType() + "/play animation, basic attack");
                    _animationHandle.CrossFade(Ani_BasicAttack1.name);
                    break;
                case PlayerActionState.MagicTrickA:
                   // print(GetType() + "/play animation, MagicTrickA");
                    _animationHandle.CrossFade(Ani_MagicTrickA.name);
                    break;
                case PlayerActionState.MagicTrickB:
                    //print(GetType() + "/play animation, MagicTrickB");
                    _animationHandle.CrossFade(Ani_MagicTrickB.name);
                    break;
                default:
                    break;
            }
        }
    }
}

