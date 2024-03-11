using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContr : MonoBehaviour
{
    public void TraslateToScene()
    {
        SceneManager.LoadScene("GwentMain"); //Cambio de escena para la escena pricipal
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}