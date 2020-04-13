/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: purchase shop 
 *      
 * Description:
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

namespace Control
{
    public class Ctrl_PanelShop : BaseControl
    {
        public static Ctrl_PanelShop Instance; //instance

        private void Awake()
        {
            Instance = this;
        }


        //10 diamonds
        public bool Add10_Diamonds()
        {
            //you have to connect to app store payment SDK.
            PlayerExtenalDataProxy.GetInstance().AddDiamond(10);
            return true;
        }
        //10 golds
        public bool Add10_Gold()
        {
            bool boolResult = false;

            bool boolFlat = PlayerExtenalDataProxy.GetInstance().MinusDiamond(1);
            //you have subtract 1 diamond from player account and then add 10 golds
            if(boolFlat)
            {
                PlayerExtenalDataProxy.GetInstance().AddGold(10);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }
        //purchase 5 health potions
        public bool Add5_HealthPotion()
        {
            bool boolResult = false;

            bool boolFlat = PlayerExtenalDataProxy.GetInstance().MinusGold(10);
            //you have subtract gold from player account and then add 5 health potions
            if (boolFlat)
            {
                PlayerInventoryDataProxy.GetInstance().IncreaseHealthPotion(5);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }
        //purchase 5 mana potions
        public bool Add5_ManaPotion()
        {
            bool boolResult = false;

            bool boolFlat = PlayerExtenalDataProxy.GetInstance().MinusGold(10);
            //you have subtract gold from player account and then add 5 mana potions
            if (boolFlat)
            {
                PlayerInventoryDataProxy.GetInstance().IncreaseManaPotion(5);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }
        //increase attack
        public bool Add1_AttackIncrease()
        {
            bool boolResult = false;

            bool boolFlat = PlayerExtenalDataProxy.GetInstance().MinusGold(10);
            //you have subtract gold from player account and then add attack increase
            if (boolFlat)
            {
                PlayerInventoryDataProxy.GetInstance().IncreaseAtkItem(1);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }
        //increase defence
        public bool Add1_DefenceIncrease()
        {
            bool boolResult = false;

            bool boolFlat = PlayerExtenalDataProxy.GetInstance().MinusGold(10);
            //you have subtract gold from player account and then add defence increase
            if (boolFlat)
            {
                PlayerInventoryDataProxy.GetInstance().IncreaseDefItem(1);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }
        //increase dexterity
        public bool Add1_DexterityIncrease()
        {
            bool boolResult = false;

            bool boolFlat = PlayerExtenalDataProxy.GetInstance().MinusGold(10);
            //you have subtract gold from player account and then add dexterity increase
            if (boolFlat)
            {
                PlayerInventoryDataProxy.GetInstance().IncreaseDexItem(1);
                boolResult = true;
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }

    }
}

