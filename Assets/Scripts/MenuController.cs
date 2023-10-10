using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
public void PlayGame()
    {
        SceneManager.LoadScene("ApricotStart");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
