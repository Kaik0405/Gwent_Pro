using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Card;

public class DisplayCard : MonoBehaviour
{
    public Card currentCard; // Referencia a la carta actual

    public string Power;
    public Sprite SpriteImage;

    public TMP_Text powerText;
    public Image artImage;

    public bool cardBack;
    public static bool staticCardBack;

    public int numCardInDeck;
    public GameObject Hand;

    void Start()
    {
        numCardInDeck = playerDeck1.deckSize;

        Power = currentCard.power.ToString();
        powerText.text = " " + Power;
        SpriteImage = currentCard.spriteImage;

        artImage.sprite = SpriteImage;
    }

    void Update()
    {
        Hand = GameObject.Find("HandP1");

        if (this.transform.parent == Hand.transform.parent)
        { cardBack = false; }

        staticCardBack = cardBack;

        if (this.tag == "Clone")
        {
            if (numCardInDeck > 0 && numCardInDeck <= playerDeck1.staticDeck.Count)
            {
                currentCard = playerDeck1.staticDeck[numCardInDeck - 1];
                numCardInDeck -= 1;
                playerDeck1.deckSize -= 1;
                cardBack = false;
                this.tag = "Untagged";
            }
        }
    }
}
