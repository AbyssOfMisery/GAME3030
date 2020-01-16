/*
 * Title:"Dungoen and dragons"
 *      
 *      Commom layer: audio manager
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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;                                    //泛型集合命名空间

namespace Kernal
{
    public class AudioManager : MonoBehaviour
    {
        public AudioClip[] AudioClipArray;                               //剪辑数组
        public static float AudioBackgroundVolumns = 1F;                 //背景音量
        public static float AudioEffectVolumns = 1F;                     //音效音量

        private static Dictionary<string, AudioClip> _DicAudioClipLib;   //音频库
        private static AudioSource[] _AudioSourceArray;                  //音频源数组
        private static AudioSource _AudioSource_BackgroundAudio;         //背景音乐
        private static AudioSource _AudioSource_AudioEffectA;            //音效源A
        private static AudioSource _AudioSource_AudioEffectB;            //音效源B

        /// <summary>
        /// Sound library resource loading
        /// </summary>
        void Awake()
        {
            //Audio library loading
            _DicAudioClipLib = new Dictionary<string, AudioClip>();
            foreach (AudioClip audioClip in AudioClipArray)
            {
                _DicAudioClipLib.Add(audioClip.name, audioClip);
            }
            //audio sources array
            _AudioSourceArray = this.GetComponents<AudioSource>();
            _AudioSource_BackgroundAudio = _AudioSourceArray[0];
            _AudioSource_AudioEffectA = _AudioSourceArray[1];
            _AudioSource_AudioEffectB = _AudioSourceArray[2];

            //Get volume value from data persistence
            if (PlayerPrefs.GetFloat("AudioBackgroundVolumns") >= 0)
            {
                AudioBackgroundVolumns = PlayerPrefs.GetFloat("AudioBackgroundVolumns");
                _AudioSource_BackgroundAudio.volume = AudioBackgroundVolumns;
            }
            if (PlayerPrefs.GetFloat("AudioEffectVolumns") >= 0)
            {
                AudioEffectVolumns = PlayerPrefs.GetFloat("AudioEffectVolumns");
                _AudioSource_AudioEffectA.volume = AudioEffectVolumns;
                _AudioSource_AudioEffectB.volume = AudioEffectVolumns;
            }
        }//Start_end

        /// <summary>
        /// Play background music
        /// </summary>
        /// <param name="audioClip">音频剪辑</param>
        public static void PlayBackground(AudioClip audioClip)
        {
            //Prevent repeated playback of background music.
            if (_AudioSource_BackgroundAudio.clip == audioClip)
            {
                return;
            }
            //Handling global background music volume
            _AudioSource_BackgroundAudio.volume = AudioBackgroundVolumns;
            if (audioClip)
            {
                _AudioSource_BackgroundAudio.loop = true;
                _AudioSource_BackgroundAudio.clip = audioClip;
                _AudioSource_BackgroundAudio.Play();
            }
            else
            {
                Debug.LogWarning("[AudioManager.cs/PlayBackground()] audioClip==null !");
            }
        }

        //Play background music
        public static void PlayBackground(string strAudioName)
        {
            if (!string.IsNullOrEmpty(strAudioName))
            {
                PlayBackground(_DicAudioClipLib[strAudioName]);
            }
            else
            {
                Debug.LogWarning("[AudioManager.cs/PlayBackground()] strAudioName==null !");
            }
        }

        /// <summary>
        /// Play sound effects_Audio source A
        /// </summary>
        /// <param name="audioClip">Audio clip</param>
        private static void PlayAudioEffectA(AudioClip audioClip)
        {
            //Handling Global Sound Volume
            _AudioSource_AudioEffectA.volume = AudioEffectVolumns;

            if (audioClip)
            {
                _AudioSource_AudioEffectA.clip = audioClip;
                _AudioSource_AudioEffectA.Play();
            }
            else
            {
                Debug.LogWarning("[AudioManager.cs/PlayAudioEffectA()] audioClip==null ! Please Check! ");
            }
        }

        /// <summary>
        /// Play sound effects_Audio source B
        /// </summary>
        /// <param name="audioClip">Audio clip</param>
        private static void PlayAudioEffectB(AudioClip audioClip)
        {
            //Handling Global Sound Volume
            _AudioSource_AudioEffectB.volume = AudioEffectVolumns;

            if (audioClip)
            {
                _AudioSource_AudioEffectB.clip = audioClip;
                _AudioSource_AudioEffectB.Play();
            }
            else
            {
                Debug.LogWarning("[AudioManager.cs/PlayAudioEffectB()] audioClip==null ! Please Check! ");
            }
        }

        /// <summary>
        /// Play sound effects_Audio source A
        /// </summary>
        /// <param name="strAudioEffctName">Sound name</param>
        public static void PlayAudioEffectA(string strAudioEffctName)
        {
            if (!string.IsNullOrEmpty(strAudioEffctName))
            {
                PlayAudioEffectA(_DicAudioClipLib[strAudioEffctName]);
            }
            else
            {
                Debug.LogWarning("[AudioManager.cs/PlayAudioEffectA()] strAudioEffctName==null ! Please Check! ");
            }
        }

        /// <summary>
        /// Play sound effects_Audio source B
        /// </summary>
        /// <param name="strAudioEffctName">Sound name</param>
        public static void PlayAudioEffectB(string strAudioEffctName)
        {
            if (!string.IsNullOrEmpty(strAudioEffctName))
            {
                PlayAudioEffectB(_DicAudioClipLib[strAudioEffctName]);
            }
            else
            {
                Debug.LogWarning("[AudioManager.cs/PlayAudioEffectB()] strAudioEffctName==null ! Please Check! ");
            }
        }

        /// <summary>
        /// Change background music volume
        /// </summary>
        /// <param name="floAudioBGVolumns"></param>
        public static void SetAudioBackgroundVolumns(float floAudioBGVolumns)
        {
            _AudioSource_BackgroundAudio.volume = floAudioBGVolumns;
            AudioBackgroundVolumns = floAudioBGVolumns;
            //Data persistence
            PlayerPrefs.SetFloat("AudioBackgroundVolumns", floAudioBGVolumns);
        }

        /// <summary>
        /// Change sound volume
        /// </summary>
        /// <param name="floAudioEffectVolumns"></param>
        public static void SetAudioEffectVolumns(float floAudioEffectVolumns)
        {
            _AudioSource_AudioEffectA.volume = floAudioEffectVolumns;
            _AudioSource_AudioEffectB.volume = floAudioEffectVolumns;
            AudioEffectVolumns = floAudioEffectVolumns;
            //Data persistence
            PlayerPrefs.SetFloat("AudioEffectVolumns", floAudioEffectVolumns);
        }
    }//Class_end
}

