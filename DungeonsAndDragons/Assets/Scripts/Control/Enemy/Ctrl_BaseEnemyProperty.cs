/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: Enemy property parent script
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

namespace Control {

    public class Ctrl_BaseEnemyProperty : BaseControl
    {
        public int PlayerExp = 0;   //add exp per one enemy killed
        public int ATK = 0;      //attack damage
        public int DEF = 0;      //defence
        public int MaxHealth = 0;   //Enemy max health

        private float _CurrentHealth = 0;  //current health

        private EnemyState _CurrentState = EnemyState.Idle;         //idle

        public EnemyState CurrentState
        {
            get => _CurrentState;
            set => _CurrentState = value;
        }

        private void OnEnable()
        {
            //check is this enemy still has health
            StartCoroutine("CheckLifeContinue");
        }

        private void OnDisable()
        {
            //check is this enemy still has health
            StopCoroutine("CheckLifeContinue");
        }

        public void RunMethodInChildren()
        {
            _CurrentHealth = MaxHealth;

        }

        IEnumerator CheckLifeContinue()
        {

            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                if (_CurrentHealth <= MaxHealth * 0.01)
                {
                    // IsAlive = false;
                    _CurrentState = EnemyState.Dead;

                    //add exp to player
                    Ctrl_PlayerProperty.Instance.AddEXP(PlayerExp);
                    //add number of kills
                    Ctrl_PlayerProperty.Instance.AddKillNumber(1);

                    //dead animation
                    _CurrentState = EnemyState.Dead;
                    //destroy this enemy
                    //Destroy(this.gameObject, 5f);
                    StartCoroutine("RecoverEnemy");
                }
            }

        }

        /// <summary>
        /// damage to this enemy
        /// </summary>
        /// <param name="damageValue"></param>
        public void OnDamage(int damageValue)
        {
            // Debug.Log("damaged");
            int damageValues = 0;

            //hurt animation
            _CurrentState = EnemyState.Hurt;

            damageValues = Mathf.Abs(damageValue);
            if (damageValues > 0)
            {
                _CurrentHealth -= damageValue;
            }
        }

        /// <summary>
        /// recover enemy object to pool
        /// </summary>
        /// <returns></returns>
        IEnumerator RecoverEnemy()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            //reset enemy state and health
            _CurrentHealth = MaxHealth;
            CurrentState = EnemyState.Idle;
            //recover object
            PoolManager.PoolsArray["_Enemies"].RecoverGameObjectToPools(this.gameObject);
        }
    }
}


