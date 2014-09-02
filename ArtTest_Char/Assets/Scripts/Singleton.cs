//------------------------------------------------------------------------------
//     单件基类
//
//     Author：Neil
//	   Date: August,2014
//------------------------------------------------------------------------------
using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    /**
      Returns the instance of this singleton.
   */
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError("An instance of " + typeof(T) +
                                   " is needed in the scene, but there is none.");
                }
                else
                {
                    GameObject.DontDestroyOnLoad(instance);
                    Debug.Log("Instance Get Succeeded [" + typeof(T) + "].");
                }
            }

            return instance;
        }
    }
}