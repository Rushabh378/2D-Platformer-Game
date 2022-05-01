using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] healthUI = new Image[3];
    Animator healthAnimator;
    int N = 0;
    public bool healthDrop()
    {
        if (N < 3)
        {
            //setting healthAnimtor
            healthAnimator = healthUI[N].GetComponent<Animator>();
            healthAnimator.SetBool("health", false); N++; //destoryed healthpoint and shifting focus to next heathpoint.

            return false;
        }
        else
            return true;
    }
}
