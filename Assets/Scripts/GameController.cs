using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    int difficulty = 1;

    private const float WANDER_AMOUNT = 0.001f; 

    public GameObject balancePole;
    public GameObject character;
    public GameObject balancingObstacles;


    private float currentRotation = 0;
    private float randomRotationAmount = 0;
    private float playerRotationAmount = 0f;
    private float pressureAmount = 0.1f;
    private float decayAmount = 0.01f;
    private float currentBalancePoleXPosition = 0f;

    private Vector3 balancePoint = Vector3.zero;
    private Vector3 floorPoint = new Vector3(0, -2, 0);

    void OnEnable()
    {
        EventManager.failure += Failure;
    }

    void OnDisable()
    {
        EventManager.failure -= Failure;
    }

    void Update () {

        if (currentRotation > 40f || currentRotation < -40f)
        {
            EventManager.invokeSubscribersTo_Failure();
        }

        if (Input.GetMouseButton(0))
        {
            playerRotationAmount -= pressureAmount;
        }

        if (Input.GetMouseButton(1))
        {
            playerRotationAmount += pressureAmount;
        }

        RotateBalancePole();
        WanderPoleBalancePoint();
        RotateObstacles();
    }

    void Start()
    {
        balancePoint = balancePole.transform.position;
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

    private void WanderPoleBalancePoint()
    {
        currentBalancePoleXPosition = currentRotation / 45;
        Vector3 newBalancePointPosition = new Vector3(currentBalancePoleXPosition, balancePole.transform.position.y, 0);
        Vector3 newCharacterPosition = new Vector3(currentBalancePoleXPosition, character.transform.position.y, 0);
        balancePole.transform.position = newBalancePointPosition;
        character.transform.position = newCharacterPosition;
    }

    private void RotateObstacles()
    {
        balancingObstacles.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -currentRotation/2));
        balancingObstacles.transform.localScale = new Vector3(1, 1 + ((Mathf.Abs(currentRotation) / 2)/200), 1);
    }

    public float GetCurrentBalancePoleXPosition()
    {
        return currentBalancePoleXPosition;
    }

    private void Failure()
    {

    }







}
