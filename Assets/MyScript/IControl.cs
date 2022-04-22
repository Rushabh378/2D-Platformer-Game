using UnityEngine;

public interface IControl 
{
    void enterState(Controller2D controller);
    void updateState(Controller2D controller);
    void collisionState(Controller2D controller, Collision2D collision);
}
