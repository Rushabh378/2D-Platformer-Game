using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public Image KeyUI;
    Animator KeyAnime;
    private void Start()
    {
        KeyAnime = KeyUI.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            KeyAnime.SetBool("key_collected", true);
            Destroy(collision.gameObject);
        }
    }
}
