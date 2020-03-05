/*
 * Title:"Dungoen and dragons"
 *      
 *      Model layer: players' save datas
 *      
 * Description:
 *         Function: allow player to save their datas
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

namespace Model
{
    public class PlayerSaveData 
    {

        //Define event player key value
        public static event del_PlayerSaveModel evePlayerSaveDate;   //player core key value

        private float _FloHealth;    //player health
        private float _FloMagic;     //player mana
        private float _FloAttack;    //player attack damage
        private float _FloDefence;   //player defence
        private float _FloDexterity; //player dexterity

        private float _FloMaxHealth;    //player max health
        private float _FloMaxMagic;     //player max mana
        private float _FloMaxAttack;    //player max attack damage
        private float _FloMaxDefence;   //player max defence
        private float _FloMaxDexterity; //player max dexterity

        private float _FloAttackByProp;      //weapon damage
        private float _FloDefenceByProp;     //weapon defence
        private float _FloDexterityByProp;   //weapon dexterity



        /*Attributes */
        public float Health {
            get {return _FloHealth; }
            set
            {
                _FloHealth = value;

                //event use
                if(evePlayerSaveDate!=null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Health", Health);
                    evePlayerSaveDate(kv);
                }
            }
            
        }
        public float Magic {
            get { return _FloMagic; }
            set
            {
                _FloMagic = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Magic", Magic);
                    evePlayerSaveDate(kv);
                }
            }
        }
        public float Attack {
            get { return _FloAttack; }
            set
            {
                _FloAttack = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Attack", Attack);
                    evePlayerSaveDate(kv);
                }
            }
        }
        public float Defence {
            get { return _FloDefence; }
            set
            {
                _FloDefence = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Defence", Defence);
                    evePlayerSaveDate(kv);
                }
            }
        }
        public float Dexterity {
            get { return _FloDexterity; }
            set
            {
                _FloDexterity = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Dexterity", Dexterity);
                    evePlayerSaveDate(kv);
                }
            }
        }
    

        /*Max Attributes */
        public float MaxHealth {
        get { return _FloMaxHealth; }
        set
        {
            _FloMaxHealth = value;

            //event use
            if (evePlayerSaveDate != null)
            {
                KeyValueUpdate kv = new KeyValueUpdate("MaxHealth", MaxHealth);
                evePlayerSaveDate(kv);
            }
        }
    }

        public float MaxMagic {
            get { return _FloMaxMagic; }
            set
            {
                _FloMaxMagic = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxMagic", MaxMagic);
                    evePlayerSaveDate(kv);
                }
            }
        }
        public float MaxAttack {
            get { return _FloMaxAttack; }
            set
            {
                _FloMaxAttack = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxAttack", MaxAttack);
                    evePlayerSaveDate(kv);
                }
            }
        }
        public float MaxDefence {
            get { return _FloMaxDefence; }
            set
            {
                _FloMaxDefence = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxDefence", MaxDefence);
                    evePlayerSaveDate(kv);
                }
            }
        }
        public float MaxDexterity {
            get { return _FloMaxDexterity; }
            set
            {
                _FloMaxDexterity = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxDexterity", MaxDexterity);
                    evePlayerSaveDate(kv);
                }
            }
        }

        /*Weapon Attributes */
        public float AttackByProp {
            get { return _FloAttackByProp; }
            set
            {
                _FloAttackByProp = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("AttackByProp", AttackByProp);
                    evePlayerSaveDate(kv);
                }
            }
        }
        public float DefenceByProp {
            get { return _FloDefenceByProp; }
            set
            {
                _FloDefenceByProp = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("DefenceByProp", DefenceByProp);
                    evePlayerSaveDate(kv);
                }
            }
        }
        public float DexterityByProp {
            get { return _FloDexterityByProp; }
            set
            {
                _FloDexterityByProp = value;

                //event use
                if (evePlayerSaveDate != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("DexterityByProp", DexterityByProp);
                    evePlayerSaveDate(kv);
                }
            }
        }



        //make a private constructor
        private PlayerSaveData() { }


        //make a public constructor
        public PlayerSaveData(float health, float magic, float attack, float defence, float dexterity, 
            float maxHealth, float maxMagic, float maxAttack, float maxDefence, float maxDexterity, 
            float attackByProp, float defenceByProp, float dexterityByProp) {

            this._FloHealth = health;
            this._FloMagic = magic;
            this._FloAttack = attack;
            this._FloDefence = defence;
            this._FloDexterity = dexterity;

            this._FloMaxHealth = maxHealth;
            this._FloMaxMagic = maxMagic;
            this._FloMaxAttack = maxAttack;
            this._FloMaxDefence = maxDefence;
            this._FloMaxDexterity = maxDexterity;

            this._FloAttackByProp = attackByProp;
            this._FloDefenceByProp = defenceByProp;
            this._FloDexterityByProp = dexterityByProp;
        }
    }
}

