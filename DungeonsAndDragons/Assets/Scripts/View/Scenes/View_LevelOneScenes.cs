/*
 * Title:"Dungoen and dragons"
 *      
 *      View layer: Level one scene control
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

namespace View
{
    public class View_LevelOneScenes : MonoBehaviour
    {
        public GameObject goUINormalATK;        //basic attack
        public GameObject goUIMagicATK_A;       //skill A
        public GameObject goUIMagicATK_B;       //skill B
        public GameObject goUIMagicATK_C;       //skill C
        public GameObject goUIMagicATK_D;       //skill D

        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT2);
            goUIMagicATK_A.GetComponent<View_ATKButtomCDEffect>().EnableSelf() ;
            goUIMagicATK_B.GetComponent<View_ATKButtomCDEffect>().EnableSelf();
            goUIMagicATK_C.GetComponent<View_ATKButtomCDEffect>().DisableSelf();
            goUIMagicATK_D.GetComponent<View_ATKButtomCDEffect>().DisableSelf();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

