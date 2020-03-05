/*
 * Title:"Dungoen and dragons"
 *      
 *      Model layer: Player expansion value
 *      
 * Description:
 *         Function: This class provides access value for player extended data
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

namespace Model
{

    public class PlayerSaveDataProxy:PlayerSaveData
    {

        public static PlayerSaveDataProxy _Instance = null; //get instance
        public const int ENEMY_MIN_ATK = 1;        //enemy lowest damage


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
        public PlayerSaveDataProxy(float health, float magic, float ATK, float DEF, float DEX,
            float maxHealth, float maxMagic, float maxATK, float maxDEF, float maxDEX,
            float ATKByProp, float DEFByProp, float DEXByProp):
            base(health,magic,ATK,DEF,DEX,
                maxHealth,maxMagic,maxATK,maxDEF,maxDEX,
                ATKByProp,DEFByProp,DEXByProp)
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
        public static PlayerSaveDataProxy GetInstance()
        {
            if(_Instance == null)
            {
                return _Instance;
            }
            else
            {
                Debug.LogWarning("GetInstance()/call Constructor first");
                return null;
            }
        }//end getinstance

        #region health changes
        /// <summary>
        /// decrease healths with attack be enemy
        /// function: _health = _health -(enemy damage - player defense -player weapon defense)
        /// </summary>
        /// <param name="enemyAttackValue">health cost</param>
        public void DecreaseHealthValues(float enemyAttackValue)
        {
            float enemyRealATK = 0f;

            enemyRealATK = enemyAttackValue - base.Defence - base.DefenceByProp;

            if(enemyRealATK > 0)
            {
                base.Health -= enemyRealATK;
            }
            else
            {
                base.Health -= ENEMY_MIN_ATK;
            }
            //attack defence and sexterity update
            this.UpdateATKValues();
            this.UpdateDEFValues();
            this.UpdateDEXValues();
        }

        /// <summary>
        /// add health when player eat health potions
        /// </summary>
        /// <param name="healthValue"></param>
        public void IncreaseHealthValues(float healthValue)
        {
            float floRealIncreaseHealthValues = 0f; //real increase amount of health

            floRealIncreaseHealthValues = base.Health += healthValue;
            if (floRealIncreaseHealthValues < base.MaxHealth)
            {
                base.Health += healthValue;
            }
            else
            {
                base.Health = base.MaxHealth;
            }
        }

        /// <summary>
        /// get currentHealth
        /// </summary>
        /// <returns></returns>
        public float GetCurrentHealth()
        {
            return base.Health;
        }

        /// <summary>
        ///  add max health of player
        /// </summary>
        /// <param name="increaseHealth">Incremental health value</param>
        public void IncreaseMaxHealth(float increaseHealth)
        {
            base.MaxHealth += Mathf.Abs(increaseHealth);
        }

        /// <summary>
        /// get max health of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxHealth()
        {
            return base.MaxHealth;
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
            float realMagicValueResult = 0.0f; //check current magic value
            realMagicValueResult = base.Magic -= MagicValue;
            if (realMagicValueResult > 0)
            {
                base.Magic -= Mathf.Abs(MagicValue);
            }
            else
            {
                base.Magic = 0;
            }
            
        }

        /// <summary>
        /// add magic when player eat magic potions
        /// </summary>
        /// <param name="MagicValue">add magic value</param>
        public void IncreaseMagicValues(float magicValue)
        {
            float floRealIncreaseMagicValues = 0f; //real increase amount of magic

            floRealIncreaseMagicValues = base.Magic += magicValue;
            if (floRealIncreaseMagicValues < base.MaxMagic)
            {
                base.Magic += magicValue;
            }
            else
            {
                base.Magic = base.MaxMagic;
            }
        }

        /// <summary>
        /// get currentMagic
        /// </summary>
        /// <returns></returns>
        public float GetCurrentMagic()
        {
            return base.Magic;
        }

        /// <summary>
        ///  add max magic of player
        /// </summary>
        /// <param name="increaseHealth">Incremental health value</param>
        public void IncreaseMaxMagic(float increaseMagic)
        {
            base.MaxMagic += Mathf.Abs(increaseMagic);
        }

        /// <summary>
        /// get max magic of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxMagic()
        {
            return base.MaxMagic;
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
            float realATKValues = 0.0f;

            //player didnt get new weapon
            if(newWeaponValues == 0)
            {
                realATKValues = base.MaxAttack / 2 * (base.Health / base.MaxHealth) + base.AttackByProp;
            }
            //player has got new weapon
            else if(newWeaponValues > 0)
            {
                realATKValues = base.MaxAttack / 2 * (base.Health / base.MaxHealth) + newWeaponValues;
                base.AttackByProp = newWeaponValues;
            }


            //double check attack values (max sure player attack is in a range)
            if (realATKValues > base.MaxAttack)
            {
                base.Attack = base.MaxAttack;
            }
            else
            {
                base.Attack = realATKValues;
            }
        }

        /// <summary>
        /// get current attack damage
        /// </summary>
        /// <returns></returns>
        public float GetCurrentATK()
        {
            return base.Attack;
        }

        /// <summary>
        ///  add max attack damage of player
        /// </summary>
        /// <param name="increaseHealth">Incremental attack damage value</param>
        public void IncreaseMaxATK(float increaseATK)
        {
            base.MaxAttack += Mathf.Abs(increaseATK);
        }

        /// <summary>
        /// get max attack damage of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxATK()
        {
            return base.MaxAttack;
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
            float realDEFValues = 0.0f;

            //player didnt get new weapon
            if (newWeaponDEFValues == 0)
            {
                realDEFValues = base.MaxDefence / 2 * (base.Health / base.MaxHealth) + base.DefenceByProp;
            }
            //player has got new weapon
            else if (newWeaponDEFValues > 0)
            {
                realDEFValues = base.MaxDefence / 2 * (base.Health / base.MaxHealth) + newWeaponDEFValues;
                base.DefenceByProp = newWeaponDEFValues;
            }

            //double check defence values (max sure player defense is in a range)
            if (realDEFValues > base.MaxDefence)
            {
                base.Defence = base.MaxDefence;
            }
            else
            {
                base.Defence = realDEFValues;
            }
        }

        /// <summary>
        /// get current attack damage
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEF()
        {
            return base.Defence;
        }

        /// <summary>
        ///  add max attack damage of player
        /// </summary>
        /// <param name="increaseDEF">Incremental attack damage value</param>
        public void IncreaseMaxDEF(float increaseDEF)
        {
            base.MaxDefence += Mathf.Abs(increaseDEF);
        }

        /// <summary>
        /// get max attack damage of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEF()
        {
            return base.MaxDefence;
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
            float realDEXValues = 0.0f;

            //player didnt get new weapon
            if (newDEXValues == 0)
            {
                realDEXValues = base.MaxDexterity / 2 * (base.Health / base.MaxHealth) - base.Defence + base.DexterityByProp;
            }
            //player has got new weapon
            else if (newDEXValues > 0)
            {
                realDEXValues = base.MaxDexterity / 2 * (base.Health / base.MaxHealth) - base.Defence + newDEXValues;
                base.DexterityByProp = newDEXValues;
            }


            //double check Dexterity values (max sure player Dexterity is in a range)
            if (realDEXValues > base.MaxDexterity)
            {
                base.Dexterity = base.MaxDexterity;
            }
            else
            {
                base.Dexterity = realDEXValues;
            }
        }

        /// <summary>
        /// get current dexterity 
        /// </summary>
        /// <returns></returns>
        public float GetCurrentDEX()
        {
            return base.Dexterity;
        }

        /// <summary>
        ///  add max dexterity of player
        /// </summary>
        /// <param name="increaseHealth">Incremental dexterity value</param>
        public void IncreaseMaxDEX(float increaseDEX)
        {
            base.MaxDexterity += Mathf.Abs(increaseDEX);
        }

        /// <summary>
        /// get max DEX of player
        /// </summary>
        /// <returns></returns>
        public float GetMaxDEX()
        {
            return base.MaxDexterity;
        }
        #endregion

        /// <summary>
        /// Show initial value
        /// </summary>
        public void DisplayAllOriginalValues()
        {
            base.Health = base.Health;
            base.Magic = base.Magic;
            base.Attack = base.Attack;
            base.Defence = base.Defence;
            base.Dexterity = base.Dexterity;

            base.MaxHealth = base.MaxHealth;
            base.MaxMagic = base.MaxMagic;
            base.MaxAttack = base.MaxAttack;
            base.MaxDefence = base.MaxDefence;
            base.MaxDexterity = base.MaxDexterity;

            base.AttackByProp = base.AttackByProp;
            base.DefenceByProp = base.DefenceByProp;
            base.DexterityByProp = base.DexterityByProp;
        }

    }

}
