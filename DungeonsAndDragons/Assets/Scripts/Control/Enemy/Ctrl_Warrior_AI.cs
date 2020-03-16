/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: Enemy AI
 *      
 * Description:
 *         Path finding, attacks or other states
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
    public class Ctrl_Warrior_AI : BaseControl
    {
        public float FloMoveSpeed = 1.0f;  //moving speed
        public float floRoataionSpeed = 1.0f; //rotaion speed
        public float FloAttackDistance = 2f;    //attack range
        public float FloatCordonDistance = 5f;     //alert range

        public float FloThinkInterval = 1f;         //run program 1f per once

        private GameObject goPlayer;        //player

        private Transform _MyTransform;     //enemy position

        private Ctrl_BaseEnemyProperty _MyProperty;      //Attributes

        private CharacterController _cc;                //charactercontroller component
        // Start is called before the first frame update
        void Start()
        {
            //get this enemy position
            _MyTransform = this.gameObject.transform;
            //get player
            goPlayer = GameObject.FindGameObjectWithTag(Tag.Player);

            //get Attributes instance
            _MyProperty = this.gameObject.GetComponent<Ctrl_BaseEnemyProperty>();

            //get character contronller
            _cc = this.gameObject.GetComponent<CharacterController>();

            /* get random property number for each enemy*/
            FloMoveSpeed = UnityHelper.GetInstance().GetRandomNum(1,2);
            FloAttackDistance = UnityHelper.GetInstance().GetRandomNum(1, 3);
            FloatCordonDistance = UnityHelper.GetInstance().GetRandomNum(4, 15);
            FloThinkInterval = UnityHelper.GetInstance().GetRandomNum(1, 3);

            //use ThinkProcess
            StartCoroutine("ThinkProcess");
            //use MovingProcess
            StartCoroutine("MovingProcess");
        }

        /// <summary>
        /// check with state or action to go next
        /// </summary>
        /// <returns></returns>
        IEnumerator ThinkProcess()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
            while (true)
            {
                yield return new WaitForSeconds(FloThinkInterval);
                if(_MyProperty && _MyProperty.CurrentState != EnemyState.Dead)
                {
                    //get player position
                    Vector3 VecPlayer = goPlayer.GetComponent<Transform>().position;

                    //get player and enemy's distance
                    float floDistance = Vector3.Distance(VecPlayer, _MyTransform.position);

                    //check distence
                    if (floDistance < FloAttackDistance)
                    {
                        //attack state
                        _MyProperty.CurrentState = EnemyState.Attack;

                    }
                    else if (floDistance < FloatCordonDistance)
                    {
                        //alert (Chase)
                        _MyProperty.CurrentState = EnemyState.Walking;
                    }
                    else
                    {
                        //enemy is in idle state
                        _MyProperty.CurrentState = EnemyState.Idle;
                    }
                }
                
            }
        }

        /// <summary>
        /// path finding
        /// </summary>
        /// <returns></returns>
        IEnumerator MovingProcess()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT02);
                if (_MyProperty && _MyProperty.CurrentState != EnemyState.Dead)
                {
                    //face to player
                    UnityHelper.GetInstance().FaceToGoal(this.gameObject.transform,goPlayer.transform, floRoataionSpeed);
                    //moving to player or just moving

                    switch (_MyProperty.CurrentState)
                    {
                        case EnemyState.Walking:
                            Vector3 v = Vector3.ClampMagnitude((goPlayer.transform.position-_MyTransform.position), FloMoveSpeed * Time.deltaTime);
                            _cc.Move(v);
                            break;
                        //when enemy is hurted they will move one step backward
                        case EnemyState.Hurt:
                            Vector3 vec = transform.forward * FloMoveSpeed * Time.deltaTime; ;
                            _cc.Move(-vec);
                            break;
                        default:

                            break;
                    }

                }
            }
        }

 
    }
}

