using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContr : MonoBehaviour
{
    public void ChangeSceneWithDelay(string sceneName, float delay)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        Invoke("TraslateToScene", delay);
    }

    public void TraslateToScene()
    {

        ChangeSceneWithDelay("TraslateToScene", 3);

        SceneManager.LoadSceneAsync("GwentMain"); //Cambio de escena para la escena pricipal
    }
    public void ExitGame()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null) { audioSource.Play(); }

        Application.Quit();
    }

}
