/*
 * Title:"Dungoen and dragons"
 *      
 *      View layer: logon scenes
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
using Control;

namespace View {
    public class View_LogonScenes : MonoBehaviour
    {
        public GameObject _Warrior; //warrior prefab
        public GameObject _Witch;   //witch prefab
        public GameObject _UIWarriorInfo; //warrior info
        public GameObject _UIWitchInfo; //witch info
        public InputField _UserName; //user name


        private void Start()
        {
            //get this character
            //Defaults
            GlobalParaMgr.PlayerTypes = PlayerType.Warrior;
        }
        /// <summary>
        /// choose warrior
        /// </summary>
        public void ChangeToWarrior()
        {
            //show object
            _Warrior.SetActive(true);
            //hide object
            _Witch.SetActive(false);
            //show ui
            _UIWarriorInfo.SetActive(true);
            _UIWitchInfo.SetActive(false);

            //play audio clip
            Ctrl_LogonScenes.Instance.ClickWarriorAudio();
        }

        /// <summary>
        /// choose witch
        /// </summary>
        public void ChangeToWitch()
        {
            //show object
            _Warrior.SetActive(false);
            //hide object
            _Witch.SetActive(true);
            //show ui
            _UIWarriorInfo.SetActive(false);
            _UIWitchInfo.SetActive(true);
            GlobalParaMgr.PlayerTypes = PlayerType.Witch;

            //play audio clip
            Ctrl_LogonScenes.Instance.ClickWitchAudio();
        }

        //when player click on question icon
        public void OtherChampion()
        {
            //play audio clip
            Ctrl_LogonScenes.Instance.ClickQuestionAudio();
        }
        /// <summary>
        /// submit user name
        /// </summary>
        public void SubmitName()
        {
            //get user name
            GlobalParaMgr.PlayerName = _UserName.name;
            // switch to next scenes
            //(control layers)
            Ctrl_LogonScenes.Instance.EnterNextScenes();

        }
    }
}

