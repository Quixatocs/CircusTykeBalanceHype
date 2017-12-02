using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicShake : MonoBehaviour {

    private const float SCALE_VALUE = 0.02f;
    private float invokeTime = 0.05f;

    void OnEnable()
    {
        EventManager.failure += Failure;
    }

    void OnDisable()
    {
        EventManager.failure -= Failure;
    }

    void Start()
    {
        InvokeRepeating("ChangePosition", 0.05f, invokeTime);
        InvokeRepeating("RandomiseInvoke", 0.5f, 0.5f);
    }

    private void ChangePosition()
    {
        transform.localPosition = new Vector3(Random.value * SCALE_VALUE, Random.value * SCALE_VALUE, 0f);
    }

    private void RandomiseInvoke()
    {
        invokeTime = Random.Range(0.1f, 0.01f);
    }

    private void Failure()
    {
        CancelInvoke();
    }
}
