using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    IControl currentState;
    public idle idle = new idle();
    public Run run = new Run();
    public Jump jump = new Jump();
    public crouch crouch = new crouch();

    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public CapsuleCollider2D capsuleCollider;

    public float jump_force = 5f;
    [HideInInspector]
    public float movement_speed;
    [HideInInspector]
    public bool bool_jump = false;

    // Start is called before the first frame update
    void Start()
    {
        //getting all neccessary components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        currentState = idle;
        currentState.enterState(this);

    }

    // Update is called once per frame
    void Update()
    {
        //if player jumps
        if (Input.GetButtonDown("Jump"))
            switchState(jump);
            
        currentState.updateState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.collisionState(this, collision);
    }

    public void switchState(IControl state)
    {
        currentState = state;
        currentState.enterState(this);
    }
}
