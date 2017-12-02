using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour {

    private RectTransform rect;
    private Quaternion newRotation;

    public float rangeValues = 6f;
    public float repeatTime = 0.66f;
    public float damp = 0.1f;

    void Start () {
        rect = GetComponent<RectTransform>();
        InvokeRepeating("NewDestinationRotation", repeatTime, repeatTime);
    }
	
	
	void Update () {
        
        rect.transform.rotation = Quaternion.Lerp(rect.transform.rotation, newRotation, damp);
    }

    private void NewDestinationRotation()
    {
        newRotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-rangeValues, rangeValues)));
    }
}
