/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: Enemy(Attributes)
 *      
 * Description:
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
using Kernal;

namespace Control
{
    public class Ctrl_Warrior_Property : Ctrl_BaseEnemyProperty
    {
        public int IntPlayerExp = 5;       //add exp per one enemy killed
        public int IntATK = 2;             //attack damage
        public int IntDEF = 2;             //defence
        public int IntMaxHealth = 20;      //Enemy max health

        private void Start()
        {
            base.PlayerExp = IntPlayerExp;
            base.ATK = IntATK;
            base.DEF = IntDEF;
            base.MaxHealth = IntMaxHealth;

            base.RunMethodInChildren();
        }
    }
}


