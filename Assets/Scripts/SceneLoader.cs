using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Load(string scene)
    {
        Debug.Log("Switchign to Scene: " + scene);
        Enemy.enemyCount = 0;
        SceneManager.LoadScene(scene);
    }

    public void SourceCode()
    {
        Debug.Log("Viewing Github repositiory");
        Application.OpenURL("https://github.com/t73liu/zombie-invaders");
    }

    public void LoadNextLevel()
    {
        Debug.Log("Current Scene Index: " + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void enemyDestroyed()
    {
        if (Enemy.enemyCount <= 0)
        {
            LoadNextLevel();
        }
    }
}