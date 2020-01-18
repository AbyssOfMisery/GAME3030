/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: logon scenes control script
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
using UnityEngine.SceneManagement;

using Global;
using Kernal;

namespace Control{
    public class Ctrl_LogonScenes : BaseControl
    {
        public static Ctrl_LogonScenes Instance; // add instance
                                                 // Start is called before the first frame update
        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// go to next scenes
        /// </summary>
        internal void EnterNextScenes()
        {
            //turn to logon scenes
            //you have add level one on ScenesEnum dictionary
            //GlobalParaMgr.NextScenesName = ScenesEnum.LevelOne;
            //SceneManager.LoadScene(ConvertEnumToString.GetInstance().GetStrByEnumScenes(ScenesEnum.LoadingScenes));
            base.EnterNextScenes(ScenesEnum.LevelOne);
        }
    }

}
