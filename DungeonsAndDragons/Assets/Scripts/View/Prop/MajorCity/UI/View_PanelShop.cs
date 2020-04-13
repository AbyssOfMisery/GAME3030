/*
 * Title:"Dungoen and dragons"
 *      
 *      View layer: shop panel in major city
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
using Control;
using UnityEngine.UI;

namespace View {
    public class View_PanelShop : MonoBehaviour
    {
        //showing item name
        public Text Txt_10_Diamonds;        //10 diamonds
        public Text Txt_10_Gold;            //10 golds
        public Text Txt_5_HP;           //5 health potions
        public Text Txt_5_MP;               //5 mana potions
        public Text Txt_1_Attack;           //increase attack
        public Text Txt_1_Defense;          //increase defence
        public Text Txt_1_Dexterity;        //increase dexterity


        //respone button
        public Button Btn_10_Diamonds;        //10 diamonds
        public Button Btn_10_Gold;            //10 golds
        public Button Btn_5_HP;           //5 health potions
        public Button Btn_5_MP;               //5 mana potions
        public Button Btn_1_Attack;           //increase attack
        public Button Btn_1_Defense;          //increase defence
        public Button Btn_1_Dexterity;        //increase dexterity

        //show item description Txt
        public Text TxtDescription;         //show item description

        private void Awake()
        {
            //register buttons
            RegisterTxtAndBtn();
        }

        #region Register Text and buttom for shop system
        /// <summary>
        /// register buttoms and images
        /// </summary>
        private void RegisterTxtAndBtn()
        {
            //images
            if (Txt_10_Diamonds != null)
            {
                EventTriggerListenner.Get(Txt_10_Diamonds.gameObject).onClick += Display_10Diamonds;
            }
            if (Txt_10_Gold != null)
            {
                EventTriggerListenner.Get(Txt_10_Gold.gameObject).onClick += Display_10Gold;
            }
            if (Txt_5_HP != null)
            {
                EventTriggerListenner.Get(Txt_5_HP.gameObject).onClick += Display_HealthPotion;
            }
            if (Txt_5_MP != null)
            {
                EventTriggerListenner.Get(Txt_5_MP.gameObject).onClick += Display_ManaPotion;
            }
            if (Txt_1_Attack != null)
            {
                EventTriggerListenner.Get(Txt_1_Attack.gameObject).onClick += Display_Attack;
            }
            if (Txt_1_Defense != null)
            {
                EventTriggerListenner.Get(Txt_1_Defense.gameObject).onClick += Display_Defence;
            }
            if (Txt_1_Dexterity != null)
            {
                EventTriggerListenner.Get(Txt_1_Dexterity.gameObject).onClick += Display_Dexterity;
            }

            //buttons
            if (Btn_10_Diamonds != null)
            {
                EventTriggerListenner.Get(Btn_10_Diamonds.gameObject).onClick += Purchase10Diamonds;
            }
            if (Btn_10_Gold != null)
            {
                EventTriggerListenner.Get(Btn_10_Gold.gameObject).onClick += Purchase10Gold;
            }
            if (Btn_5_HP != null)
            {
                EventTriggerListenner.Get(Btn_5_HP.gameObject).onClick += Purchase5HealthPotion;
            }
            if (Btn_5_MP != null)
            {
                EventTriggerListenner.Get(Btn_5_MP.gameObject).onClick += Purchase5ManaPotion;
            }
            if (Btn_1_Attack != null)
            {
                EventTriggerListenner.Get(Btn_1_Attack.gameObject).onClick += Purchase1AttackIncrease;
            }
            if (Btn_1_Defense != null)
            {
                EventTriggerListenner.Get(Btn_1_Defense.gameObject).onClick += Purchase1DefenceIncrease;
            }
            if (Btn_1_Dexterity != null)
            {
                EventTriggerListenner.Get(Btn_1_Dexterity.gameObject).onClick += Purchase1DexterityIncrease;
            }
        }
        #endregion


        #region showing items description
        //10 diamonds
        private void Display_10Diamonds(GameObject go)
         {
             if(go == Txt_10_Diamonds.gameObject)
             {
                TxtDescription.text = "Top up for 10 diamonds";
             }
         }
        //10 golds
        private void Display_10Gold(GameObject go)
        {
            if (go == Txt_10_Gold.gameObject)
            {
                TxtDescription.text = " 10 golds for 1 diamond";
            }
        }
        //5 health potions
        private void Display_HealthPotion(GameObject go)
        {
            if (go == Txt_5_HP.gameObject)
            {
                TxtDescription.text = "5 health potions for 10 gold";
            }
        }
        //5 mana potions
        private void Display_ManaPotion(GameObject go)
        {
            if (go == Txt_5_MP.gameObject)
            {
                TxtDescription.text = "5 mana potions for 10 gold";
            }
        }
        //increase attack
        private void Display_Attack(GameObject go)
        {
            if (go == Txt_1_Attack.gameObject)
            {
                TxtDescription.text = "attack increase for 10 gold";
            }
        }
        //increase defence
        private void Display_Defence(GameObject go)
        {
            if (go == Txt_1_Defense.gameObject)
            {
                TxtDescription.text = "defence increase for 10 gold";
            }
        }
        //increase dexterity
        private void Display_Dexterity(GameObject go)
        {
            if (go == Txt_1_Dexterity.gameObject)
            {
                TxtDescription.text = "dexterity increase for 10 gold";
            }
        }
        #endregion

        #region items click response
        //10 diamonds
        private void Purchase10Diamonds(GameObject go)
        {
            if(go == Btn_10_Diamonds.gameObject)
            {
                bool boolResult = false;
                //pretend you have a logic to internet and allow player to top up 
                boolResult = Ctrl_PanelShop.Instance.Add10_Diamonds();
                //boolResult = xxx;
                if(boolResult)
                {
                    TxtDescription.text = "You have top up 10 diamonds!";
                }
                else
                {
                    TxtDescription.text = "You have failed top up, please contact to our customer service!";
                }
            }
        }
        //10 golds
        private void Purchase10Gold(GameObject go)
        {
            if (go == Btn_10_Gold.gameObject)
            {
                bool boolResult = false;
                //pretend you have a logic to internet and allow player to top up 
                boolResult = Ctrl_PanelShop.Instance.Add10_Gold();
                //boolResult = xxx;
                if (boolResult)
                {
                    TxtDescription.text = "You have bought 10 gold!";
                }
                else
                {
                    TxtDescription.text = "You have failed top up, please contact to our customer service!";
                }
            }
        }
        //5 health potions
        private void Purchase5HealthPotion(GameObject go)
        {
            if (go == Btn_5_HP.gameObject)
            {
                bool boolResult = false;
                //pretend you have a logic to internet and allow player to top up 
                boolResult = Ctrl_PanelShop.Instance.Add5_HealthPotion();
                //boolResult = xxx;
                if (boolResult)
                {
                    TxtDescription.text = "You have bought 5 health postion!";
                }
                else
                {
                    TxtDescription.text = "You have failed top up, please contact to our customer service!";
                }
            }
        }
        //5 mana potions
        private void Purchase5ManaPotion(GameObject go)
        {
            if (go == Btn_5_MP.gameObject)
            {
                bool boolResult = false;
                //pretend you have a logic to internet and allow player to top up 
                boolResult = Ctrl_PanelShop.Instance.Add5_ManaPotion();
                //boolResult = xxx;
                if (boolResult)
                {
                    TxtDescription.text = "You have bought 5 mana postion!";
                }
                else
                {
                    TxtDescription.text = "You have failed top up, please contact to our customer service!";
                }
            }
        }
        //increase attack
        private void Purchase1AttackIncrease(GameObject go)
        {
            if (go == Btn_1_Attack.gameObject)
            {
                bool boolResult = false;
                //pretend you have a logic to internet and allow player to top up 
                boolResult = Ctrl_PanelShop.Instance.Add1_AttackIncrease();
                //boolResult = xxx;
                if (boolResult)
                {
                    TxtDescription.text = "You have bought 1 attack damage increase!";
                }
                else
                {
                    TxtDescription.text = "You have failed top up, please contact to our customer service!";
                }
            }
        }
        //increase defence
        private void Purchase1DefenceIncrease(GameObject go)
        {
            if (go == Btn_1_Defense.gameObject)
            {
                bool boolResult = false;
                //pretend you have a logic to internet and allow player to top up 
                boolResult = Ctrl_PanelShop.Instance.Add1_DefenceIncrease();
                //boolResult = xxx;
                if (boolResult)
                {
                    TxtDescription.text = "You have bought 1 defence increase!";
                }
                else
                {
                    TxtDescription.text = "You have failed top up, please contact to our customer service!";
                }
            }
        }
        //increase dexterity
        private void Purchase1DexterityIncrease(GameObject go)
        {
            if (go == Btn_1_Dexterity.gameObject)
            {
                bool boolResult = false;
                //pretend you have a logic to internet and allow player to top up 
                boolResult = Ctrl_PanelShop.Instance.Add1_DexterityIncrease();
                //boolResult = xxx;
                if (boolResult)
                {
                    TxtDescription.text = "You have bought 1 Dexterity increase!";
                }
                else
                {
                    TxtDescription.text = "You have failed top up, please contact to our customer service!";
                }
            }
        }
        #endregion

    }
}

