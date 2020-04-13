/*
 * Title:"Dungoen and dragons"
 *      
 *      mode layer: global value
 *      
 * Description:
 *         save value from globalparamgr script
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

namespace Model {
    public class GlobalParameterData
    {
        //next scenes name
        private ScenesEnum _NextScenesName;

        //player name
        private string _PlayerName = "";

        public ScenesEnum NextScenesName
        {
            get => _NextScenesName;
            set => _NextScenesName = value;
        }
        public string PlayerName {
            get => _PlayerName;
            set => _PlayerName = value;
        }

        private GlobalParameterData() { }

        public GlobalParameterData(ScenesEnum scenesName, string playerName)
        {
            _NextScenesName = scenesName;
            _PlayerName = playerName;
        }

    }

}
