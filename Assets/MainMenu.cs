using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        int indexOfSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Loading level at id: " + indexOfSceneToLoad + "!");
        SceneManager.LoadScene(indexOfSceneToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
