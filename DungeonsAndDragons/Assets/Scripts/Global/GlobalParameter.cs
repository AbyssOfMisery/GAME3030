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
    public class GlobalParameter {
        //Define project system constants
        /// <summary>
        /// Input manager definition _Ability Name_Basic Attack
        /// </summary>
        public const string INPUT_MGR_ATTACKNAME_BASIC = "BasicAttack";

        /// <summary>
        /// Input manager definition _Ability Name_ MagicTrickA
        /// </summary>
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICK_A = "MagicTrickA";

        /// <summary>
        /// Input manager definition _Ability Name_ MagicTrickB
        /// </summary>
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICK_B = "MagicTrickB";


        /// <summary>
        /// Input manager definition Vertical
        /// </summary>
        public const string INPUT_MGR_VERTICAL = "Vertical";

        /// <summary>
        /// Input manager definition Horizontal
        /// </summary>
        public const string INPUT_MGR_HORIZONTAL = "Horizontal";

    }


    #region project's enum type
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

    /// <summary>
    /// player animation state
    /// </summary>
    public enum PlayerActionState
    {
        None,
        Idle,
        Running,
        BasicAttack,
        MagicTrickA,
        MagicTrickB,

    }
    #endregion
    /// <summary>
    /// Commission : player control
    /// </summary>
    /// <param name="controlType">control type</param>
    #region Project Delegate Type
    public delegate void del_PlayerControlWithStr(string controlType);
    #endregion
}
