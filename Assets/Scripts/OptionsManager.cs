using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OpcionsManager : MonoBehaviour
{
    public GameObject Botton; 

    public void ChangeSceneWithDelay(string sceneName, float delay)
    {
        if (Botton.GetComponent<AudioSource>() != null)
        {
            Botton.GetComponent<AudioSource>().Play();
        }
        Invoke("BackToMenu", delay);
    }
    public void BackToMenu()
    {
        ChangeSceneWithDelay("BackToMenu", 1.0f);
        DontDestroyOnLoad(Botton);
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
