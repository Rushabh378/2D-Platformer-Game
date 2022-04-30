using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public Image[] KeyUI = new Image[3];
    Animator KeyAnime;
    int keyN = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            
            int size = KeyUI.Length;
            if(keyN < size)
            {
                getAnimetor();
                KeyAnime.SetBool("key_collected", true);
                Destroy(collision.gameObject);
                keyN++;
                //Debug.Log("keyn vlue : " + keyN);
            }
            
        }
    }
    void getAnimetor()
    {
        KeyAnime = KeyUI[keyN].GetComponent<Animator>();
        //Debug.Log("keyUI :"+ keyN);
    }
}
