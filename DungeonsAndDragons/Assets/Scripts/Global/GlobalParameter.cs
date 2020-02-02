/*
 * Title:"Dungoen and dragons"
 *      
 *      public layer: Global parameter
 *      
 * Description:
 *         1: Define the enumeration type for the entire project
 *         2: Define the delegation perspective for the entire project
 *         3: Define system constants for the entire project
 *         4: Define system's all tags
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
    //Define project system constants
    public class GlobalParameter {
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

        /// <summary>
        /// basic attack button 1
        /// </summary>
        public const string BUTTON_ATTACK = "ButtonAttack";

        /// <summary>
        /// Magic Trick button A
        /// </summary>
        public const string BUTTON_MAGIC_A = "MagicTrickABtn";

        /// <summary>
        /// Magic Trick button B
        /// </summary>
        public const string BUTTON_MAGIC_B = "MagicTrickBBtn";

        //Const wait time
        public const float INTERVAL_TIME_0DOT1 = 0.1f;
        public const float INTERVAL_TIME_0DOT2 = 0.2f;
        public const float INTERVAL_TIME_0DOT3 = 0.3f;
        public const float INTERVAL_TIME_0DOT5 = 0.5f;
        public const float INTERVAL_TIME_1 = 1.0f;
        public const float INTERVAL_TIME_1DOT5 = 1.5f;
        public const float INTERVAL_TIME_2 = 2.0f;
        public const float INTERVAL_TIME_2DOT = 2.5f;
        public const float INTERVAL_TIME_3 = 3.0f;
    }

    /*all projects tag defind*/
    public class Tag
    {
        public static string Tag_Enemy = "TagEnemy";
        public static string Player = "Player";
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

    /// <summary>
    /// basic attack combo
    /// </summary>
    public enum BasicATKCombo
    {
        BasicATK1,
        BasicATK2,
        BasicATK3,
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
