using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenController : MonoBehaviour
{
    float movement_speed;
    bool jump = false;
    [SerializeField]
    float jump_force = 5f;
    bool crouch = false;
    Animator animator;
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
  
    }

    // Update is called once per frame
    void Update()
    {
        // taking input for ellen movement and animation..
        movement_speed = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(movement_speed));

        //animating and flippping ellen according to value.
        Vector2 scale = transform.localScale;
        if (movement_speed < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if(movement_speed > 0)
            scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jump_force;//new Vector2(rigidbody.velocity.x, jump_force);
            jump = true;
        }  
        animator.SetBool("jump", jump);

        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = true;
            capsuleCollider.enabled = false;
        }
            
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = false;
            capsuleCollider.enabled = true;
        }
            
        animator.SetBool("crouch", crouch);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("ellen collided ground");
            jump = false;
        }
    }
}
