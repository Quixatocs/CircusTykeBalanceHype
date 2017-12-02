using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

    public GameObject target;

    public float damp = 0.1f;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, damp);
    }
}
