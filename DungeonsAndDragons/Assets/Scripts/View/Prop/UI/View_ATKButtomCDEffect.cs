/*
 * Title:"Dungoen and dragons"
 *      
 *      View layer: UI buttom attack CD effect
 *      
 * Description:
 *      UI buttom CD effect
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

namespace View
{
    public class View_ATKButtomCDEffect : MonoBehaviour
    {
        public Text TxtCountDownNumber;     //count down number
        public float FloCDTime = 5f;        //cool down time

        public Image ImgCircle;   //that cool down effect
        public GameObject goWhiteAndBlack; //cool down picture
        public KeyCode keyCode;     //keycode

        private float FloTimerDelta = 0f;       //a timer
        private bool IsStartTimer = false;      //to active cool down script
        private Button BtnSelf;                 //get it's buttom
        private bool _Enable = false;      //to active cool down script

        private void Start()
        {
            //get it's buttom
            BtnSelf = this.gameObject.GetComponent<Button>();
            //show counting down timer
            TxtCountDownNumber.enabled = true;
            EnableSelf();
        }

        private void Update()
        {
            //check if player to use this component
            if(_Enable)
            {
                if(Input.GetKeyDown(keyCode))
                {
                    IsStartTimer = true;
                    
                }

                if (IsStartTimer)
                {
                    TxtCountDownNumber.enabled = true;
                    goWhiteAndBlack.SetActive(true);            //active white and black icon
                    FloTimerDelta += Time.deltaTime;            // stack up time

                    //Showing time count down
                    TxtCountDownNumber.text = Mathf.RoundToInt(FloCDTime - FloTimerDelta).ToString();
                    ImgCircle.fillAmount = FloTimerDelta / FloCDTime; //give value to image circle
                    BtnSelf.interactable = false;

                    //while FloTimerDelta is greater than flocetime, reset everything
                    if (FloTimerDelta > FloCDTime)
                    {
                        TxtCountDownNumber.enabled = false;
                        IsStartTimer = false;
                        ImgCircle.fillAmount = 1;
                        FloTimerDelta = 0;
                        goWhiteAndBlack.SetActive(false);          //hide white and black icon 
                        BtnSelf.interactable = true;
                    }
                }
            }

        }

        /// <summary>
        /// response to player click events
        /// </summary>
        public void ResponseBtnClick()
        {
            IsStartTimer = true;
            BtnSelf.interactable = true;
        }

        /// <summary>
        /// active this component
        /// </summary>
        public void EnableSelf()
        {
            _Enable = true;
            goWhiteAndBlack.SetActive(false);
            BtnSelf.interactable = true;
        }

        /// <summary>
        /// disable this component
        /// </summary>
        public void DisableSelf()
        {
            _Enable = false;
            goWhiteAndBlack.SetActive(true);
            BtnSelf.interactable = false;
        }
    }

}
