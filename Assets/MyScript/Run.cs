﻿using UnityEngine;

public class Run : IControl
{
    public void enterState(Controller2D controller)
    {
        //Debug.Log("current state : - run state");
    }
    public void updateState(Controller2D controller)
    {
        // taking input for ellen movement and animation..
        controller.movement_speed = Input.GetAxis("Horizontal");

        //animating and flippping ellen according to value.
        Vector2 scale = controller.transform.localScale;
        if (controller.movement_speed < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (controller.movement_speed > 0)
            scale.x = Mathf.Abs(scale.x);
        controller.transform.localScale = scale;

        controller.animator.SetFloat("speed", Mathf.Abs(controller.movement_speed));

        Vector2 position = controller.transform.position;
        position.x += controller.movement_speed * controller.speed * Time.deltaTime;
        controller.transform.position = position;

        if (controller.movement_speed == 0)
        {
            controller.switchState(controller.idle);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.switchState(controller.crouch);
        };
    }
    public void collisionState(Controller2D controller, Collision2D collision)
    {
        
    }
}