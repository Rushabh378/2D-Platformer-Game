using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthUI;
    Animator healthAnimator;

    private void Start()
    {
        healthAnimator = healthUI.GetComponent<Animator>();
    }
    public void healthDrop()
    {
        healthAnimator.SetBool("health", false);
    }
}
