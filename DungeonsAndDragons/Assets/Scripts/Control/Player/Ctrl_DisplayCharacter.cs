/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: Display characters
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

namespace Control
{
    public class Ctrl_DisplayCharacter : MonoBehaviour
    {
        public AnimationClip AnimIdle;  //animation clip
        public AnimationClip AnimRunning;
        public AnimationClip AnimAttack;

        private Animation _AnimCurrentAnimation; //current animation
        private float _FloIntervalTimes = 3.0f;
        private int _IntRandomAnimation; //random animation number

        private void Start()
        {
            _AnimCurrentAnimation = this.GetComponent<Animation>();
            DisplayCharacterAnim(1);
        }

        /// <summary>
        /// algorithm: every 3 seconds, will random display a animation
        /// </summary>
        private void Update()
        {
            _FloIntervalTimes -= Time.deltaTime;
            if(_FloIntervalTimes<=0)
            {
                _FloIntervalTimes = 3.0f;
                //get a random number
                _IntRandomAnimation = Random.Range(1,4); //you must increase max vaule by 1
                DisplayCharacterAnim(_IntRandomAnimation);
            }

        }

        /// <summary>
        /// display animation
        /// </summary>
        internal void DisplayCharacterAnim(int intPlayingNum)
        {
            switch(intPlayingNum)
            {
                case 1:
                    DisplayIdle();
                    break;
                case 2:
                    DisplayRunning();
                    break;
                case 3:
                    DisplayAttack();
                    break;
            }
        }

        /// <summary>
        /// display idle animation
        /// </summary>
        internal void DisplayIdle()
        {
            if(_AnimCurrentAnimation)
            {
                //_AnimCurrentAnimation.Play(AnimIdle.name);
                _AnimCurrentAnimation.CrossFade(AnimIdle.name);
            }
        }

        /// <summary>
        /// display Running animation
        /// </summary>

        internal void DisplayRunning()
        {
            //_AnimCurrentAnimation.Play(AnimRunning.name);
            _AnimCurrentAnimation.CrossFade(AnimRunning.name);
        }

        /// <summary>
        /// display Attack animation
        /// </summary>
        internal void DisplayAttack()
        {
            //_AnimCurrentAnimation.Play(AnimAttack.name);
            _AnimCurrentAnimation.CrossFade(AnimAttack.name);
        }
    }
}

