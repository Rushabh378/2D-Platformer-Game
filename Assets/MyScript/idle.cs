using UnityEngine;

public class idle : IControl
{
    public void enterState(Controller2D controller)
    {
        
    }
    public void updateState(Controller2D controller)
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            controller.switchState(controller.run);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.switchState(controller.crouch);
        }
    }
    public void collisionState(Controller2D controller, Collision2D collision)
    {

    }
}
