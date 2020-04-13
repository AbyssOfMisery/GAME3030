/*
 * Title:"Dungoen and dragons"
 *      
 *      model layer: player inventory system data proxy
 *      
 * Description:
 *         drag items into blocks
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

using Kernal;
using Global;

namespace Model
{
    public class PlayerInventoryDataProxy: PlayerInventoryData
    {
        private static PlayerInventoryDataProxy Instance = null; // instance

        public PlayerInventoryDataProxy(int healthPotion, int manPotion, int atkNum,int defNum,int dexNum):
            base(healthPotion,manPotion,atkNum,defNum,dexNum)
        {
            if(Instance==null)
            {
                Instance = this;
                
            }
            else
            {
                Debug.LogError(GetType()+ "/PlayerInventoryDataProxy() can't be multiple");
            }
        }

        /// <summary>
        /// get its instance
        /// </summary>
        /// <returns></returns>
        public static PlayerInventoryDataProxy GetInstance()
        {
            if(Instance!=null)
            {
                return Instance;
            }
            else
            {
                Debug.LogError("/GetInstance() can not be called");
                return null;
            }
        }

        //number of health potion
        #region health potion
        /// <summary>
        /// increase number of health potion
        /// </summary>
        /// <param name="healthPotion"></param>
        public void IncreaseHealthPotion(int healthPotion)
        {
            base.HealthPotionNum += Mathf.Abs(healthPotion);
        }

        /// <summary>
        /// decrease health potion
        /// </summary>
        /// <param name="healthPotion"></param>
        public void DecreaseHealthPotion(int healthPotion)
        {
            if (base.HealthPotionNum - Mathf.Abs(healthPotion) >= 0)
            {
                base.HealthPotionNum -= Mathf.Abs(healthPotion);
            }
        }
        /// <summary>
        /// display health potion
        /// </summary>
        /// <param name="healthPotion"></param>
        public int DisplayHealthPotion(int healthPotion)
        {
            return base.HealthPotionNum;
        }
        #endregion

        #region Mana potion
        //number of mana potion

        /// <summary>
        /// increase number of mana potion
        /// </summary>
        /// <param name="manaPotion"></param>
        public void IncreaseManaPotion(int manaPotion)
        {
            base.ManaPotionNum += Mathf.Abs(manaPotion);
        }

        /// <summary>
        /// decrease mana potion
        /// </summary>
        /// <param name="manaPotion"></param>
        public void DecreaseManaPotion(int manaPotion)
        {
            if (base.ManaPotionNum - Mathf.Abs(manaPotion) >= 0)
            {
                base.ManaPotionNum -= Mathf.Abs(manaPotion);
            }
        }
        /// <summary>
        /// display mana potion
        /// </summary>
        /// <param name="manaPotion"></param>
        public int DisplayManaPotion(int manaPotion)
        {
            return base.ManaPotionNum;
        }

        #endregion

        #region ATK Items
        //damage item

        /// <summary>
        /// increase number of atk item
        /// </summary>
        /// <param name="atkNum"></param>
        public void IncreaseAtkItem(int atkNum)
        {
            base.PropATKNum += Mathf.Abs(atkNum);
        }

        /// <summary>
        /// decrease atk item
        /// </summary>
        /// <param name="atkNum"></param>
        public void DecreaseAtkItem(int atkNum)
        {
            if (base.PropATKNum - Mathf.Abs(atkNum) >= 0)
            {
                base.PropATKNum -= Mathf.Abs(atkNum);
            }
        }
        /// <summary>
        /// display atk item
        /// </summary>
        /// <param name="atkNum"></param>
        public int DisplayATKItem(int atkNum)
        {
            return base.PropATKNum;
        }
        #endregion

        #region Defence Item
        //defence item

        /// <summary>
        /// increase number of def item
        /// </summary>
        /// <param name="defNum"></param>
        public void IncreaseDefItem(int defNum)
        {
            base.PropDEFNum += Mathf.Abs(defNum);
        }

        /// <summary>
        /// decrease def item
        /// </summary>
        /// <param name="defNum"></param>
        public void DecreaseDefItem(int defNum)
        {
            if (base.PropDEFNum - Mathf.Abs(defNum) >= 0)
            {
                base.PropDEFNum -= Mathf.Abs(defNum);
            }
        }
        /// <summary>
        /// display def item
        /// </summary>
        /// <param name="defNum"></param>
        public int DisplayDEFItem(int defNum)
        {
            return base.PropDEFNum;
        }
        #endregion

        #region Dexterity Item

        //dexterity item

        /// <summary>
        /// increase number of dex item
        /// </summary>
        /// <param name="dexNum"></param>
        public void IncreaseDexItem(int dexNum)
        {
            base.PropDEXNum += Mathf.Abs(dexNum);
        }

        /// <summary>
        /// decrease dex item
        /// </summary>
        /// <param name="defNum"></param>
        public void DecreaseDexItem(int dexNum)
        {
            if (base.PropDEXNum - Mathf.Abs(dexNum) >= 0)
            {
                base.PropDEXNum -= Mathf.Abs(dexNum);
            }
        }
        /// <summary>
        /// display dex item
        /// </summary>
        /// <param name="dexNum"></param>
        public int DisplayDEXItem(int dexNum)
        {
            return base.PropDEXNum;
        }
        #endregion


    }
}


