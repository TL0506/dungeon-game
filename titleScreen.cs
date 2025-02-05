using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class titleScreen : MonoBehaviour
{
   public void OnPlayButton()
    {
        SceneManager.LoadScene("mainGame");
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
