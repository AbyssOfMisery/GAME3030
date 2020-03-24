/*
 * Title:"Dungoen and dragons"
 *      
 *     View Mode: response to player clicks
 *      
 * Description:
 *    do response to click event
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
using Model;

namespace View {
    
    public class View_DisplayPlayerInfo : MonoBehaviour
    {
        //display on screen
        public Text TxtPlayerName;               //player name
        public Slider SliHp;                     //Hp
        public Slider SliMp;                     //Mp
        public Text TxtCurrentLevelByScreen;     //current level
        public Text TxtCurrentHpByScreen;        //current hp
        public Text TxtMaxHpByScreen;            //max hp
        public Text TxtCurrentMpByScreen;        //current mp
        public Text TxtMaxMpByScreen;            //max mp
        public Text TxtCurrentExpByScreen;       //Current exp
        public Text TxtGoldByScreen;             //gold
        public Text TxtDiamondsByScreen;         //diamond


        public Text TxtCurHp;                      //current hp
        public Text TxtMaxHp;                      //max hp
        public Text TxtCurMp;                      //current mp
        public Text TxtMaxMp;                      //max mp
        public Text TxtCurATK;                     //Attack damage
        public Text TxtMaxATK;                     //Max Attack Damage
        public Text TxtCurDEF;                     //Defence 
        public Text TxtMaxDEF;                     //Max Defence
        public Text TxtCurDEX;                     //Dexterity
        public Text TxtMaxDEX;                     //max dexterity
        public Text TxtLevel;                      //level
        public Text TxKillNum;                     //Number of enemy kills
        public Text TxtExp;                        //exp
        public Text TxtGold;                       //gold
        public Text TxtDiamonds;                   //diamond

        //const
        public const float WAIT_FOR_SECONDS_ON_START = 0.3f;

        private void Awake()
        {
            PlayerSaveData.evePlayerSaveDate += DisplayHP;
            PlayerSaveData.evePlayerSaveDate += DisplayMaxHP;
            PlayerSaveData.evePlayerSaveDate += DisplayMagic;
            PlayerSaveData.evePlayerSaveDate += DisplayMaxMagic;
            PlayerSaveData.evePlayerSaveDate += DisplayATK;
            PlayerSaveData.evePlayerSaveDate += DisplayMaxATK;
            PlayerSaveData.evePlayerSaveDate += DisplayDEF;
            PlayerSaveData.evePlayerSaveDate += DisplayMaxDEF;
            PlayerSaveData.evePlayerSaveDate += DisplayDEX;
            PlayerSaveData.evePlayerSaveDate += DisplayMaxDEX;

            PlayerExtenalData.evePlayerExtenalData += DisplayExp;
            PlayerExtenalData.evePlayerExtenalData += DisplayKillNum;
            PlayerExtenalData.evePlayerExtenalData += DisplayLevel;
            PlayerExtenalData.evePlayerExtenalData += DisplayGold;
            PlayerExtenalData.evePlayerExtenalData += DisplayDiamond;
        }

        // Start is called before the first frame update
        IEnumerator Start()
        {
            //  PlayerSaveDataProxy playerSaveDataProxy = new PlayerSaveDataProxy(100, 100, 10,
            //  5, 45, 100, 100, 10, 5, 50, 0, 0, 0);
            //
            //  PlayerExtenalDataProxy playerExtenalDataProxy = new PlayerExtenalDataProxy(0, 0, 0, 0, 0);

            yield return new WaitForSeconds(WAIT_FOR_SECONDS_ON_START);
            //Show initial value
            PlayerSaveDataProxy.GetInstance().DisplayAllOriginalValues();
            PlayerExtenalDataProxy.GetInstance().DisplayerAllOriginalValue();

            //player name
            // if((GlobalParaMgr.PlayerName != null) && (!GlobalParaMgr.PlayerName.Trim().Equals("")))
            if(!string.IsNullOrEmpty(GlobalParaMgr.PlayerName))
            {
                TxtPlayerName.text = GlobalParaMgr.PlayerName;
            }
        }

        #region event register function
        void DisplayHP(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Health"))
            {
                if(TxtCurrentHpByScreen && TxtCurHp)
                {
                    TxtCurrentHpByScreen.text = kv.Values.ToString();
                    TxtCurHp.text = kv.Values.ToString();

                    //slider hp
                    SliHp.value = (float)kv.Values;
                }

            }
        }

        void DisplayMaxHP(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxHealth"))
            {
                if(TxtMaxHpByScreen&&TxtMaxHp)
                {
                    TxtMaxHpByScreen.text = kv.Values.ToString();
                    TxtMaxHp.text = kv.Values.ToString();
                    SliHp.minValue = 0;
                    SliHp.maxValue = (float)kv.Values;
                }

            }
        }
        void DisplayMagic(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Magic"))
            {
                if(TxtCurrentMpByScreen && TxtCurMp)
                {
                    TxtCurMp.text = kv.Values.ToString();
                    TxtCurrentMpByScreen.text = kv.Values.ToString();
                    SliMp.value = (float)kv.Values;
                }

            }
        }
        void DisplayMaxMagic(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxMagic"))
            {
                if(TxtMaxMpByScreen && TxtMaxMp)
                {
                    TxtMaxMp.text = kv.Values.ToString();
                    TxtMaxMpByScreen.text = kv.Values.ToString();

                    //slider mp
                    SliMp.minValue = 0;
                    SliMp.maxValue = (float)kv.Values;
                }
              
            }
        }
        void DisplayATK(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Attack"))
            {
                if(TxtCurATK)
                {
                    TxtCurATK.text = kv.Values.ToString();
                }

            }
        }
        void DisplayMaxATK(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxAttack"))
            {
                if(TxtMaxATK)
                {
                    TxtMaxATK.text = kv.Values.ToString();
                }
            }
        }
        void DisplayDEF(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Defence"))
            {
                if(TxtCurDEF)
                {
                    TxtCurDEF.text = kv.Values.ToString();
                }

            }
        }
        void DisplayMaxDEF(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxDefence"))
            {
                if(TxtMaxDEF)
                {
                    TxtMaxDEF.text = kv.Values.ToString();
                }
            }
        }
        void DisplayDEX(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Dexterity"))
            {
                if(TxtCurDEX)
                {
                    TxtCurDEX.text = kv.Values.ToString();
                }
            }
        }
        void DisplayMaxDEX(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxDexterity"))
            {
                if(TxtMaxDEX)
                {
                    TxtMaxDEX.text = kv.Values.ToString();

                }
            }
        }

        void DisplayExp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Experience"))
            {
                if(TxtExp&& TxtCurrentExpByScreen)
                {
                    TxtCurrentExpByScreen.text = kv.Values.ToString();
                    TxtExp.text = kv.Values.ToString();
                }
            }
        }

        void DisplayKillNum(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("KillNumber"))
            {
                if(TxKillNum)
                {
                    TxKillNum.text = kv.Values.ToString();
                }
            }
        }

        void DisplayLevel(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Level"))
            {
                if(TxtCurrentLevelByScreen&& TxtLevel)
                {
                    TxtLevel.text = kv.Values.ToString();
                    TxtCurrentLevelByScreen.text = kv.Values.ToString();
                }
            }
        }

        void DisplayGold(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Gold"))
            {
                if(TxtGoldByScreen&& TxtGold)
                {
                    TxtGoldByScreen.text = kv.Values.ToString();
                    TxtGold.text = kv.Values.ToString();
                }

            }
        }

        void DisplayDiamond(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Diamonds"))
            {
                if(TxtDiamondsByScreen&& TxtDiamonds)
                {
                    TxtDiamondsByScreen.text = kv.Values.ToString();
                    TxtDiamonds.text = kv.Values.ToString();
                }
            }
        }

        #endregion

    }//class end
}

