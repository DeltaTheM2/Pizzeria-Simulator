using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void NewGame()
    {
        SceneManager.LoadScene("TEST");
    }
    public void Continue()
    {
        SceneManager.LoadScene("TEST");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
