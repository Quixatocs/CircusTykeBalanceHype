using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceSecondsTextUI : MonoBehaviour {

    void OnEnable()
    {
        EventManager.updateBalanceSecondsSignToUI += UpdateUI;
    }

    void OnDisable()
    {
        EventManager.updateBalanceSecondsSignToUI -= UpdateUI;
    }

    private void UpdateUI(int seconds)
    {
        GetComponent<Text>().text = "Next Balance " + seconds + " Seconds";
    }

}
