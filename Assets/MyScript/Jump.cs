using UnityEngine;

public class Jump : IControl
{
    public void enterState(Controller2D controller)
    {
        controller.rb.velocity = Vector2.up * controller.jump_force;//new Vector2(rigidbody.velocity.x, controller.bool_jump_force);
        controller.bool_jump = true;
        controller.animator.SetBool("jump", controller.bool_jump);
    }
    public void updateState(Controller2D controller)
    {
        
    }
    public void collisionState(Controller2D controller, Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("ellen collided ground");
            controller.bool_jump = false;
            controller.animator.SetBool("jump", controller.bool_jump);
            controller.switchState(controller.run);

        }
    }
}
