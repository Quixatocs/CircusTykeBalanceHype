using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnFailure : MonoBehaviour {

    void OnEnable()
    {
        EventManager.failure += DeactivateSelf;
    }

    void OnDisable()
    {
        EventManager.failure -= DeactivateSelf;
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
}
