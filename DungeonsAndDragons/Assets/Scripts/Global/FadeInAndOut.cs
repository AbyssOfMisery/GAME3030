/*
 * Title:"Dungoen and dragons"
 *      
 *      Public layer: Fade in and out
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


namespace Global
{
    public class FadeInAndOut : MonoBehaviour
    {
        public static FadeInAndOut Instance; // instance

        public float FloColorChangeSpeed = 1.0f; // color change speed

        public GameObject goRawImage; //raw Image object
        private RawImage _RawImage; //raw Image Component

        private bool _BoolScenesToClear = true; // fade out
        private bool _BoolScenesToBlack = false; //fade in

        private void Awake()
        {
            //Get this class instance
            Instance = this;
            //to access raw image compoent
            if(goRawImage)
            {
                _RawImage = goRawImage.GetComponent<RawImage>();
            }
        }

        //set scenes fade in
        public void SetScenesToClear()
        {
            _BoolScenesToClear = true;
            _BoolScenesToBlack = false;
        }

        //set scenes fade out
        public void SetScenesToBlack()
        {
            _BoolScenesToClear = false;
            _BoolScenesToBlack = true;
        }

        //change color alpha value to 0
        private void FadeToClear()
        {
            //Change color alpha value
            _RawImage.color = Color.Lerp(_RawImage.color,Color.clear,FloColorChangeSpeed * Time.deltaTime);
        }

        //change color alpha value to 255
        private void FadeToBlack()
        {
            //Change color alpha value
            _RawImage.color = Color.Lerp(_RawImage.color, Color.black, FloColorChangeSpeed * Time.deltaTime);
        }

        //scene fade in
        private void ScenesToClear()
        {
            FadeToClear();
            if(_RawImage.color.a <= 0.05f)
            {
                _RawImage.color = Color.clear;
                _RawImage.enabled = false;
                _BoolScenesToClear = false;
            }
        }

        //scene fade out
        private void ScenesToBlack()
        { 
            _RawImage.enabled = true;
            FadeToBlack();
            if(_RawImage.color.a >= 0.95f)
            {
                _RawImage.color = Color.black;
                _BoolScenesToBlack = false;
            }

        }

        private void Update()
        {
            if(_BoolScenesToClear)
            {
                //fade out
                ScenesToClear();
            }else if(_BoolScenesToBlack)
            {
                //fade in
                ScenesToBlack();
            }
        }//update end
    }//class end
}

