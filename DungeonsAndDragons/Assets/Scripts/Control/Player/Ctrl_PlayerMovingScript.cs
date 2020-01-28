/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: player movement control scripts
 *      
 * Description:
 *         Using easytouch plugin to control player
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

using Global;
using Kernal;

namespace Control {
    public class Ctrl_PlayerMovingScript : BaseControl
    {

        //  private const string JOYSTICK_NAME = "HeroJoystick";
        //
        //  #region
        // /// <summary>
        // /// find the joystick
        // /// </summary>
        // private void OnEnable()
        // {
        //     EasyJoystick.On_JoystickMove += OnJoystickMove;
        //     EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
        // }
        //
        // /// <summary>
        // /// joystick destroy
        // /// </summary>
        // private void OnDestroy()
        // {
        //     EasyJoystick.On_JoystickMove -= OnJoystickMove;
        //     EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        // }
        //
        // /// <summary>
        // /// disable is disable 
        // /// </summary>
        // private void OnDisable()
        // {
        //     EasyJoystick.On_JoystickMove -= OnJoystickMove;
        //     EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        // }
        // #endregion //register event
        //
        //
        //  //use joystick to move
        //  void OnJoystickMove(MovingJoystick move)
        //  {
        //      if(move.joystickName != JOYSTICK_NAME)
        //      {
        //          return;
        //      }
        //
        //      //too get joystick axis
        //      float joyPositionX = move.joystickAxis.x;
        //      float joyPositionY = move.joystickAxis.y;
        //
        //      if(joyPositionY != 0 || joyPositionX !=0)
        //      {
        //          //set up character rotation
        //          transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
        //
        //          //move character
        //          transform.Translate(Vector3.forward * Time.deltaTime * 5);
        //
        //          //play run animation
        //          GetComponent<Animation>().CrossFade("Run");
        //      }
        //  }
        //
        //  //stop use joystick
        //  void OnJoystickMoveEnd(MovingJoystick move)
        //  {
        //      //when player isnt moving character, the character will play idle animation
        //      if(move.joystickName == JOYSTICK_NAME)
        //      {
        //
        //          //play run animation
        //          GetComponent<Animation>().CrossFade("Idle");
        //      }
        //  }
        //  

        private CharacterController cc; //character controller
        private Animation anim; //animation 

        // Use this for initialization
        void Start()
        {

            cc = GetComponent<CharacterController>();
            anim = GetComponentInChildren<Animation>();
        }


        // Wait end of frame to manage charactercontroller, because gravity is managed by virtual controller
        void LateUpdate()
        {
            if (cc.isGrounded && (ETCInput.GetAxis(GlobalParameter.INPUT_MGR_VERTICAL) != 0 || ETCInput.GetAxis(GlobalParameter.INPUT_MGR_HORIZONTAL) != 0))
            {
                //anim.CrossFade("Run");
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.Running);
            }

            if (cc.isGrounded && ETCInput.GetAxis(GlobalParameter.INPUT_MGR_VERTICAL) == 0 && ETCInput.GetAxis(GlobalParameter.INPUT_MGR_HORIZONTAL) == 0)
            {
                //anim.CrossFade("Idle");
                Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.Idle);
            }
           // if(cc.isGrounded && ETCInput.GetButtonDown("ButtonAttack"))
           // {
           //     Ctrl_PlayerAnimation.Instance.SetCurrentAtionState(PlayerActionState.MagicTrickB);
           // }

           
        }
    }

}
