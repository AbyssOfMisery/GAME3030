/*
 * Title:"Dungoen and dragons"
 *      
 *     Just for testing
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
using Model;
public class TestModelLayer : MonoBehaviour
{
    public Text textHp;
    public Text textMaxHp;
    public Text textMp;
    public Text textMaxMp;
    public Text textATK;
    public Text textMaxATK;
    public Text textDEF;
    public Text textMaxDEF;
    public Text textDEX;
    public Text textMaxDEX;


    public Text textExp;
    public Text textKillNum;
    public Text textLevel;
    public Text textGold;
    public Text textDiamond;


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
    void Start()
    {
       // PlayerSaveDataProxy playerSaveDataProxy = new PlayerSaveDataProxy(100,100,10,
       //     5,45,100,100,10,5,50,0,0,0) ;
       //
       // PlayerExtenalDataProxy playerExtenalDataProxy = new PlayerExtenalDataProxy(0,0,0,0,0);
       // //Show initial value
       // PlayerSaveDataProxy._Instance.DisplayAllOriginalValues();
       // PlayerExtenalDataProxy._Instance.DisplayerAllOriginalValue();

    }

    #region user click event check
    public void IncreaseHP()
    {
        //use modle layer functions
        PlayerSaveDataProxy.GetInstance().IncreaseHealthValues(30);
    }
    public void DecreaseHP()
    {
        PlayerSaveDataProxy.GetInstance().DecreaseHealthValues(10);
    }
    public void IncreaseMagic()
    {
        PlayerSaveDataProxy.GetInstance().IncreaseMagicValues(40);
    }
    public void DecreaseMagic()
    {
        PlayerSaveDataProxy.GetInstance().DecreaseMagicValues(15);
    }

    public void IncreaseEXP()
    {
        //use modle layer functions
        PlayerExtenalDataProxy.GetInstance().AddEXP(100);
    }
    public void Killnumbers()
    {
        PlayerExtenalDataProxy.GetInstance().AddKillNumber(100);
    }
    public void Gold()
    {
        PlayerExtenalDataProxy.GetInstance().AddGold(100);
    }
    public void Diamond()
    {
        PlayerExtenalDataProxy.GetInstance().AddDiamond(100);
    }

    public void Level()
    {
        //PlayerExtenalDataProxy.GetInstance().AddLevel(1);
    }
    #endregion


    #region event register function
    void DisplayHP(KeyValueUpdate kv)
    {
      if(kv.Key.Equals("Health"))
        {
            textHp.text = kv.Values.ToString();
        }
    }
    void DisplayMaxHP(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxHealth"))
        {
            textMaxHp.text = kv.Values.ToString();
        }
    }
    void DisplayMagic(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Magic"))
        {
            textMp.text = kv.Values.ToString();
        }
    }
    void DisplayMaxMagic(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxMagic"))
        {
            textMaxMp.text = kv.Values.ToString();
        }
    }
    void DisplayATK(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Attack"))
        {
            textATK.text = kv.Values.ToString();
        }
    }
    void DisplayMaxATK(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxAttack"))
        {
            textMaxATK.text = kv.Values.ToString();
        }
    }
    void DisplayDEF(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Defence"))
        {
            textDEF.text = kv.Values.ToString();
        }
    }
    void DisplayMaxDEF(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxDefence"))
        {
            textMaxDEF.text = kv.Values.ToString();
        }
    }
    void DisplayDEX(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Dexterity"))
        {
            textDEX.text = kv.Values.ToString();
        }
    }
    void DisplayMaxDEX(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxDexterity"))
        {
            textMaxDEX.text = kv.Values.ToString();
        }
    }

    void DisplayExp(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Experience"))
        {
            textExp.text = kv.Values.ToString();
        }
    }

    void DisplayKillNum(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("KillNumber"))
        {
            textKillNum.text = kv.Values.ToString();
        }
    }

    void DisplayLevel(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Level"))
        {
            textLevel.text = kv.Values.ToString();
        }
    }

    void DisplayGold(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Gold"))
        {
            textGold.text = kv.Values.ToString();
        }
    }

    void DisplayDiamond(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Diamonds"))
        {
            textDiamond.text = kv.Values.ToString();
        }
    }

    #endregion
}
