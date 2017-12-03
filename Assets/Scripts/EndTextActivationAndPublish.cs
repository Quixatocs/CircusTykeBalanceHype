using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTextActivationAndPublish : MonoBehaviour {

    public Text text;
    public Image image;

    private bool hasDisplayedText = false;

    public string[] successLines;
    public string[] failLines;
    
    void OnEnable()
    {
        EventManager.success += Success;
        EventManager.failure += Failure;
    }

    void OnDisable()
    {
        EventManager.success -= Success;
        EventManager.failure -= Failure;
    }

    private void Success()
    {
        if (!hasDisplayedText)
            ShowText(true);
    }

    private void Failure()
    {
        if (!hasDisplayedText)
            ShowText(false);
    }

    private void ShowText(bool isSuccess)
    {
        hasDisplayedText = true;
        text.enabled = true;
        image.enabled = true;

        if (isSuccess)
        {
            int RNGsus = Mathf.FloorToInt(Random.Range(0, successLines.Length));
            text.text = successLines[RNGsus];
        }
        else
        {
            int RNGsus = Mathf.FloorToInt(Random.Range(0, failLines.Length));
            text.text = failLines[RNGsus];

        }

    }
}
