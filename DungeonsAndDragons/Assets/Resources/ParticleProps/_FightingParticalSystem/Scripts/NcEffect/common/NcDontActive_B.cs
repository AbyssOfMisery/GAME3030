// ----------------------------------------------------------------------------------
//
// FXMaker
// Created by ismoon - 2012 - ismoonto@gmail.com
//
// ----------------------------------------------------------------------------------

// Attribute ------------------------------------------------------------------------
// Property -------------------------------------------------------------------------
// Loop Function --------------------------------------------------------------------
// Control Function -----------------------------------------------------------------
// Event Function -------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class NcDontActive_B : NcEffectBehaviour_B
{
	// --------------------------------------------------------------------------
	// --------------------------------------------------------------------------
	void Awake()
	{
#if UNITY_EDITOR
        //if (IsCreatingEditObject_B() == false)
#endif
		{
#if (UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9)
			Object.Destroy(gameObject);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            gameObject.active = false;
#pragma warning restore CS0618 // Type or member is obsolete
#endif
        }
	}

	void OnEnable()
	{
#if (UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9)
#else
#pragma warning disable CS0618 // Type or member is obsolete
        gameObject.active = false;
#pragma warning restore CS0618 // Type or member is obsolete
#endif
    }

	// --------------------------------------------------------------------------
}
