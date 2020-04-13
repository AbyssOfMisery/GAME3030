/*
 * Title:"Dungoen and dragons"
 *      
 *      View layer: showing images in player's backpack
 *      
 * Description:
 *      UI buttom CD effect
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

using Kernal;
using Global;
using Model;
using UnityEngine.UI;

namespace View {
    public class View_InventoryCtrl : MonoBehaviour
    {
        //define item objects
        public GameObject goHealthPotion;
        public GameObject goManaPotion;
        public GameObject goATKItem;
        public GameObject goDEFItem;
        public GameObject goDEXItem;
        //define number of objects
        public Text TxtHealthPotion;
        public Text TxtManaPotion;

        private void Awake()
        {

            PlayerInventoryData.evePlayerInventoryData += DisplayHealthPotion;
            PlayerInventoryData.evePlayerInventoryData += DisplayManaPotion;
            PlayerInventoryData.evePlayerInventoryData += DisplayATKItem;
            PlayerInventoryData.evePlayerInventoryData += DisplayDEFItem;
            PlayerInventoryData.evePlayerInventoryData += DisplayDEXItem;
        }


        /// <summary>
        /// health potion
        /// </summary>
        /// <param name="kv"></param>
       public void DisplayHealthPotion(KeyValueUpdate kv)
        {
            if(kv.Key.Equals("HealthPotion"))
            {
                if(goHealthPotion && TxtHealthPotion)
                {
                    if(System.Convert.ToInt32(kv.Values)>=1)
                    {
                        goHealthPotion.SetActive(true);
                        //show health potion number
                        TxtHealthPotion.text = kv.Values.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// mana potion
        /// </summary>
        /// <param name="kv"></param>
        public void DisplayManaPotion(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("ManaPotion"))
            {
                if (goManaPotion && goManaPotion)
                {
                    if (System.Convert.ToInt32(kv.Values) >= 1)
                    {
                        goManaPotion.SetActive(true);
                        //show mana potion number
                        TxtManaPotion.text = kv.Values.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// ATK Item
        /// </summary>
        /// <param name="kv"></param>
        public void DisplayATKItem(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("ATKItemNum"))
            {
                if (goATKItem)
                {
                    if (System.Convert.ToInt32(kv.Values) >= 1)
                    {
                        goATKItem.SetActive(true);
                    }
                }
            }
        }

        /// <summary>
        /// DEF Item
        /// </summary>
        /// <param name="kv"></param>
        public void DisplayDEFItem(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("DEFItemNum"))
            {
                if (goDEFItem)
                {
                    if (System.Convert.ToInt32(kv.Values) >= 1)
                    {
                        goDEFItem.SetActive(true);
                    }
                }
            }
        }

        /// <summary>
        /// DEX Item
        /// </summary>
        /// <param name="kv"></param>
        public void DisplayDEXItem(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("DEXItemNum"))
            {
                if (goDEXItem)
                {
                    if (System.Convert.ToInt32(kv.Values) >= 1)
                    {
                        goDEXItem.SetActive(true);
                    }
                }
            }
        }
    }
}

