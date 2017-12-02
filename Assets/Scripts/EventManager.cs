using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager instance = null;
    
    public delegate void Failure();
    public static event Failure failure;

    public delegate void Success();
    public static event Success success;

    public delegate void UpdateTimeRemainingToUI(int time);
    public static event UpdateTimeRemainingToUI updateTimeRemainingToUI;

    public delegate void StartTheBalancing();
    public static event StartTheBalancing startTheBalancing;

    public delegate void LoadTheBalanceScene();
    public static event LoadTheBalanceScene loadTheBalanceScene;

    void Awake()
    {
        singleton();
    }

    void singleton()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    

    public static void invokeSubscribersTo_Failure()
    {
        failure();
    }

    public static void invokeSubscribersTo_Success()
    {
        success();
    }

    public static void invokeSubscribersTo_UpdateTimeRemainingToUI(int time)
    {
        updateTimeRemainingToUI(time);
    }

    public static void invokeSubscribersTo_StartTheBalancing()
    {
        startTheBalancing();
    }

    public static void invokeSubscribersTo_LoadTheBalanceScene()
    {
        loadTheBalanceScene();
    }



}
