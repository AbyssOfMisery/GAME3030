/*
 * Title:"Dungoen and dragons"
 *      
 *      Model layer: Player extension value proxy class
 *      
 * Description:
 *          Function: In order to simplify the development of numerical values
 *          we separate the direct access of numerical values from the calculation 
 *          of complex operations.
 *          (The essence is the application of the proxy design pattern)
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
    public class PlayerExtenalData 
    {

        //Define event player key value
        public static event del_PlayerSaveModel evePlayerExtenalData;   //player core key value


        private int _IntExperience;   //player experience
        private int _IntKillNumber;   //number of enmey killed
        private int _IntLevel;        //player current level
        private int _IntGold;         //player's gold
        private int _IntDiamonds;     //player's diamonds;


        /*Player Attributes core data */
        /// <summary>
        /// player experience
        /// </summary>
        public int Experience {
            get { return _IntExperience; }
            set
            {
                _IntExperience = value;

                //event use
                if (evePlayerExtenalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Experience", Experience);
                    evePlayerExtenalData(kv);
                }
            }
        }
        /// <summary>
        /// number of enemy killed
        /// </summary>
        public int KillNumber {
            get { return _IntKillNumber; }
            set
            {
                _IntKillNumber = value;

                //event use
                if (evePlayerExtenalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("KillNumber", KillNumber);
                    evePlayerExtenalData(kv);
                }
            }
        }
        /// <summary>
        /// player level
        /// </summary>
        public int Level {
            get { return _IntLevel; }
            set
            {
                _IntLevel = value;

                //event use
                if (evePlayerExtenalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Level", Level);
                    evePlayerExtenalData(kv);
                }
            }
        }
        /// <summary>
        /// money
        /// </summary>
        public int Gold {
            get { return _IntGold; }
            set
            {
                _IntGold = value;

                //event use
                if (evePlayerExtenalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Gold", Gold);
                    evePlayerExtenalData(kv);
                }
            }
        }
        public int Diamonds {
            get { return _IntDiamonds; }
            set
            {
                _IntDiamonds = value;

                //event use
                if (evePlayerExtenalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Diamonds", Diamonds);
                    evePlayerExtenalData(kv);
                }
            }
        }

        //make a private constructor
        private PlayerExtenalData() { }

        public PlayerExtenalData(int experience, int killNum, int level,
            int gold, int diamonds)
        {
            _IntExperience = experience;
            _IntKillNumber = killNum;
            _IntLevel = level;
            _IntGold = gold;
            _IntDiamonds = diamonds;
        }

    }
}

