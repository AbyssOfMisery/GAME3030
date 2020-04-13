/*
 * Title:"Dungoen and dragons"
 *      
 *      global layer: save and load script
 *      
 * Description:
 *          -save game datas
 *          -load game datas
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
using Model;

namespace Global
{
    public class SaveAndLoading : MonoBehaviour
    {
        private static SaveAndLoading _Instance; // instance

        //global config path
        private static string _FileNameByGlobalParameterData = Application.persistentDataPath + "/GlobalParaData.xml";
        //play data
        private static string _FileNameByKernalData = Application.persistentDataPath + "/KernalData.xml";
        //player extend data
        private static string _FileNameByExtendalData = Application.persistentDataPath + "/ExtenalData.xml";
        //player inventory data
        private static string _FileNameByInventoryData = Application.persistentDataPath + "/InventoryData.xml";

        //mode layer proxy
        private static PlayerSaveDataProxy _PlayerKernalDataProxy;
        private static PlayerExtenalDataProxy _PlayerExtenalDataProxy;
        private static PlayerInventoryDataProxy _PlayerInventoryDataProxy;

        public static SaveAndLoading GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new GameObject("SaveAndLoad").AddComponent<SaveAndLoading>();
            }
            return _Instance;
        }

        #region save game datas
        /// <summary>
        /// save game process
        /// </summary>
        /// <returns></returns>
        public bool SaveGameProcess()
        {
            _PlayerKernalDataProxy = PlayerSaveDataProxy.GetInstance();
            _PlayerExtenalDataProxy = PlayerExtenalDataProxy.GetInstance();
            _PlayerInventoryDataProxy = PlayerInventoryDataProxy.GetInstance();

            //save game config
            StoreTOXML_GlobalParaData();
            //save player core data
            StoreTOXML_KernalData();
            //save player extenal data
            StoreTOXML_ExtenalData();
            //save player inventory data
            StoreTOXML_InventoryData();
            return true;
        }


        //save game config
        private void StoreTOXML_GlobalParaData()
        {
            string playerName = GlobalParaMgr.PlayerName;
            ScenesEnum scenesName = GlobalParaMgr.NextScenesName;
            GlobalParameterData GPD = new GlobalParameterData(scenesName, playerName);
            
            //Object serialization
            string s = XmlOperation.GetInstance().SerializeObject(GPD, typeof(GlobalParameterData));

            //create xml file, and save data to this xml file

            if(!string.IsNullOrEmpty(_FileNameByGlobalParameterData))
            {
                XmlOperation.GetInstance().CreateXML(_FileNameByGlobalParameterData, s);
            }

            Log.Write(GetType() + "StoreTOXML_GlobalParaData()/ xml path =" + _FileNameByGlobalParameterData);
        }
        //save player core data
        private void StoreTOXML_KernalData()
        {
            //data that need to be save to xml file

            float health =_PlayerKernalDataProxy.Health;
            float magic =_PlayerKernalDataProxy.Magic;
            float attack = _PlayerKernalDataProxy.Attack;
            float defence = _PlayerKernalDataProxy.Defence;
            float dexterity =_PlayerKernalDataProxy.Dexterity;

            float maxHealth =_PlayerKernalDataProxy.MaxHealth;
            float maxMagic =_PlayerKernalDataProxy.MaxMagic;
            float maxAttack = _PlayerKernalDataProxy.MaxAttack;
            float maxDefence = _PlayerKernalDataProxy.MaxDefence;
            float maxDexterity = _PlayerKernalDataProxy.MaxDexterity;

            float attaclItem = _PlayerKernalDataProxy.AttackByProp;
            float defenceItem = _PlayerKernalDataProxy.DefenceByProp;
            float dexterityItem = _PlayerKernalDataProxy.DexterityByProp;

            PlayerSaveData PSD = new PlayerSaveData(
                health, magic, attack, defence, dexterity,
                maxHealth, maxMagic, maxAttack, maxDefence, maxDexterity,
                attaclItem, defenceItem, dexterityItem
                );

            //Object serialization
            string s = XmlOperation.GetInstance().SerializeObject(PSD, typeof(GlobalParameterData));

            //create xml file, and save data to this xml file

            if (!string.IsNullOrEmpty(_FileNameByKernalData))
            {
                XmlOperation.GetInstance().CreateXML(_FileNameByKernalData, s);
            }

            Log.Write(GetType() + "StoreTOXML_KernalData()/ xml path =" + _FileNameByKernalData);
        }
        //save player extenal data
        private void StoreTOXML_ExtenalData()
        {
            int exp =_PlayerExtenalDataProxy.Experience;
            int killNum=_PlayerExtenalDataProxy.KillNumber;
            int level = _PlayerExtenalDataProxy.Level;
            int glod = _PlayerExtenalDataProxy.Gold;
            int diamond =_PlayerExtenalDataProxy.Diamonds;

            PlayerExtenalData PED = new PlayerExtenalData(exp,killNum,level,glod,diamond);
            //Object serialization
            string s = XmlOperation.GetInstance().SerializeObject(PED, typeof(GlobalParameterData));

            //create xml file, and save data to this xml file

            if (!string.IsNullOrEmpty(_FileNameByExtendalData))
            {
                XmlOperation.GetInstance().CreateXML(_FileNameByExtendalData, s);
            }

            Log.Write(GetType() + "StoreTOXML_ExtenalData()/ xml path =" + _FileNameByExtendalData);
        }
        //save player inventory data
        private void StoreTOXML_InventoryData()
        {
            int HP =_PlayerInventoryDataProxy.HealthPotionNum;
            int MP =_PlayerInventoryDataProxy.ManaPotionNum;
            int ATKItem = _PlayerInventoryDataProxy.PropATKNum;
            int DEFItem = _PlayerInventoryDataProxy.PropDEFNum;
            int DEXItem = _PlayerInventoryDataProxy.PropDEXNum;

            PlayerInventoryDataProxy PIDP = new PlayerInventoryDataProxy(HP, MP, ATKItem, DEFItem, DEXItem);
            //Object serialization
            string s = XmlOperation.GetInstance().SerializeObject(PIDP, typeof(GlobalParameterData));

            //create xml file, and save data to this xml file

            if (!string.IsNullOrEmpty(_FileNameByInventoryData))
            {
                XmlOperation.GetInstance().CreateXML(_FileNameByInventoryData, s);
            }

            Log.Write(GetType() + "StoreTOXML_InventoryData()/ xml path =" + _FileNameByInventoryData);
        }
        #endregion

        #region load game datas
        /// <summary>
        /// load game config
        /// </summary>
        /// <returns></returns>
        public bool LoadingGame_GlobalParameter()
        {
            //load game config
            ReadFromXML_GlobalParaData();

            return true;
        }

        /// <summary>
        /// load player data
        /// </summary>
        /// <returns></returns>
        public bool loadingGame_PlayerData()
        {
            //load player core datas
            ReadFromXML_PlayerKernalData();
            //load player extenal datas
            ReadFromXML_PlayerExtenalData();
            //load player inventory datas
            ReadFromXML_PlayerInventoryData();
            return true;
        }

        //load game config
        private void ReadFromXML_GlobalParaData()
        {
            GlobalParameterData GPD = null;

            if(string.IsNullOrEmpty(_FileNameByGlobalParameterData))
            {
                Debug.LogError(GetType()+ "/ReadFromXML_GlobalParaData()/_FileNameByGlobalParameterData doesn't exist");
                return;
            }

            try
            {

                //load xml
                string strTemp = XmlOperation.GetInstance().LoadXML(_FileNameByGlobalParameterData);

                GPD = XmlOperation.GetInstance().DeserializeObject(strTemp, typeof(GlobalParameterData)) as GlobalParameterData;

                GlobalParaMgr.PlayerName = GPD.PlayerName;
                GlobalParaMgr.NextScenesName = GPD.NextScenesName;
                GlobalParaMgr.CurGameType = CurrentGameType.Continue;
            }
            catch 
            {
                Debug.LogError(GetType()+ "/ReadFromXML_GlobalParaData()/load game save config data failed");
            }

        }

        //load player core datas
        private void ReadFromXML_PlayerKernalData()
        {
            PlayerSaveData PSD = null;

            if (string.IsNullOrEmpty(_FileNameByKernalData))
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerKernalData()/_FileNameByKernalData doesn't exist");
                return;
            }

            try
            {

                //load xml
                string strTemp = XmlOperation.GetInstance().LoadXML(_FileNameByKernalData);

                PSD = XmlOperation.GetInstance().DeserializeObject(strTemp, typeof(PlayerSaveData)) as PlayerSaveData;

                PlayerSaveDataProxy._Instance.Health = PSD.Health;
                PlayerSaveDataProxy._Instance.Magic = PSD.Magic;
                PlayerSaveDataProxy._Instance.Attack = PSD.Attack;
                PlayerSaveDataProxy._Instance.Defence = PSD.Defence;
                PlayerSaveDataProxy._Instance.Dexterity = PSD.Dexterity;

                PlayerSaveDataProxy._Instance.MaxHealth = PSD.MaxHealth;
                PlayerSaveDataProxy._Instance.MaxMagic = PSD.MaxMagic;
                PlayerSaveDataProxy._Instance.MaxAttack = PSD.MaxAttack;
                PlayerSaveDataProxy._Instance.MaxDefence = PSD.MaxDefence;
                PlayerSaveDataProxy._Instance.MaxDexterity = PSD.MaxDexterity;

                PlayerSaveDataProxy._Instance.AttackByProp = PSD.AttackByProp;
                PlayerSaveDataProxy._Instance.DefenceByProp = PSD.DefenceByProp;
                PlayerSaveDataProxy._Instance.DexterityByProp = PSD.DexterityByProp;


            }
            catch
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerKernalData()/load game save config data failed");
            }
        }
        //load player extenal datas
        private void ReadFromXML_PlayerExtenalData()
        {
            PlayerExtenalData PED = null;

            if (string.IsNullOrEmpty(_FileNameByExtendalData))
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerExtenalData()/_FileNameByExtendalData doesn't exist");
                return;
            }

            try
            {

                //load xml
                string strTemp = XmlOperation.GetInstance().LoadXML(_FileNameByExtendalData);

                PED = XmlOperation.GetInstance().DeserializeObject(strTemp, typeof(PlayerExtenalData)) as PlayerExtenalData;

                PlayerExtenalDataProxy._Instance.Experience = PED.Experience;
                PlayerExtenalDataProxy._Instance.KillNumber = PED.KillNumber;
                PlayerExtenalDataProxy._Instance.Level = PED.Level;
                PlayerExtenalDataProxy._Instance.Gold = PED.Gold;
                PlayerExtenalDataProxy._Instance.Diamonds = PED.Diamonds;


            }
            catch
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerExtenalData()/load game save config data failed");
            }
        }
        //load player inventory datas
        private void ReadFromXML_PlayerInventoryData()
        {
            PlayerInventoryData PID = null;

            if (string.IsNullOrEmpty(_FileNameByInventoryData))
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerInventoryData()/_FileNameByInventoryData doesn't exist");
                return;
            }

            try
            {

                //load xml
                string strTemp = XmlOperation.GetInstance().LoadXML(_FileNameByExtendalData);

                PID = XmlOperation.GetInstance().DeserializeObject(strTemp, typeof(PlayerInventoryData)) as PlayerInventoryData;

                PlayerInventoryDataProxy.GetInstance().HealthPotionNum = PID.HealthPotionNum;
                PlayerInventoryDataProxy.GetInstance().ManaPotionNum = PID.ManaPotionNum;
                PlayerInventoryDataProxy.GetInstance().PropATKNum = PID.PropATKNum;
                PlayerInventoryDataProxy.GetInstance().PropDEFNum = PID.PropDEFNum;
                PlayerInventoryDataProxy.GetInstance().PropDEXNum = PID.PropDEXNum;

            }
            catch
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerInventoryData()/load game save config data failed");
            }
        }

        #endregion
    }

}
