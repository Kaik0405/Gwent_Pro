using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PowerInfo : MonoBehaviour // Scrip para mostrar en tiempo real el poder acumulado en el campo de ambos jugadores
{
    public TMP_Text powerP1;
    public TMP_Text powerP2;
    void Update()
    {
        if (powerP1 != null)
            powerP1.text = GameManager.player1.PowerFull().ToString();
        
        if (powerP2 != null)
            powerP2.text = GameManager.player2.PowerFull().ToString();
    }
}
