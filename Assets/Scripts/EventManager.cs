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

    public delegate void UpdateBalanceSecondsSignToUI(int seconds);
    public static event UpdateBalanceSecondsSignToUI updateBalanceSecondsSignToUI;

    public delegate void IncreaseTheHypeTime();
    public static event IncreaseTheHypeTime increaseTheHypeTime;

    public delegate void TakeSnapshot();
    public static event TakeSnapshot takeSnapshot;

    public delegate void PlayGaspSound();
    public static event PlayGaspSound playGaspSound;



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

    public static void invokeSubscribersTo_UpdateBalanceSecondsSignToUI(int seconds)
    {
        updateBalanceSecondsSignToUI(seconds);
    }

    public static void invokeSubscribersTo_IncreaseTheHypeTime()
    {
        increaseTheHypeTime();
    }

    public static void invokeSubscribersTo_TakeSnapshot()
    {
        if(takeSnapshot != null)
            takeSnapshot();
    }

    public static void invokeSubscribersTo_PlayGaspSound()
    {
        playGaspSound();
    }



}
