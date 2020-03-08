/*
 * Title:"Dungoen and dragons"
 *      
 *      Model layer: Upgrade rules
 *      
 * Description:
 *          Upgrade some rules in game
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

namespace Model
{
    public class UpgradeRule
    {
        private static UpgradeRule _Instance;   // get instance

        private UpgradeRule() { }

        public static UpgradeRule GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new UpgradeRule();
            }
                return _Instance;  
        }

        /// <summary>
        ///  [level up]upgrade condition
        /// </summary>
        /// <param name="experience">character experience</param>
        public void UpgradeCondition(int experience)
        {
            int currentLevel = 0;

            currentLevel = PlayerExtenalDataProxy._Instance.GetLevel();
            if (experience >= 100 && experience< 300 && currentLevel == 0)
            {
                PlayerExtenalDataProxy._Instance.AddLevel();
            }
            else if(experience >= 300 && experience < 500 && currentLevel == 1)
            {
                PlayerExtenalDataProxy._Instance.AddLevel();
            }
            else if (experience >= 500 && experience < 1000 && currentLevel == 2)
            {
                PlayerExtenalDataProxy._Instance.AddLevel();
            }
            else if (experience >= 1000 && experience < 3000 && currentLevel == 3)
            {
                PlayerExtenalDataProxy._Instance.AddLevel();
            }
            else if (experience >= 3000 && experience < 5000 && currentLevel == 4)
            {
                PlayerExtenalDataProxy._Instance.AddLevel();
            }
            else if (experience >= 5000 && experience < 10000 && currentLevel == 5)
            {
                PlayerExtenalDataProxy._Instance.AddLevel();
            }
        }


        /// <summary>
        /// Upgrade operation
        /// </summary>
        public void UpgradeOperation(LevelName levelName)
        {
            switch (levelName)
            {
                case LevelName.Level_0:
                    //make a function
                    UpgradeRuleOperation(10,10,2,1,10);
                    break;
                case LevelName.Level_1:
                    UpgradeRuleOperation(20, 20, 4, 2, 10);
                    break;
                case LevelName.Level_2:
                    UpgradeRuleOperation(25, 25, 5, 2, 10);
                    break;
                case LevelName.Level_3:
                    UpgradeRuleOperation(30, 30, 5, 2, 10);
                    break;
                case LevelName.Level_4:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_5:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_6:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_7:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_8:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_9:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_10:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                default:
                    break;
            }

        }// UpgradeOperation_end

        /// <summary>
        /// UpgradeRuleOperation
        /// </summary>
        /// <param name="hp"></param>
        /// <param name="mp"></param>
        /// <param name="ATK"></param>
        /// <param name="DEF"></param>
        /// <param name="DEX"></param>
        private void UpgradeRuleOperation(float maxhp, float maxmp, float maxATK, float maxDEF,float maxDEX)
        {
            PlayerSaveDataProxy.GetInstance().IncreaseMaxHealth(maxhp);
            PlayerSaveDataProxy.GetInstance().IncreaseMaxMagic(maxmp);
            PlayerSaveDataProxy.GetInstance().IncreaseMaxATK(maxATK);
            PlayerSaveDataProxy.GetInstance().IncreaseMaxDEF(maxDEF);
            PlayerSaveDataProxy.GetInstance().IncreaseMaxDEX(maxDEX);
                           
            PlayerSaveDataProxy.GetInstance().IncreaseHealthValues(PlayerSaveDataProxy.GetInstance().GetMaxHealth());
            PlayerSaveDataProxy.GetInstance().IncreaseMagicValues(PlayerSaveDataProxy.GetInstance().GetMaxMagic());
        }
    }//class end

}
