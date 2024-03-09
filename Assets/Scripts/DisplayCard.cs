using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayID=0;

    public int power; 
    public TMP_Text powerText;

    void Start()
    {
        displayCard[0] = CardData.cardList[displayID];
    }


    void Update()
    {
        power = displayCard[0].power;   
        powerText.text = " " + power;
    }
}
