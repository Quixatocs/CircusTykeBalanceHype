using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeSnapshot : MonoBehaviour {

    public Image image;

    void OnEnable()
    {
        EventManager.takeSnapshot += InitiateSnapshot;
    }

    void OnDisable()
    {
        EventManager.takeSnapshot -= InitiateSnapshot;
    }

    private void InitiateSnapshot()
    {
        StartCoroutine(Snapshot());
    }

    private IEnumerator Snapshot()
    {
        image.enabled = true;
        yield return new WaitForSeconds(0.1f);
        image.enabled = false;
    }
}
