using UnityEngine;

public class crouch : IControl
{
    Vector2 size;
    Vector2 offset;
    public void enterState(Controller2D controller)
    {
        controller.animator.SetBool("crouch", true);
        //controller.capsuleCollider.enabled = false;
        size = controller.capsuleCollider.size;
        offset = controller.capsuleCollider.offset;
        controller.capsuleCollider.size = new Vector2(controller.capsuleCollider.size.x, 1.3f);
        controller.capsuleCollider.offset = new Vector2(controller.capsuleCollider.offset.x, 0.6f);
    }
    public void updateState(Controller2D controller)
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.animator.SetBool("crouch", false);
            //controller.capsuleCollider.enabled = true;
            controller.capsuleCollider.size = size;
            controller.capsuleCollider.offset = offset;
            controller.idleOrRun();
        }
    }
    public void collisionState(Controller2D controller, Collision2D collision)
    {

    }
}
