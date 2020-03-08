/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: Player(Attributes)
 *      
 * Description:
 *          1: setup default value for each instance
 *          2: The core method of integrating the model layer about the "player" module and allow other control layer script to use tis script
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
using Model;

namespace Control
{
    public class Ctrl_PlayerProperty : BaseControl
    {
        public static Ctrl_PlayerProperty Instance; //this instance
        //core value 
        public float playerCurrentHp = 100f;   //player current hp
        public float playerMaxHp = 100f;       //player max hp
        public float playerCurrentMp = 100f;   //player current mp
        public float playerMaxMp = 100f;       //player Max mp
        public float playerCurrentATK = 10f;   //player current ATK
        public float playerMaxATK = 10f;       //player Max ATK
        public float playerCurrentDEF = 5f;    //player current DEF
        public float playerMaxDEF = 5f;        //player Max DEF
        public float playerCurrentDEX = 45f;   //player current DEX
        public float playerMaxDEX = 50f;       //player Max DEX

        public float FloATKByProp = 0f;         //ATK by prop
        public float FloDEFByProp = 0f;         //DEF by prop
        public float FloDEXByProp = 0f;         //DEX by prop

        //extend vaule
        public int IntEXP = 0;                  // exp
        public int IntLevel = 0;                //level
        public int IntKillNum = 0;              //number of enemy killed
        public int IntGold = 0;                 //gold
        public int IntDiamond = 0;              //diamond




        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
             //setup default value
              PlayerSaveDataProxy playerSaveDataProxy = new PlayerSaveDataProxy(playerCurrentHp, playerCurrentMp, playerCurrentATK,
              playerCurrentDEF, playerCurrentDEX, playerMaxHp, playerMaxMp, playerMaxATK, playerMaxDEF, playerMaxDEX, FloATKByProp, FloDEFByProp, FloDEXByProp);
            
              PlayerExtenalDataProxy playerExtenalDataProxy = new PlayerExtenalDataProxy(IntEXP, IntKillNum, IntLevel, IntGold, IntDiamond);
        }

        #region health changes
        /// <summary>
        /// decrease healths with attack be enemy
        /// function: _health = _health -(enemy damage - player defense -player weapon defense)
        /// </summary>
        /// <param name="enemyAttackValue">health cost</param>
        public void DecreaseHealthValues(float enemyAttackValue)
        {
            if (enemyAttackValue > 0)
            {
                PlayerSaveDataProxy.GetInstance().DecreaseHealthValues(enemyAttackValue);
            }

        }

        /// <summary>
        /// add health when player eat health potions
        /// </summary>
        /// <param name="healthValue"></param>
        public void IncreaseHealthValues(float healthValue)
        {
            if (healthValue>0)
            {
                PlayerSaveDataProxy.GetInstance().IncreaseHealthValues(healthValue);
            }

        }

        /// <summary>
        /// get currentHealth
        /// </summary>
        /// <returns></returns>
        public float GetCurrentHealth()
        {
            return PlayerSaveDataProxy.GetInstance().GetCurrentHealth();
        }

        /// <summary>
        ///  add max health of player
        /// </summary>
        /// <param name="increaseHealth">Incremental health value</param>
        public void IncreaseMaxHealth(float increaseHealth)
        {
            if(increaseHealth>0)
            {
                PlayerSaveDataProxy.GetInstance().IncreaseMaxHealth(increaseHealth);
            }

        }

        /// <summary>
        /// get max health of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxHealth()
        {
            return PlayerSaveDataProxy.GetInstance().GetMaxHealth();
        }
        #endregion

        #region magic changes
        /// <summary>
        /// decrease magic with attack be enemy
        /// function: magic = magic -(magic cost)
        /// </summary>
        /// <param name="MagicValue">magic cost</param>
        public void DecreaseMagicValues(float MagicValue)
        {
            if(MagicValue >0)
            {
                PlayerSaveDataProxy.GetInstance().DecreaseMagicValues(MagicValue);
            }

        }

        /// <summary>
        /// add magic when player eat magic potions
        /// </summary>
        /// <param name="MagicValue">add magic value</param>
        public void IncreaseMagicValues(float magicValue)
        {
            if(magicValue>0)
            {
                PlayerSaveDataProxy.GetInstance().IncreaseMagicValues(magicValue);
            }

        }

        /// <summary>
        /// get currentMagic
        /// </summary>
        /// <returns></returns>
        public float GetCurrentMagic()
        {
            return PlayerSaveDataProxy.GetInstance().GetCurrentMagic();
        }

        /// <summary>
        ///  add max magic of player
        /// </summary>
        /// <param name="increaseHealth">Incremental health value</param>
        public void IncreaseMaxMagic(float increaseMagic)
        {
            if(increaseMagic>0)
            {
                PlayerSaveDataProxy.GetInstance().IncreaseMaxMagic(increaseMagic);
            }

        }

        /// <summary>
        /// get max magic of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxMagic()
        {
            return PlayerSaveDataProxy.GetInstance().GetMaxMagic();
        }
        #endregion

        #region attakc changes
        /// <summary>
        /// function: _AttackForce = MaxATK/2*(Health/MaxHealth)+[Weapon damage]
        /// update attack damage
        /// </summary>
        /// <param name="newWeaponValues">new weapon damage</param>
        public void UpdateATKValues(float newWeaponValues = 0)
        {
            PlayerSaveDataProxy.GetInstance().UpdateATKValues(newWeaponValues);
        }

        /// <summary>
        /// get current attack damage
        /// </summary>
        /// <returns></returns>
        public float GetCurrentATK()
        {
            return PlayerSaveDataProxy.GetInstance().GetCurrentATK();
        }

        /// <summary>
        ///  add max attack damage of player
        /// </summary>
        /// <param name="increaseHealth">Incremental attack damage value</param>
        public void IncreaseMaxATK(float increaseATK)
        {
            if (increaseATK > 0)
            {
                PlayerSaveDataProxy.GetInstance().IncreaseMaxATK(increaseATK);
            }

        }

        /// <summary>
        /// get max attack damage of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxATK()
        {
            return PlayerSaveDataProxy.GetInstance().GetCurrentATK();
        }
        #endregion

        #region defence changes
        /// <summary>
        /// function: _Defence = MaxDEF/2*(Health/MaxHealth)+[Weapon defence]
        /// update defence damage
        /// </summary>
        /// <param name="newWeaponDEFValues">new weapon defence</param>
        public void UpdateDEFValues(float newWeaponDEFValues = 0)
        {
            PlayerSaveDataProxy.GetInstance().UpdateDEFValues(newWeaponDEFValues);
        }

        /// <summary>
        /// get current attack damage
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEF()
        {
            return PlayerSaveDataProxy.GetInstance().GetCurrentDEF();
        }

        /// <summary>
        ///  add max attack damage of player
        /// </summary>
        /// <param name="increaseDEF">Incremental attack damage value</param>
        public void IncreaseMaxDEF(float increaseDEF)
        {
            if (increaseDEF > 0)
            {
                PlayerSaveDataProxy.GetInstance().IncreaseMaxDEX(increaseDEF);
            }

        }

        /// <summary>
        /// get max attack damage of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEF()
        {
            return PlayerSaveDataProxy.GetInstance().GetMaxDEF();
        }
        #endregion

        #region dexterity changes
        /// <summary>
        /// function: _MoveSpeed = maxMoveSpeed /2 * (health /maxhealth ) - defence + [weapon dexterity]
        /// update player dexterity
        /// </summary>
        /// <param name="newDEXValues">new dexterity</param>
        public void UpdateDEXValues(float newDEXValues = 0)
        {
            PlayerSaveDataProxy.GetInstance().UpdateDEXValues(newDEXValues);
        }

        /// <summary>
        /// get current dexterity 
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEX()
        {
            return PlayerSaveDataProxy.GetInstance().GetCurrentDEX();
        }

        /// <summary>
        ///  add max dexterity of player
        /// </summary>
        /// <param name="increaseHealth">Incremental dexterity value</param>
        public void IncreaseMaxDEX(float increaseDEX)
        {
            if(increaseDEX>0)
            {
                PlayerSaveDataProxy.GetInstance().IncreaseMaxDEX(increaseDEX);
            }

        }

        /// <summary>
        /// get max DEX of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEX()
        {
            return PlayerSaveDataProxy.GetInstance().GetMaxDEX();
        }
        #endregion

        #region EXP
        /// <summary>
        /// add experience
        /// </summary>
        public void AddEXP(int ExpValue)
        {
            if(ExpValue>0)
            {
                PlayerExtenalDataProxy.GetInstance().AddEXP(ExpValue);
            }

        }

        /// <summary>
        /// get Experience
        /// </summary>
        public int GetEXP()
        {
            return PlayerExtenalDataProxy.GetInstance().GetEXP();
        }
        #endregion

        #region Number of enemy killed
        public void AddKillNumber(int killValue)
        {
            if (killValue >0 )
            {
                PlayerExtenalDataProxy.GetInstance().AddKillNumber(killValue);
            }
  
        }

        public int GetKillNumber()
        {
            return PlayerExtenalDataProxy.GetInstance().GetKillNumber();
        }
        #endregion

        #region level
        /// <summary>
        /// level up
        /// </summary>
        public void AddLevel()
        {
            PlayerExtenalDataProxy.GetInstance().AddLevel();
        }
        /// <summary>
        /// get current level
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return PlayerExtenalDataProxy.GetInstance().GetLevel();
        }
        #endregion

        #region gold
        /// <summary>
        /// add gold to player
        /// </summary>
        public void AddGold(int GoldNumber)
        {
            if(GoldNumber>0)
            {
                PlayerExtenalDataProxy.GetInstance().AddGold(GoldNumber);
            }

        }
        /// <summary>
        /// get current gold
        /// </summary>
        /// <returns></returns>
        public int GetGold()
        {
            return PlayerExtenalDataProxy.GetInstance().GetGold();
        }
        #endregion

        #region diamond
        /// <summary>
        /// add diamonds
        /// </summary>
        public void AddDiamond(int DiamondNumber)
        {
            if (DiamondNumber > 0)
            {
                PlayerExtenalDataProxy.GetInstance().AddDiamond(DiamondNumber);
            }

        }
        /// <summary>
        /// get current diamonds
        /// </summary>
        /// <returns></returns>
        public int GetDiamonds()
        {
            return PlayerExtenalDataProxy.GetInstance().GetDiamonds();
        }
        #endregion

    }

}
