using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Card;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayID;

    public int power;
    public Sprite spriteImage;

    public TMP_Text powerText;
    public Image artImage;

    void Start()
    {
        displayCard[0] = CardData.deckShadows[displayID];

         
        power = displayCard[0].power;
        powerText.text = " " + power;
        spriteImage = displayCard[0].spriteImage;

        artImage.sprite = spriteImage;

    }


    void Update()
    {
      
    }
}
