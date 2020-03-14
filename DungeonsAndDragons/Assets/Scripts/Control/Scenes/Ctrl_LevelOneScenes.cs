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


namespace Control
{
    public class Ctrl_LevelOneScenes : BaseControl
    {
        public Transform[] TraSpawnEnemyPosition_1; // enemy spawn position

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpwanEnemy(5));
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
                int randomNumber = UnityHelper.GetInstance().GetRandomNum(1,8);
                //TraSpawnEnemyPosition_1 = new Transform[randomNumber];
                GameObject goEnemy = Resources.Load("Prefabs/Enemy/skeleton_warrior_green",typeof(GameObject)) as GameObject;
                goEnemy.transform.position = new Vector3(TraSpawnEnemyPosition_1[randomNumber].position.x, TraSpawnEnemyPosition_1[randomNumber].position.y, TraSpawnEnemyPosition_1[randomNumber].position.z);
                GameObject goEnemyClone = GameObject.Instantiate(goEnemy);
                //enemy position
 
                goEnemyClone.transform.parent = TraSpawnEnemyPosition_1[randomNumber].parent;
                
          
            }
        }
    }
}
