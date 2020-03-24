/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: Recovered Obj By Time in gameobject pool
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
    public class RecoveredObjByTime : MonoBehaviour
    {
        public float FloRecoverTime = 1f;  //Recovered Time

        private void OnEnable()
        {
            StartCoroutine("RecoveredGameObjectByTime");
        }

        private void OnDisable()
        {
            StopCoroutine("RecoveredGameObjectByTime");
        }


        /// <summary>
        /// recycle gameobject
        /// </summary>
        /// <returns></returns>
        IEnumerator RecoveredGameObjectByTime()
        {
            yield return new WaitForSeconds(FloRecoverTime);
            PoolManager.PoolsArray["_ParticleSys"].RecoverGameObjectToPools(this.gameObject);

        }
    }

}

