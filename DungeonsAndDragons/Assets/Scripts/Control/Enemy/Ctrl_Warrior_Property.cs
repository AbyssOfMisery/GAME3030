/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: Enemy(Attributes)
 *      
 * Description:
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
    public class Ctrl_Warrior_Property : MonoBehaviour
    {
        public int IntPlayerExp = 5;   //add exp per one enemy killed

        public int IntATK = 2;      //attack damage
        public int IntDEF = 2;      //defence


       // private bool _isAlive = true; //check enemy is alive
        public int _MaxHealth = 20;   //Enemy max health
        private float _CurrentHealth = 0;  //current health

        private EnemyState _CurrentState = EnemyState.Idle;         //idle

        public EnemyState CurrentState
        {
            get => _CurrentState;
            set => _CurrentState = value;
        }

        //get this enemy is it alive?
       //public bool IsAlive
       //{
       //    get => _isAlive;
       //    set => _isAlive = value;
       //}
       

        private void Start()
        {
            _CurrentHealth = _MaxHealth;

            //check is this enemy still has health
            StartCoroutine("CheckLifeContinue");
        }

        IEnumerator CheckLifeContinue()
        {

            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                if (_CurrentHealth <= _MaxHealth * 0.01)
                {
                    // IsAlive = false;
                    _CurrentState = EnemyState.Dead;

                    //add exp to player
                    Ctrl_PlayerProperty.Instance.AddEXP(IntPlayerExp);
                    //add number of kills
                    Ctrl_PlayerProperty.Instance.AddKillNumber(1);

                    //dead animation
                    _CurrentState = EnemyState.Dead;
                    //destroy this enemy
                    Destroy(this.gameObject,5f);
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
    }
}


