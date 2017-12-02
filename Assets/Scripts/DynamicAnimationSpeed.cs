using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAnimationSpeed : MonoBehaviour {

    public GameController gameController;

    Animator animator;

    private float currentBalancePoleXPosition = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        currentBalancePoleXPosition = gameController.GetCurrentBalancePoleXPosition();
        animator.speed = 0.5f + (Mathf.Abs(gameController.GetCurrentBalancePoleXPosition()) * 5);

    }
}
