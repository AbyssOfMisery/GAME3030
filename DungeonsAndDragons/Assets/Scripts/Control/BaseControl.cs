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
    }

}
