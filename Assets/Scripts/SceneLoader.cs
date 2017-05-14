using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Load(string scene)
    {
        Debug.Log("Switchign to Scene: " + scene);
        SceneManager.LoadScene(scene);
    }

    public void SourceCode()
    {
        Debug.Log("Viewing Github repositiory");
        Application.OpenURL("https://github.com/t73liu/zombie-invaders");
    }
}