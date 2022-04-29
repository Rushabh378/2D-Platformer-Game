using UnityEngine;

public class crouch : IControl
{
    public void enterState(Controller2D controller)
    {
        controller.animator.SetBool("crouch", true);
        controller.capsuleCollider.enabled = false;
    }
    public void updateState(Controller2D controller)
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.animator.SetBool("crouch", false);
            controller.capsuleCollider.enabled = true;
            controller.idleOrRun();
        }
    }
    public void collisionState(Controller2D controller, Collision2D collision)
    {

    }
}
