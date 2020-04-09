/*
 * Title:"Dungoen and dragons"
 *      
 *     View layer: display character info
 *      
 * Description:
 *     displayer character infos; level, hp, mp, or etc 
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

using Control;
using Kernal;
using Global;

namespace View
{
    public class View_PlayerInfoResponse : MonoBehaviour
    {
        public static View_PlayerInfoResponse Instance;     //get instance
        public GameObject goPlayerDetailInfoPanel;   //player info panel
        public GameObject goET;                      //easy touch joystick

        public GameObject goPlayerInfo;

        public GameObject goBasicATK;                      //Visual Key
        public GameObject goMagicA;                      //Visual Key
        public GameObject goMagicB;                      //Visual Key
        public GameObject goMagicC;                      //Visual Key
        public GameObject goMagicD;                      //Visual Key
        public GameObject goAddingHp;                      //Visual Key

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            DisplayET();
        }

        /// <summary>
        /// show or hide player info panel
        /// </summary>
        //public void DisplayOrHidePlayerDetailInfoPanel()
        //{
        //    goPlayerDetailInfoPanel.SetActive(!goPlayerDetailInfoPanel.activeSelf); 
        //}

        public void DisplayPlayerRoles()
        {
            if(goPlayerDetailInfoPanel!=null)
            {
                BeforeOpenWindows(goPlayerDetailInfoPanel);
            }
            goPlayerDetailInfoPanel.SetActive(true);
        }

        public void HidePlayerRoles()
        {
            if (goPlayerDetailInfoPanel != null)
            {
                AfterCloseWindow();
            }
            goPlayerDetailInfoPanel.SetActive(false);
        }



        /// <summary>
        /// Show ET
        /// </summary>
        public void DisplayET()
        {
            goET.SetActive(true);
        }

        /// <summary>
        /// Hide ET
        /// </summary>
        public void HideET()
        {
            goET.SetActive(false);
        }

        /// <summary>
        /// Display Visual Key
        /// </summary>
        public void DisplayVisualKey()
        {
            goBasicATK.SetActive(true);
            goMagicA.SetActive(true);
            goMagicB.SetActive(true);
            goMagicC.SetActive(true);
            goMagicD.SetActive(true);
            goAddingHp.SetActive(true);
        }

        /// <summary>
        /// Hide Visual Key
        /// </summary>
        public void HideVisualKey()
        {
            goBasicATK.SetActive(false);
            goMagicA.SetActive(false);
            goMagicB.SetActive(false);
            goMagicC.SetActive(false);
            goMagicD.SetActive(false);
            goAddingHp.SetActive(false);
        }

        public void ShowBasicAttack()
        {
            goBasicATK.SetActive(true);
            goMagicA.SetActive(false);
            goMagicB.SetActive(false);
            goMagicC.SetActive(false);
            goMagicD.SetActive(false);
            goAddingHp.SetActive(false);
        }

        /// <summary>
        /// show player info UI
        /// </summary>
        public void DisplayPlayerUIInfo()
        {
            goPlayerInfo.SetActive(true);
        }

        /// <summary>
        /// hide player info ui
        /// </summary>
        public void HidePlayerUIInfo()
        {
            goPlayerInfo.SetActive(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        /// <summary>
        /// before open windows pre setting
        /// </summary>
        private void BeforeOpenWindows(GameObject goNeedDisplayPanel)
        {
            //deactive easy touch
            HideET();
            //windows Modalization
            this.gameObject.GetComponent<UIMaskMgr>().SetMaskWindow(goNeedDisplayPanel);
        }

        private void AfterCloseWindow()
        {
            //active easy touch
            DisplayET();
            //windows Modalization
            this.gameObject.GetComponent<UIMaskMgr>().CancleMaskWindow();
        }
        //#if UNITY_ANDROID || UNITY_IPHONE
        #region response to player attack
        //public void ResponseBASICATK()
        //{
        //    Ctrl_PlayerAttackInputByET.Instance.ResponseATKByBasic();
        //}


        public void ResponseATKByMagicA()
        {
            Ctrl_PlayerAttackInputByET.Instance.ResponseATKByMagicA();
            
        }

        public void ResponseATKByMagicB()
        {
            Ctrl_PlayerAttackInputByET.Instance.ResponseATKByMagicB();
        }

        public void ResponseATKByMagicC()
        {
            Ctrl_PlayerAttackInputByET.Instance.ResponseATKByMagicC();
        }

        public void ResponseATKByMagicD ()
        {
            Ctrl_PlayerAttackInputByET.Instance.ResponseATKByMagicC();
        }

 #endregion
//#endif
    }

}
