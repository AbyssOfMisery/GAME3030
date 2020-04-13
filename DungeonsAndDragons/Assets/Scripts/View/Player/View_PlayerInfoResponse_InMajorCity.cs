/*
 * Title:"Dungoen and dragons"
 *      
 *     View layer: display info panel in major city
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

namespace View
{
    public class View_PlayerInfoResponse_InMajorCity : MonoBehaviour
    {
        public GameObject goPlayerSkillPanel;
        public GameObject goPlayerMissionPanel;
        public GameObject goPlayerShopPanel;
        public GameObject goPlayerInventoryPanel;

       public void DisplayRoles()
       {
            View_PlayerInfoResponse.Instance.DisplayPlayerRoles();
       }

       public void HideRoles()
       {
            View_PlayerInfoResponse.Instance.HidePlayerRoles();
       }
        
        public void DisplaySkillPanel()
        {
            if(goPlayerSkillPanel!=null)
            {
                BeforeOpenWindows(goPlayerSkillPanel);
            }
            goPlayerSkillPanel.SetActive(true);
        }

        public void HideSkillPanel()
        {
            if (goPlayerSkillPanel != null)
            {
                AfterCloseWindow();
            }
            goPlayerSkillPanel.SetActive(false);
        }

        public void DisplayMissionPanel()
        {
            if (goPlayerMissionPanel != null)
            {
                BeforeOpenWindows(goPlayerMissionPanel);
            }
            goPlayerMissionPanel.SetActive(true);
        }

        public void HideMissionPanel()
        {
            if (goPlayerMissionPanel != null)
            {
                AfterCloseWindow();
            }
            goPlayerMissionPanel.SetActive(false);
        }

        public void DisplayShopPanel()
        {
            if (goPlayerShopPanel != null)
            {
                BeforeOpenWindows(goPlayerShopPanel);
            }
            goPlayerShopPanel.SetActive(true);
        }

        public void HideShopPanel()
        {
            if (goPlayerShopPanel != null)
            {
                AfterCloseWindow();
            }
            goPlayerShopPanel.SetActive(false);
        }

        public void DisplayInventoryPanel()
        {
            if (goPlayerInventoryPanel != null)
            {
                BeforeOpenWindows(goPlayerInventoryPanel);
            }
            goPlayerInventoryPanel.SetActive(true);
        }

        public void HideInventoryPanel()
        {

            if (goPlayerInventoryPanel != null)
            {
                AfterCloseWindow();
            }
            goPlayerInventoryPanel.SetActive(false);
        }
        
        /// <summary>
        /// before open windows pre setting
        /// </summary>
        private void BeforeOpenWindows(GameObject goNeedDisplayPanel)
        {
            //deactive easy touch
            View_PlayerInfoResponse.Instance.HideET();
            //windows Modalization
            this.gameObject.GetComponent<UIMaskMgr>().SetMaskWindow(goNeedDisplayPanel);
        }

        private void AfterCloseWindow()
        {
            //active easy touch
            View_PlayerInfoResponse.Instance.DisplayET();
            //windows Modalization
            this.gameObject.GetComponent<UIMaskMgr>().CancleMaskWindow();
        }
    }
}
