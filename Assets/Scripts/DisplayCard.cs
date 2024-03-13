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

    public bool cardBack;
    public static bool staticCardBack;

    public int numCardInDeck;
    public GameObject Hand;
    void Start()
    {
        numCardInDeck = playerDeck1.deckSize;

        displayCard[0] = CardData.deckShadows[displayID];

        power = displayCard[0].power;
        powerText.text = " " + power;
        spriteImage = displayCard[0].spriteImage;

        artImage.sprite = spriteImage;
    }


    void Update()
    {
   
        Hand = GameObject.Find("HandP1");

        if(this.transform.parent == Hand.transform.parent)
        { cardBack = false; }

        staticCardBack = cardBack;

        if(this.tag == "Clone")
        {
            displayCard[0] = playerDeck1.staticDeck[numCardInDeck-1];
            numCardInDeck -= 1;
            playerDeck1.deckSize -=1;
            cardBack = false;
            this.tag = "Untagged";
        }
    }
}
