/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: level one scene game manager
 *      
 * Description:
 *      1: spawn random Enemies with random position
 *      2: ect;
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
using Model;

namespace Control
{
    public class Ctrl_LevelOneScenes : BaseControl
    {
        public AudioClip Acbackground;              //background audioclip

        public Transform[] TraSpawnEnemyPosition_1; // enemy spawn position

        public bool level0 = true;

        //basic particle effect
        public GameObject[] goParticleEffects;
        //pool gameobject enemy
        public GameObject[] goEnemyWarrior; 
        private void Awake()
        {
            //when player level up it will show level up particle effect
            PlayerExtenalData.evePlayerExtenalData += LevelUp;
        }
        // Start is called before the first frame update
        IEnumerator Start()
        {
            //background music
            AudioManager.SetAudioBackgroundVolumns(0.3f);
            AudioManager.SetAudioEffectVolumns(1f);
            AudioManager.PlayBackground(Acbackground);


            StartCoroutine(SpwanEnemy(4));
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            StartCoroutine(SpwanEnemy(4));
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            StartCoroutine(SpwanEnemy(4));
        }

        /// <summary>
        /// spawn enemys
        /// </summary>
        /// <param name="createEnemies">enemy amounts</param>
        /// <returns></returns>
        IEnumerator SpwanEnemy(int createEnemies)
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            for (int i = 1; i <= createEnemies; ++i)
            {
               
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                int randomNumber = UnityHelper.GetInstance().GetRandomNum(0, 7);
                //load enemy
                //GameObject goEnemyClone = ResourceMgr.GetInstance().LoadAsset(GetRandomEnemyType(), true, TraSpawnEnemyPosition_1[randomNumber]);
                int intRandomNum = UnityHelper.GetInstance().GetRandomNum(0, 1);
                goEnemyWarrior[intRandomNum].transform.position = TraSpawnEnemyPosition_1[randomNumber].position;
                //add enemy object to object pool
                PoolManager.PoolsArray["_Enemies"].GetGameObjectByPool(goEnemyWarrior[intRandomNum], goEnemyWarrior[intRandomNum].transform.position,Quaternion.identity);
                AudioManager.PlayAudioEffectA("EnemyDisplayEffect");
                //particle effect
                EnemySpawnParticleEffect(goEnemyWarrior[intRandomNum]);
            }
        }
         
        public int GetRandomEnemyType()
        {
            int intRandomNum = UnityHelper.GetInstance().GetRandomNum(1, 2);
            return intRandomNum;
        }
       
        //spawn enemy particle effect
        private void EnemySpawnParticleEffect(GameObject EnemyWarrior)
        {
           // StartCoroutine(LoadParticleEffectMethod(GlobalParameter.INTERVAL_TIME_0DOT1,
           //"ParticleProps/EnemyPoint", true, EnemyWarrior.transform.position +transform.TransformDirection(0f,2f,0f), EnemyWarrior.transform, "EnemyDisplayEffect", 0));
            goParticleEffects[0].transform.position = EnemyWarrior.transform.position + EnemyWarrior.transform.TransformDirection(new Vector3(0f, 1.5f, 0f));
            PoolManager.PoolsArray["_ParticleSys"].GetGameObjectByPool(goParticleEffects[0], goParticleEffects[0].transform.position, Quaternion.identity);
        }


        /// <summary>
        /// player level up
        /// </summary>
        /// <param name="kv"></param>
        private void LevelUp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Level"))
            {
                if(level0)
                {
                    level0 = false;
                }
                else
                {
                    PlayerLevelUp();
                }

            }
        }

        //player level up particle effect
        private void PlayerLevelUp()
        {
            //level up effect
            ResourceMgr.GetInstance().LoadAsset("ParticleProps/Player_LvUp",true,this.transform);
            //audio
            AudioManager.PlayAudioEffectA("LevelUp");

        }
    }
}
