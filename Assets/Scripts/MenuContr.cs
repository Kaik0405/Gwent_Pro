using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContr : MonoBehaviour
{
    public GameObject music;
    public void ChangeSceneWithDelay(string sceneName, float delay)
    {
        if (music.GetComponent<AudioSource>() != null)
        {
            music.GetComponent<AudioSource>().Play();
        }
        Invoke("TraslateToScene", delay);
    }

    public void TraslateToScene()
    {

        ChangeSceneWithDelay("TraslateToScene", 1.0f);
        DontDestroyOnLoad(music);
        SceneManager.LoadSceneAsync("GwentMain"); //Cambio de escena para la escena pricipal
    }
    public void ExitGame()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null) { audioSource.Play(); }

        Application.Quit();
    }

}
