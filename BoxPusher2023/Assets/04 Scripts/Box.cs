using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    public AudioSource goalSound;
    public GameObject clearText;
    public static int count;
    public int clearCount;

    private void Start()
    {
        count = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Goal"))
        {
            Debug.Log("목표지점에 도달");
            other.gameObject.SetActive(false);
            count++;
            Debug.Log(count);
            goalSound.Play();
            if (count == clearCount)
            {
                clearText.SetActive(true);
                PlayerPrefs.SetInt("Key", SceneManager.GetActiveScene().buildIndex);
                Invoke("ClearStage", 3.5f);
            }
        }
    }

    void ClearStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
