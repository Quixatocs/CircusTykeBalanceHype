using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour {

    Image image;

    //private float greenRedValue = 0;
    //private float blueAlphaValue = 1;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time / 10, 1));
    }

   


}
