using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtom : MonoBehaviour
{
    public void JugarButtom()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitButtom()
    { 
        Application.Quit();
    }
}
