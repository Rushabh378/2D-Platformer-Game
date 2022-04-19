using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenController : MonoBehaviour
{
    [SerializeField]
    float movement_speed = 0f;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement_speed = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(movement_speed));

        Vector2 scale = transform.localScale;
        if (movement_speed < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if(movement_speed > 0)
            scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
