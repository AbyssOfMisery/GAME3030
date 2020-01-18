/*
 * Title:"Dungoen and dragons"
 *      
 *      public layer: Global parameter
 *      
 * Description:
 *         1: Define the enumeration type for the entire project
 *         2: Define the delegation perspective for the entire project
 *         3: Define system constants for the entire project
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

namespace Global{
    public class GlobalParamete {
    }
    //scenes name enums
    public enum ScenesEnum
    {
        StartScenes,
        LoadingScenes,
        LogonScenes,
        LevelOne,
        LevelTwo,
        BaseScenes
    }

    //player type
    public enum PlayerType
    {
        Warrior,        //warrior
        Witch,          //Witch
        Other
    }
}
