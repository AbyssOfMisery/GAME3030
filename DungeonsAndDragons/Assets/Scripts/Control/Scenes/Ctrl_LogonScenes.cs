/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: logon scenes control script
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
using UnityEngine.SceneManagement;

using Global;
using Kernal;

namespace Control{
    public class Ctrl_LogonScenes : BaseControl
    {
        public static Ctrl_LogonScenes Instance; // add instance
        public AudioClip aucBgMusic; //bg music

        // Start is called before the first frame update
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            //to play background music
            AudioManager.SetAudioBackgroundVolumns(0.5f);
            AudioManager.SetAudioEffectVolumns(0.5f);

            AudioManager.PlayBackground(aucBgMusic);
        }

        //When player click on warrior icon will play a sound effect
        public void ClickWarriorAudio()
        {
            AudioManager.PlayAudioEffectA("1_LightRoar_SwordHero");
        }

        //When player click on witch icon will play a sound effect
        public void ClickWitchAudio()
        {
            AudioManager.PlayAudioEffectB("2_FireBallEffect_MagicHero");
        }

        //When player click on question icon will play a sound effect
        public void ClickQuestionAudio()
        {
            AudioManager.PlayAudioEffectB("ItemPickup");
        }
        /// <summary>
        /// go to next scenes
        /// </summary>
        internal void EnterNextScenes()
        {
            //turn to logon scenes
            //you have add level one on ScenesEnum dictionary
            //GlobalParaMgr.NextScenesName = ScenesEnum.LevelOne;
            //SceneManager.LoadScene(ConvertEnumToString.GetInstance().GetStrByEnumScenes(ScenesEnum.LoadingScenes));
            base.EnterNextScenes(ScenesEnum.LevelOne);
        }
    }

}
