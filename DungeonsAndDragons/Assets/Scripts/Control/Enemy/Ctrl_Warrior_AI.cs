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
    public class Ctrl_Warrior_AI : MonoBehaviour
    {
        public float FloMoveSpeed = 1.0f;  //moving speed
        public float floRoataionSpeed = 1.0f; //rotaion speed
        private GameObject goPlayer;        //player

        private Transform _MyTransform;     //enemy position

        private Ctrl_Warrior_Property _MyProperty;      //Attributes

        private CharacterController _cc;                //charactercontroller component
        // Start is called before the first frame update
        void Start()
        {
            //get this enemy position
            _MyTransform = this.gameObject.transform;
            //get player
            goPlayer = GameObject.FindGameObjectWithTag(Tag.Player);

            //get Attributes instance
            _MyProperty = this.gameObject.GetComponent<Ctrl_Warrior_Property>();

            //get character contronller
            _cc = this.gameObject.GetComponent<CharacterController>(); 

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
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                if(_MyProperty && _MyProperty.CurrentState != EnemyState.Dead)
                {
                    //get player position
                    Vector3 VecPlayer = goPlayer.GetComponent<Transform>().position;

                    //get player and enemy's distance
                    float floDistance = Vector3.Distance(VecPlayer, _MyTransform.position);

                    //check distence
                    if (floDistance < 2)
                    {
                        //attack state
                        _MyProperty.CurrentState = EnemyState.Attack;

                    }
                    else if (floDistance < 5)
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
                yield return new WaitForSeconds(0.02f);
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

                        default:

                            break;
                    }

                }
            }
        }

 
    }
}

