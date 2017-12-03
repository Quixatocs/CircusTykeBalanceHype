using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleShake : MonoBehaviour {

    private const float SCALE_VALUE = 2.5f;
    private float invokeTime = 0.05f;


    void Start()
    {
        InvokeRepeating("ChangePosition", 0.05f, invokeTime);
        InvokeRepeating("RandomiseInvoke", 0.25f, 0.25f);
    }

    private void ChangePosition()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + Random.Range(-SCALE_VALUE, SCALE_VALUE), transform.localPosition.y + Random.Range(-SCALE_VALUE, SCALE_VALUE), 0f);
    }

    private void RandomiseInvoke()
    {
        invokeTime = Random.Range(0.1f, 0.01f);
    }

}
