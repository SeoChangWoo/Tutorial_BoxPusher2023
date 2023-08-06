using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float remainingTime;
    public Text remainingTimeUI;
    public GameObject timeOverText;

    void Update()
    {
        remainingTime = remainingTime - Time.deltaTime;
        remainingTimeUI.text = remainingTime.ToString("F0");
        if(remainingTime <= 0)
        {
            timeOverText.SetActive(true);
            remainingTimeUI.text = "0";
            Invoke("RestartScene", 3f);
        }
    }
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
