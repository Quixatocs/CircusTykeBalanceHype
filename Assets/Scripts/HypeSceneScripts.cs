using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypeSceneScripts : MonoBehaviour {

    public void StartTheBalancing()
    {
        EventManager.invokeSubscribersTo_StartTheBalancing();
    }

    public void IncreaseTheHypeTime()
    {
        EventManager.invokeSubscribersTo_IncreaseTheHypeTime();
    }

    public void SkipThePreHype()
    {
        EventManager.invokeSubscribersTo_SkipThePreHype();
    }


}
