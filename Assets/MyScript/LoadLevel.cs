using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Button[] buttons = new Button[3];
  
    private void Start()
    {
        buttons[0].onClick.AddListener(() => loadLevel(1));
        buttons[1].onClick.AddListener(() => loadLevel(2));
        buttons[2].onClick.AddListener(() => loadLevel(3));
    }
    void loadLevel(int level)
    {
        SceneManager.LoadScene(level);
        //Debug.Log(level + " level activated");
    }
}