using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager instance = null;


    public delegate void Failure();
    public static event Failure failure;

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


    
}
