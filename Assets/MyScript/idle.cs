using UnityEngine;

public class idle : IControl
{
    public void enterState(Controller2D controller)
    {
        //Debug.Log("current state : - idle state");
    }
    public void updateState(Controller2D controller)
    {
        controller.animator.SetFloat("speed", Mathf.Abs(controller.movement_speed));

        controller.movement_speed = Input.GetAxis("Horizontal");
        if (controller.movement_speed != 0)
        {
            controller.switchState(controller.run);
        }
    }
    public void collisionState(Controller2D controller, Collision2D collision)
    {

    }
}
