/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: parent control layer
 *      
 * Description:
 *         inherit other control script public functions.
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
using UnityEngine.SceneManagement;

using Global;
using Kernal;

namespace Control
{
    public class BaseControl : MonoBehaviour
    {

        /// <summary>
        /// go to next scenes
        /// </summary>
        /// <param name="scenesEnumName">scenes enum names</param>
        protected void EnterNextScenes(ScenesEnum scenesEnumName)
        {
            //turn to logon scenes
            //you have add level one on ScenesEnum dictionary
            GlobalParaMgr.NextScenesName = scenesEnumName;
            SceneManager.LoadScene(ConvertEnumToString.GetInstance().GetStrByEnumScenes(ScenesEnum.LoadingScenes));
        }
        /// <summary>
        /// common function: attack to enemy
        /// </summary>
        /// <param name="attackArea">attack range</param>
        /// <param name="AttackPowerMultiple">multiple damage</param>
        /// <param name="isDirection">does it have diretion</param>
        protected void AttackEnemy(List<GameObject> ListEnemies, Transform traNearestEnemy, float attackArea, int AttackPowerMultiple, bool isDirection = true)
        {
            //Parameter check
            if (ListEnemies == null || ListEnemies.Count <= 0)
            {
                traNearestEnemy = null;
                return;
            }

            foreach (GameObject enemyItem in ListEnemies)
            {
                //make sure this gameobject is still exist

                // if (enemyItem && enemyItem.GetComponent<Ctrl_Enemy>())
                if (enemyItem && enemyItem.GetComponent<Ctrl_BaseEnemyProperty>())
                {
                    //check if enemy is alive
                    //if (enemyItem.GetComponent<Ctrl_Enemy>().IsAlive)
                    if (enemyItem.GetComponent<Ctrl_BaseEnemyProperty>().CurrentState != EnemyState.Dead)
                    {

                        //check enemy and player distance 
                        float floDistance = Vector3.Distance(this.gameObject.transform.position, enemyItem.transform.position);
                        //check player rotation(is player facing enemy or is enemy facing player)
                        if (isDirection)
                        {
                            //Vector subtraction
                            Vector3 dir = (enemyItem.transform.position - this.gameObject.transform.position).normalized;
                            //check player and enemy angle(use vertor point multiplication)
                            float floAngleDirection = Vector3.Dot(dir, this.gameObject.transform.forward);
                            //if palyer and enemy has same dirction and within attack range. so player can damage enemy
                            if (floAngleDirection > 0 && floDistance <= attackArea)
                            {

                                enemyItem.SendMessage("OnDamage", Ctrl_PlayerProperty.Instance.GetCurrentATK() * AttackPowerMultiple, SendMessageOptions.DontRequireReceiver);
                            }
                        }
                        else
                        {
                            //if palyer and enemy has same dirction and within attack range. so player can damage enemy
                            if (floDistance <= attackArea)
                            {

                                enemyItem.SendMessage("OnDamage", Ctrl_PlayerProperty.Instance.GetCurrentATK() * AttackPowerMultiple, SendMessageOptions.DontRequireReceiver);
                            }
                        }


                    }

                }

            }
        }



        /// <summary>
        /// Load ParticleEffect Method
        /// </summary>
        /// <param name="internalTime">wait timer</param>
        /// <param name="strPath">path </param>
        /// <param name="isUseCatch"></param>
        /// <param name="particleEffectPosition"></param>
        /// <param name="tranParent"></param>
        /// <param name="strAudio"></param>
        /// <param name="destoryTime"></param>
        /// <returns></returns>
        //common function for loading particle effect
         public  IEnumerator LoadParticleEffectMethod(float internalTime, string strPath, bool isUseCatch,
            Vector3 particleEffectPosition, Transform tranParent, string strAudio=null, float destoryTime =0)
        {
            yield return new WaitForSeconds(internalTime);

            GameObject PlayerBasicATKParticleEffect = ResourceMgr.GetInstance().LoadAsset(strPath, isUseCatch, this.transform);
            PlayerBasicATKParticleEffect.transform.position = particleEffectPosition;
            if (tranParent)
            {
                PlayerBasicATKParticleEffect.transform.parent = tranParent;
            }

            if(!string.IsNullOrEmpty(strAudio))
            {
                AudioManager.PlayAudioEffectA(strAudio);
            }

            //destroy this particle object
            if(destoryTime > 0)
            {
                Destroy(PlayerBasicATKParticleEffect, destoryTime);
            }

        }
    }

}
