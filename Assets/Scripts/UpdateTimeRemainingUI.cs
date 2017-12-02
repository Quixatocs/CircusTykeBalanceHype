using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTimeRemainingUI : MonoBehaviour {

    void OnEnable()
    {
        EventManager.updateTimeRemainingToUI += UpdateUI;
    }

    void OnDisable()
    {
        EventManager.updateTimeRemainingToUI -= UpdateUI;
    }

    private void UpdateUI(int time)
    {
        GetComponent<Text>().text = time + " seconds";
    }
}
