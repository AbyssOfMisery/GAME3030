/*
 * Title:"Dungoen and dragons"
 *      
 *      Model layer: save players' datas proxy class
 *      
 * Description:
 *          Function: In order to simplify the development of numerical values
 *          we separate the direct access of numerical values from the calculation 
 *          of complex operations.
 *          (The essence is the application of the proxy design pattern)
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

namespace Model
{
    public class PlayerExtenalDataProxy:PlayerExtenalData
    {
        public static PlayerExtenalDataProxy _Instance = null; //get instance


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="health"></param>
        /// <param name="magic"></param>
        /// <param name="ATK"></param>
        /// <param name="DEF"></param>
        /// <param name="DEX"></param>
        /// <param name="maxHealth"></param>
        /// <param name="maxMagic"></param>
        /// <param name="maxATK"></param>
        /// <param name="maxDEF"></param>
        /// <param name="maxDEX"></param>
        /// <param name="ATKByProp"></param>
        /// <param name="DEFByProp"></param>
        /// <param name="DEXByProp"></param>
        public PlayerExtenalDataProxy(int experience, int killNumber, int level,
            int gold, int diamonds) :base(experience, killNumber, level,gold,diamonds)
        {
            if(_Instance == null)
            {
                _Instance = this;
            }
               else
            {
                Debug.LogError(GetType()+ "/PlayerSaveDataProxy()/it's not instance check again");
            }
        }

        /// <summary>
        /// get this instance
        /// </summary>
        /// <returns></returns>
        public static PlayerExtenalDataProxy GetInstance()
        {
            if (_Instance != null)
            {
                return _Instance;
            }
            else
            {
                Debug.LogWarning("GetInstance()/call Constructor first");
                return null;
            }
        }//end getinstance


        #region EXP
        /// <summary>
        /// add experience
        /// </summary>
        public void AddEXP(int ExpValue)
        {
            //++base.Experience;
            base.Experience += ExpValue;
            //reset exp and level up players

            UpgradeRule.GetInstance().UpgradeCondition(base.Experience);
        }

        /// <summary>
        /// get Experience
        /// </summary>
        public int GetEXP()
        {
            return base.Experience;
        }
        #endregion

        #region Number of enemy killed
        public void AddKillNumber(int killValue)
        {
            //++base.KillNumber;
            base.KillNumber += killValue;
        }

        public int GetKillNumber()
        {
            return base.KillNumber;
        }
        #endregion

        #region level
        /// <summary>
        /// level up
        /// </summary>
        public void AddLevel()
        {
            ++base.Level;
            //level up character level
            UpgradeRule.GetInstance().UpgradeOperation((LevelName)base.Level);
        }
        /// <summary>
        /// get current level
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return base.Level;
        }
        #endregion

        #region gold
        /// <summary>
        /// add gold to player
        /// </summary>
        public void AddGold(int GoldNumber)
        {
            base.Gold += Mathf.Abs(GoldNumber);
        }
        /// <summary>
        /// MinusGold gold to player
        /// </summary>
        public bool MinusGold(int GoldNumber)
        {
            bool boolHandleFlag = false;

            //diamond can not be minus
            if (GetGold() - Mathf.Abs(GoldNumber) >= 0)
            {
                base.Gold -= Mathf.Abs(GoldNumber);
                boolHandleFlag = true;
            }
            else
            {
                boolHandleFlag = false;
            }
            return boolHandleFlag;
        }
        /// <summary>
        /// get current gold
        /// </summary>
        /// <returns></returns>
        public int GetGold()
        {
            return base.Gold;
        }
        #endregion

        #region diamond
        /// <summary>
        /// add diamonds
        /// </summary>
        public void AddDiamond(int DiamondNumber)
        {
           base.Diamonds += Mathf.Abs(DiamondNumber);
        }
        /// <summary>
        /// Minus diamonds
        /// </summary>
        public bool MinusDiamond(int DiamondNumber)
        {
            bool boolHandleFlag = false;

            //diamond can not be minus
            if (GetDiamonds() - Mathf.Abs(DiamondNumber) >= 0)
            {
                base.Diamonds -= Mathf.Abs(DiamondNumber);
                boolHandleFlag = true;
            }
            else
            {
                boolHandleFlag = false;
            }
            return boolHandleFlag;
        }
        /// <summary>
        /// get current diamonds
        /// </summary>
        /// <returns></returns>
        public int GetDiamonds()
        {
            return base.Diamonds;
        }
        #endregion


        public void DisplayerAllOriginalValue()
        {
            base.Experience = base.Experience;
            base.KillNumber = base.KillNumber;
            base.Level = base.Level;
            base.Gold = base.Gold;
            base.Diamonds = base.Diamonds;
        }
    }
}

