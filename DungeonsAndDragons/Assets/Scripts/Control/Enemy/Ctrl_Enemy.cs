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
    public class Ctrl_Enemy : BaseControl
    {
        private bool _isAlive = true; //check enemy is alive
        public int _MaxHealth = 20;   //Enemy max health
        private float _CurrentHealth = 0;  //current health

        //get this enemy is it alive?
        public bool IsAlive {
            get => _isAlive;
            set => _isAlive = value;
        }

        private void Start()
        {
            _CurrentHealth = _MaxHealth;

            //check is this enemy still has health
            StartCoroutine("CheckLifeContinue");
        }

        IEnumerator CheckLifeContinue()
        {
           
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                if (_CurrentHealth <= _MaxHealth * 0.01)
                {
                    IsAlive = false;
                    //destroy this enemy
                    Destroy(this.gameObject);
                }
            }

        }

        /// <summary>
        /// damage to this enemy
        /// </summary>
        /// <param name="damageValue"></param>
        public void OnDamage(int damageValue)
        {
            Debug.Log("damaged");
            int damageValues = 0;

            damageValues = Mathf.Abs(damageValue);
            if(damageValues > 0)
            {
                _CurrentHealth -= damageValue;
            }
        }
    }
}
