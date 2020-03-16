/*
 * Title:"Dungoen and dragons"
 *      
 *      control layer: red warrior property
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


using Global;
using Kernal;

namespace Control {
    public class Ctrl_RedWarrior_Property : Ctrl_BaseEnemyProperty
    {
        public int IntPlayerExp = 20;       //add exp per one enemy killed
        public int IntATK = 10;             //attack damage
        public int IntDEF = 3;             //defence
        public int IntMaxHealth = 50;      //Enemy max health

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


