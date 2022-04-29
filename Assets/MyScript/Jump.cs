using UnityEngine;

public class Jump : IControl
{
    public void enterState(Controller2D controller)
    {
        controller.rb.velocity = Vector2.up * controller.jump_force; //new Vector2(controller.rb.velocity.x, controller.jump_force);
        //Debug.Log("form jump enterState");
        controller.animator.SetBool("jump", true);
    }
    public void updateState(Controller2D controller)
    {
        controller.run.updateState(controller);
        //Debug.Log("this line after run update in jump");
    }
    public void collisionState(Controller2D controller, Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            controller.idleOrRun();
        }
    }
}
