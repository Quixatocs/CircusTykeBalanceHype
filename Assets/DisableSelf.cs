using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableSelf : MonoBehaviour {

    public Button hypeButton;

    public void DisableInteractivity()
    {
        GetComponent<Button>().interactable = false;
        hypeButton.interactable = false;
    }
}
