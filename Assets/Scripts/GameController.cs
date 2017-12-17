using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private float difficultyCoefficient = 0.2f;

    private const float WANDER_AMOUNT = 0.001f;

    private GameManager gameManager;

    public GameObject balancePole;
    public GameObject character;
    public GameObject balancingObstacles;

    public int timeRemaining = 20;


    private float currentRotation = 0;
    private float randomRotationAmount = 0;
    private float playerRotationAmount = 0f;
    private float pressureAmount = 0.1f;
    private float decayAmount = 0.01f;
    private float currentBalancePoleXPosition = 0f;

    private float gaspSoundThreshold = 0.5f;
    private float timeSinceGaspSound = 0;

    private bool hasFailed = false;
    private bool hasSucceded = false;

    void OnEnable()
    {
        EventManager.failure += Failure;
        EventManager.success += Success;
    }

    void OnDisable()
    {
        EventManager.failure -= Failure;
        EventManager.success -= Success;
    }

    void Update()
    {

        if ((currentRotation > 40f || currentRotation < -40f) && !hasFailed && !hasSucceded)
        {
            EventManager.invokeSubscribersTo_Failure();
        }

        if (timeRemaining <= 0 && !hasFailed && !hasSucceded)
        {
            timeRemaining = 0;
            EventManager.invokeSubscribersTo_Success();
        }

        if ((Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            playerRotationAmount -= pressureAmount;
        }

        if ((Input.GetMouseButton(0) && Input.mousePosition.x <= Screen.width / 2) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerRotationAmount += pressureAmount;
        }

        if (!hasFailed && !hasSucceded && (currentRotation > 15f || currentRotation < -15f) && Time.timeSinceLevelLoad - timeSinceGaspSound > gaspSoundThreshold)
        {
            timeSinceGaspSound = Time.timeSinceLevelLoad;
            EventManager.invokeSubscribersTo_PlayGaspSound();
        }

        if (!hasFailed)
        {
            gaspSoundThreshold = Map(Mathf.Abs(currentBalancePoleXPosition), 0f, 1f, 0.7f, 0.1f);
            
            RotateBalancePole();
            WanderPoleBalancePoint();
            RotateObstacles();
        }
    }

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timeRemaining = gameManager.GetGameHypeTimeAccrued();
        EventManager.invokeSubscribersTo_UpdateTimeRemainingToUI(timeRemaining);

        timeSinceGaspSound = Time.timeSinceLevelLoad;

        InvokeRepeating("ChangeRotationAmount", 1.0f, 1.0f);
        InvokeRepeating("IncreaseDifficulty", 1.0f, 1.0f);
        InvokeRepeating("DecreaseTimeRemaining", 1.0f, 1.0f);
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

    private void IncreaseDifficulty()
    {
        difficultyCoefficient += 0.02f;
    }

    private void ChangeRotationAmount()
    {
        randomRotationAmount = Random.Range(-difficultyCoefficient, difficultyCoefficient);
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
        hasFailed = true;
        CancelInvoke();
    }

    private void Success()
    {
        hasSucceded = true;
        CancelInvoke();
    }

    private void DecreaseTimeRemaining()
    {
        timeRemaining--;
        EventManager.invokeSubscribersTo_UpdateTimeRemainingToUI(timeRemaining);
    }

    private float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }







}
