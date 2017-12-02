using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {

    void OnEnable()
    {
        EventManager.failure += FallDueToGravity;
    }

    void OnDisable()
    {
        EventManager.failure -= FallDueToGravity;
    }

    private void FallDueToGravity()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }


}
