using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateOnSuccess : MonoBehaviour {

    void OnEnable()
    {
        EventManager.success += Activate;
    }

    void OnDisable()
    {
        EventManager.success -= Activate;
    }

    private void Activate()
    {
        GetComponent<Text>().enabled = true;
    }
}
