using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void NewGame()
    {
        SceneManager.LoadSceneAsync("Start", LoadSceneMode.Single);
    }
    public void Continue()
    {
        SceneManager.LoadSceneAsync("TEST", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LetsGo()
    {
        SceneManager.LoadScene("TEST");
    }
}
