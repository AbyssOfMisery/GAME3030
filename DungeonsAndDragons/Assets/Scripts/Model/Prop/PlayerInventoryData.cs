/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: player inventory system data
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
    public class PlayerInventoryData
    {
        public static del_PlayerSaveModel evePlayerInventoryData; //player inventory data
        private int _IntHealthPotionNum;  //number of health potion
        private int _IntManaPotionNum;   //number of mana potion
        private int _IntPropATKNum;         //damage item
        private int _IntPropDEFNum;             //defence item
        private int _IntPropDEXNum;             //dexterity item

        //register item data to inventory system
        public int HealthPotionNum {
            get { return _IntHealthPotionNum; }
            set { _IntHealthPotionNum = value;
                if (evePlayerInventoryData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("HealthPotion", HealthPotionNum);
                    evePlayerInventoryData(kv);
                }
            }
        }

        public int ManaPotionNum {
            get { return _IntManaPotionNum; }
            set { _IntManaPotionNum = value;
                if (evePlayerInventoryData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("ManaPotion", ManaPotionNum);
                    evePlayerInventoryData(kv);
                }
            }
        }
        public int PropATKNum {
            get { return _IntPropATKNum; }
            set { _IntPropATKNum = value;
                if (evePlayerInventoryData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("ATKItemNum", PropATKNum);
                    evePlayerInventoryData(kv);
                }
            }
        }
        public int PropDEFNum {
            get { return _IntPropDEFNum; }
            set { _IntPropDEFNum = value;
                if (evePlayerInventoryData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("DEFItemNum", PropDEFNum);
                    evePlayerInventoryData(kv);
                }
            }
        }
        public int PropDEXNum {
            get { return _IntPropDEXNum; }
            set { _IntPropDEXNum = value;
                if (evePlayerInventoryData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("DEXItemNum", PropDEXNum);
                    evePlayerInventoryData(kv);
                }
            }
        }

        private PlayerInventoryData() { }

        public PlayerInventoryData(int healthpotion, int manapoition, int ATKnum,int DEFnum,int DEXnum )
        {
            this._IntHealthPotionNum = healthpotion;
            this._IntManaPotionNum = manapoition;
            this._IntPropATKNum = ATKnum;
            this._IntPropDEFNum = DEFnum;
            this._IntPropDEXNum = DEXnum;
        }
    }

}
