using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContr : MonoBehaviour
{
    public void TraslateToScene()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null) { audioSource.Play(); }
        
        StartCoroutine(Lapse());
        SceneManager.LoadSceneAsync("GwentMain"); //Cambio de escena para la escena pricipal
    }
    public void ExitGame()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null) { audioSource.Play(); }
        
        StartCoroutine(Lapse());
        Application.Quit();
    }
    IEnumerator Lapse()
    {
        yield return new WaitForSeconds(5.0f);

    }
}