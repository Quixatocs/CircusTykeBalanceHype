using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterSeconds : MonoBehaviour {

    public float time;
	
	void Start () {
        Invoke("DisableSelfAfterSeconds", time);
    }

    private void DisableSelfAfterSeconds()
    {
        gameObject.SetActive(false);
    }
}
