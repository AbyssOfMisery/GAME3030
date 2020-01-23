using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Internal;
using System.Collections;

public class KeyFrameEvents : MonoBehaviour
{
    public float runtime;
    public float runDis;

    public float backtime;
    public float backDis;

    public float animationSufferStopTime = 0.3f;
    public float animationTime = 0f;

    public delegate void CastHandler(int step);
    public CastHandler castHandler;
    
    public delegate void ActionRunHandler(float runDis,float value);
    public ActionRunHandler actionRunHandler;

    public delegate void ActionBackHandler(float backDis, float value);
    public ActionBackHandler actionBackHandler;

    public delegate void ActionStopHandler();
    public ActionStopHandler actionStopHandler;


    public delegate void AnimationSufferStopHandler(float dur);
    public AnimationSufferStopHandler animationSufferStopHandler;


     public delegate void CastFxPlayHandler(int idx,int bo);
     public CastFxPlayHandler castFxPlayHandler;

    public delegate void CreateFxsRundustHandler();
    public CreateFxsRundustHandler createFxsRundustHandler;

    public delegate void WeaponTrailEnabled(bool b);
    public WeaponTrailEnabled weaponTrailEnabled;

    public delegate void KFE_CameraBlur();
    public KFE_CameraBlur cameraBlur;

    public delegate void KFE_CameraShake();
    public KFE_CameraShake cameraShadke;

    public delegate void KFE_FxPlay(string url);
    public KFE_FxPlay fxPlay;
    void Attack_Cast(int step=0)
    {
        if (castHandler != null)
            castHandler(step);
    }

    void Action_Run()
    {
        if (actionRunHandler != null && runtime > 0 && runDis>0)
            actionRunHandler(runDis,runtime);
    }
    void Action_Back()
    {
        if (actionBackHandler != null && backtime > 0 && backDis>0)
            actionBackHandler(backDis,backtime);
    }

    void Action_Stop()
    {
        if (actionStopHandler != null)
            actionStopHandler();
    }

    void WeaponTrail_Enabled_True()
    {
        if (weaponTrailEnabled != null)
        {
            weaponTrailEnabled(true);
        }
    }
    void WeaponTrail_Enabled_False()
    {
        if (weaponTrailEnabled != null)
        {
            weaponTrailEnabled(false);
        }
    }

    void Animation_Suffer_Stop()
    {
        if (animationSufferStopHandler != null)
        {
            animationSufferStopHandler(animationSufferStopTime);
        }
    }

    void Animation_Stop()
    {
        gameObject.GetComponent<Animator>().speed = 0;
        if (animationTime > 0)
        {
            Invoke("Animation_On", animationTime);
        }
    }
    void Animation_On()
    {
        gameObject.GetComponent<Animator>().speed = 1;
    }


    void Cast_FX_Play_0(int bo=0)
    {
        if (castFxPlayHandler != null)
            castFxPlayHandler(0,bo);
    }

    void Cast_FX_Play_1(int bo=0)
    {
        if (castFxPlayHandler != null)
            castFxPlayHandler(1,bo);
    }

    void Cast_FX_Play_2(int bo=0)
    {
        if (castFxPlayHandler != null)
            castFxPlayHandler(2,bo);
    }

    void Cast_FX_Play_3(int bo = 0)
    {
        if (castFxPlayHandler != null)
            castFxPlayHandler(3, bo);
    }

    void Cast_FX_Play_4(int bo = 0)
    {
        if (castFxPlayHandler != null)
            castFxPlayHandler(4, bo);
    }

    void Cast_FX_Play_5(int bo = 0)
    {
        if (castFxPlayHandler != null)
            castFxPlayHandler(5, bo);
    }

    void CreateFx_Rundust()
    {
        if (createFxsRundustHandler != null)
        {
            createFxsRundustHandler();
        }
    }

    void CameraBlur()
    {
        if (cameraBlur != null)
        {
            cameraBlur();
        }
    }
    void Camera_Shake()
    {
        if (cameraShadke != null)
        {
            cameraShadke();
        }
    }

    public void Fx_Play(string url)
    {
        if (fxPlay != null)
        {
            fxPlay(url);
        }
    }
}

