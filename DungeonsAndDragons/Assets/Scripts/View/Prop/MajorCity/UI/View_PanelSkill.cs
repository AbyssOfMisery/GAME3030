/*
 * Title:"Dungoen and dragons"
 *      
 *     View layer: display player skill info detail
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
using UnityEngine.UI;

using Global;
using Kernal;

namespace View
{
    public class View_PanelSkill : MonoBehaviour
    {
        //gameobjects
        public Image ImgBasicATK;
        public Image ImgATK1;
        public Image ImgATK2;
        public Image ImgATK3;
        public Image ImgATK4;

        //display text
        public Text TxtSkillName;
        public Text TxtSkilDescription;

        private void Awake()
        {
            //attack image rigister
            RigisterAttack();

        }

        private void Start()
        {
            TxtSkillName.text = "Basic Attck";
            TxtSkilDescription.text = "Just a basic attack combo";
        }

        /// <summary>
        /// rigister image
        /// </summary>
        public void RigisterAttack()
        {
            if(ImgBasicATK!=null)
            {
                EventTriggerListenner.Get(ImgBasicATK.gameObject).onClick += BasicATK;
            }
            if (ImgATK1 != null)
            {
                EventTriggerListenner.Get(ImgATK1.gameObject).onClick += ATK1;
            }
            if (ImgATK2 != null)
            {
                EventTriggerListenner.Get(ImgATK2.gameObject).onClick += ATK2;
            }
            if (ImgATK3 != null)
            {
                EventTriggerListenner.Get(ImgATK3.gameObject).onClick += ATK3;
            }
            if (ImgATK4 != null)
            {
                EventTriggerListenner.Get(ImgATK4.gameObject).onClick += ATK4;
            }
       
        }

        private void BasicATK(GameObject go)
        {
            if(go == ImgBasicATK.gameObject)
            {
                TxtSkillName.text = "Basic Attck";
                TxtSkilDescription.text = "Just a basic attack combo";
            }
        }
        private void ATK1(GameObject go)
        {
            if (go == ImgATK1.gameObject)
            {
                TxtSkillName.text = "Ability 1";
                TxtSkilDescription.text = "Small range ability, it will attack all enemies in small range";
            }
        }
        private void ATK2(GameObject go)
        {
            if (go == ImgATK2.gameObject)
            {
                TxtSkillName.text = "Ability 2";
                TxtSkilDescription.text = "Causing high amount of damage to towards of enemies";
            }
        }
        private void ATK3(GameObject go)
        {
            if (go == ImgATK3.gameObject)
            {
                TxtSkillName.text = "Ability 3";
                TxtSkilDescription.text = "summon a fireball to attack enemy";
            }
        }
        private void ATK4(GameObject go)
        {
            if (go == ImgATK4.gameObject)
            {
                TxtSkillName.text = "Ability 4";
                TxtSkilDescription.text = "Calling a thunderbolt form sky, and then do damage to enemy";
            }
        }


    }
}

