using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EllenController : MonoBehaviour
{
    float movementSpeed;
    bool jump = false;
    [SerializeField]
    float jump_force = 6f;
    [SerializeField]
    float speed = 5f;
    bool crouch = false;
    bool onground = false;
    bool facingRight = true;

    //for crouch
    Vector2 size;
    Vector2 offset;

    Animator animator;
    Rigidbody2D rigid;
    CapsuleCollider2D capsuleCollider;
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        health = GetComponent<Health>();
    }
    // Update is called once per frame
    void Update()
    {
        // taking input for ellen movement and animation..
        movementSpeed = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(movementSpeed));

        //animating and flippping ellen according to value.
        if (facingRight)
        {
            if(movementSpeed < 0)
            {
                flip();
            }
        }
        else
        {
            if(movementSpeed > 0)
            {
                flip();
            }
        }

        //jump
        if (Input.GetButtonDown("Jump") && onground == true)
        {
            rigid.velocity = Vector2.up * jump_force;
            jump = true;
            onground = false;
        }
        animator.SetBool("jump", jump);


        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = true;
            //capsuleCollider.enabled = false;
            size = capsuleCollider.size;
            offset = capsuleCollider.offset;
            capsuleCollider.size = new Vector2(capsuleCollider.size.x, 1.3f);
            capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, 0.6f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = false;
            //capsuleCollider.enabled = true;
            capsuleCollider.size = size;
            capsuleCollider.offset = offset;
        }
        animator.SetBool("crouch", crouch);
    }
    private void FixedUpdate()
    {
        if (!crouch)
        {
            Vector2 position = transform.position;
            position.x += movementSpeed * speed * Time.fixedDeltaTime;
            transform.position = position;
        }
        //if player hurt is true.
        //animator.SetBool("hurt", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("collided ground");
            jump = false;
            onground = true;
        }
        if (collision.gameObject.GetComponent<EnemyController>() == true)
        {
            //Debug.Log("ellen fot damaged.");
            gotDamaged();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("collision exited");
        animator.SetBool("hurt", false);
    }
    void flip()
    {
        transform.Rotate(0f, 180, 0f);
        facingRight = !facingRight;
    }
    void gotDamaged()
    {
        animator.SetBool("hurt", true);
        health.healthDrop();
    }
}