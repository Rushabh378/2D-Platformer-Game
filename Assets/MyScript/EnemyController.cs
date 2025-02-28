﻿
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float sightLength = 2;
    public GameObject Detector;
    public float movementSpeed = 2f;
    float direction = 1f;
    bool facingRight = true;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(Detector.transform.position, Detector.transform.right, sightLength);
        if (hit2D)
        {
            if(hit2D.collider.name == "Ellen")
            {
                Debug.DrawRay(Detector.transform.position, Detector.transform.right, Color.red, sightLength);
                movementSpeed = 3;
            }
            else
            {
                Debug.DrawRay(Detector.transform.position, Detector.transform.right, Color.yellow, sightLength);
                direction *= -1f;
                flip();
            }
            
        }
        else
        {
            Debug.DrawRay(Detector.transform.position, Detector.transform.right, Color.green, sightLength);
        }

        Vector2 position =transform.position;
        position.x += direction * movementSpeed * Time.fixedDeltaTime;
        transform.position = position;
        animator.SetFloat("speed", movementSpeed);
    }
    private void flip()
    {
        transform.Rotate(0f, 180, 0f);
        facingRight = !facingRight;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("flipper"))
        {
            Debug.DrawRay(Detector.transform.position, Detector.transform.right, Color.yellow, sightLength);
            direction *= -1f;
            flip();
        }
    }
}
