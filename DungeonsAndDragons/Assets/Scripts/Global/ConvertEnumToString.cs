/*
 * Title:"Dungoen and dragons"
 *      
 *      Common layer: Covert enum to string
 *      
 * Description:
 *         Get examples of instances
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

namespace Global
{
    public class ConvertEnumToString
    {
        private static ConvertEnumToString _Instance; // Instance

        //put all Enum scenes together
        private Dictionary<ScenesEnum, string> _DicScenesEnumLib;

        //Create Constructor
        private ConvertEnumToString()
        {
            _DicScenesEnumLib = new Dictionary<ScenesEnum, string>();
            _DicScenesEnumLib.Add(ScenesEnum.StartScenes, "1_StartScenes");
            _DicScenesEnumLib.Add(ScenesEnum.LogonScenes, "2_LogonScenes");
            _DicScenesEnumLib.Add(ScenesEnum.LoadingScenes, "LoadingScenes");
        }

        //Get examples of instances
        //
        public static ConvertEnumToString GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new ConvertEnumToString();
            }
            return _Instance;
        }
        //Covert enum scenes to strings and get it's names
        public string GetStrByEnumScenes(ScenesEnum scenesEnum)
        {
            if(_DicScenesEnumLib!=null && _DicScenesEnumLib.Count>=1)
            {
                return _DicScenesEnumLib[scenesEnum];
            }
            else
            {
                Debug.LogWarning(GetType()+ "/GetStrByEnumScenes()/_DicScenesEnumLib.Count<=0!, please check eumes");
                return null; 
            }
        }
    }

}
