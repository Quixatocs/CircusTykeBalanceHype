using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSelf : MonoBehaviour {

    void Start()
    {
        if (!GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GetIsSecondPlusPlaythrough())
        {
            DeactivateMyself();
        }
    }

    public void DeactivateMyself()
    {
        gameObject.SetActive(false);
    }
}
