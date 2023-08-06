using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Key") + 1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
