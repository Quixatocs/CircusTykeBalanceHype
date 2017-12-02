using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAnimationSpeed : MonoBehaviour {

    public GameController gameController;

    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.speed = 0.5f + (Mathf.Abs(gameController.GetCurrentBalancePoleXPosition()) * 5);

    }
}
