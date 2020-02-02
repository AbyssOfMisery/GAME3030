/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: player attack
 *      
 * Description:
 *        1. put nearby enemies in a enemy array
 *          1.1 get all enemy and put them in an array
 *          1.2 check enemy array and find out the closest enemy
 *          
 *        2. player will target closest enemy as attack target
 *        
 *        3. response to attack signal. and damage enemy when enemy is in front of players
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
    public class Ctrl_PlayerAttack : BaseControl
    {
        public float _FloMinAttackDistance = 4.0f; //minimum attack range
        public float _FloPlayerRoataionSpeed = 1.0f;

        private List<GameObject> _LisEnemies; //list of enemies
        private Transform _TraNearestEnemy;//get closest enemy postion
        private float _FloMaxDistance = 10.0f;      //enemy and player the maximum distance
      


        private void Awake()
        {
            //register event(Multicast delegation) : player attack inputs
            Ctrl_PlayerAttackInputByKey.evePlayerControl += ResponseBasicAttack;
            Ctrl_PlayerAttackInputByKey.evePlayerControl += ResponseMagicTrickA;
            Ctrl_PlayerAttackInputByKey.evePlayerControl += ResponseMagicTrickB;
        }

        private void Start()
        {
            //Collection initialization
            _LisEnemies = new List<GameObject>();

            //put nearby enemies in a enemy array
            StartCoroutine("PutNearByEnemyToArray");

            //player will target closest enemy as attack target
            StartCoroutine("PlayerRotationEnemy");
        }

        #region response to attacks signal
        /// <summary>
        /// responding basic attack
        /// </summary>
        public void ResponseBasicAttack(string controlType)
        {
            if (controlType == GlobalParameter.INPUT_MGR_ATTACKNAME_BASIC)
            {
                //play basic attack animation
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.BasicAttack);
                //Deal damage to specific enemies
            }
        }

        /// <summary>
        /// responding magic trick a
        /// </summary>
        public void ResponseMagicTrickA(string controlType)
        {
            if (controlType == GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A)
            {
                //play MagicTrickA attack animation
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.MagicTrickA);
                //Deal damage to specific enemies
            }
        }


        /// <summary>
        /// responding magic trick b
        /// </summary>
        public void ResponseMagicTrickB(string controlType)
        {
            if (controlType == GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B)
            {
                //play MagicTrickB attack animation
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.MagicTrickB);
                //Deal damage to specific enemies
            }
        }
        #endregion

        //1. put nearby enemies in a enemy array
        IEnumerator PutNearByEnemyToArray()
        {
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_2);
                // 1.1 get all enemy and put them in an array
                GetEnemiesToArray();
                // 1.2 check enemy array and find out the closest enemy
                GetNearestEnemy();
            }
   

        }
        /// <summary>
        ///  get all enemy and put them in an array
        /// </summary>
        public void GetEnemiesToArray()
        {
            GameObject[] GoEnemies = GameObject.FindGameObjectsWithTag(Tag.Tag_Enemy);
            foreach(GameObject goItem in GoEnemies)
            {
                //check the enemy is alive

                _LisEnemies.Add(goItem);
            }
        }
        /// <summary>
        /// check enemy array and find out the closest enemy
        /// </summary>
        private void GetNearestEnemy()
        {
            if(_LisEnemies != null && _LisEnemies.Count >= 1)
            {
                foreach (GameObject goEnemy in _LisEnemies)
                {
                    float floDistance = Vector3.Distance(this.gameObject.transform.position, goEnemy.transform.position);
                    if (floDistance < _FloMaxDistance)
                    {
                        _FloMaxDistance = floDistance;
                        _TraNearestEnemy = goEnemy.transform;
                    }
                }//foreach end
            }
        }//getnearstenemy() end

        //player will target closest enemy as attack target
        IEnumerator PlayerRotationEnemy()
        {
            while(true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
               if(_TraNearestEnemy != null)
                {
                    float floDistance = Vector3.Distance(this.gameObject.transform.position, _TraNearestEnemy.position);

                    if(floDistance < _FloMinAttackDistance)
                    {
                        //minimum attack range
                        //this.transform.LookAt(_TraNearestEnemy);
                        this.transform.rotation = 
                            Quaternion.Slerp(this.transform.rotation,
                            Quaternion.LookRotation(new Vector3(_TraNearestEnemy.position.x,0,_TraNearestEnemy.position.z)-new Vector3(this.gameObject.transform.position.x,0,this.gameObject.transform.position.z)),
                            _FloPlayerRoataionSpeed);
                    }
         
                }
            }
        }
    }
}


