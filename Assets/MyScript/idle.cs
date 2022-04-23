using UnityEngine;

public class idle : IControl
{
    public void enterState(Controller2D controller)
    {
        
    }
    public void updateState(Controller2D controller)
    {
        controller.movement_speed = Input.GetAxis("Horizontal");
        controller.animator.SetFloat("speed", Mathf.Abs(controller.movement_speed));
        if (controller.movement_speed != 0)
        {
            controller.switchState(controller.run);
        }

        controller.anyToJump();
    }
    public void collisionState(Controller2D controller, Collision2D collision)
    {

    }
}
