using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    int difficulty = 1;

    public GameObject balancePole;
    private float currentRotation = 0;
    private float randomRotationAmount = 0;
    private float playerRotationAmount = 0f;
    private float pressureAmount = 0.1f;
    private float decayAmount = 0.01f;


    void Update () {

        if (Input.GetMouseButton(0))
        {
            playerRotationAmount -= pressureAmount;
        }

        if (Input.GetMouseButton(1))
        {
            playerRotationAmount += pressureAmount;
        }

        RotateBalancePole();
    }

    void Start()
    {
        InvokeRepeating("ChangeRotationAmount", 1.0f, 1.0f);
    }

    private void RotateBalancePole()
    {
        AddRandomRotationToCurrent();
        AddPlayerControlledRotationToCurrent();
        balancePole.transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentRotation));
    }

    private void AddRandomRotationToCurrent()
    {
        currentRotation += randomRotationAmount;
    }

    private void AddPlayerControlledRotationToCurrent()
    {
        if (Mathf.Abs(playerRotationAmount) <= 0.02f)
        {
            playerRotationAmount = 0f;
        }

        if (playerRotationAmount < 0.02)
        {
            playerRotationAmount += decayAmount;
        }

        if (playerRotationAmount > 0.02)
        {
            playerRotationAmount -= decayAmount;
        }


        currentRotation += playerRotationAmount;
    }

    private void ChangeRotationAmount()
    {
        randomRotationAmount = Random.Range(-0.5f, 0.5f);
    }


}
