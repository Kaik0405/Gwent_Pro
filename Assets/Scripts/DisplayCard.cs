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

    string nameC;
    string descriptionC;
    string typeC;
    string fieldC;
    string factionC;
    string power;
    public int realPower;

    public Sprite SpriteImage;
    public Image artImage;

    public TMP_Text powerText;
    public TMP_Text realPowerText;

    public bool cardBack;
    public static bool staticCardBack;

    public int numCardInDeck;
    public GameObject Hand;

    public bool onField;

    void Start()
    {    
        Drag dragComponent = this.GetComponent<Drag>();
        if (dragComponent != null && currentCard != null)
        {
            dragComponent.cardType = currentCard.pos_field;
            dragComponent.cardFact = currentCard.faction;
        }
        if ((currentCard.type == typecard.unit_gold) || (currentCard.type == typecard.unit_silver) || (currentCard.type == typecard.lure))
        {
            power = currentCard.power.ToString();
            realPower = currentCard.power;

            powerText.text = " " + power;
            realPowerText.text = " " + realPower; 

            SpriteImage = currentCard.spriteImage;
            artImage.sprite = SpriteImage;
        }
        else
        {
            power = currentCard.power.ToString();
            realPower = currentCard.power;

            powerText.text = " " + power;
            realPowerText.text = " " + realPower;
            
            switch (currentCard.type)
            {
                case typecard.leader:
                    powerText.text = " " + "L";

                    SpriteImage = currentCard.spriteImage;
                    artImage.sprite = SpriteImage;
                    break;
                case typecard.climate:
                    powerText.text = " " + "C";

                    SpriteImage = currentCard.spriteImage;
                    artImage.sprite = SpriteImage;
                    break;
                case typecard.clear:
                    powerText.text = " " + "D";

                    SpriteImage = currentCard.spriteImage;
                    artImage.sprite = SpriteImage;
                    break;
                case typecard.increase:
                    powerText.text = " " + "I";

                    SpriteImage = currentCard.spriteImage;
                    artImage.sprite = SpriteImage;
                    break;
            }
        }
        onField = currentCard.type == typecard.leader ? true : false;
    }
    void Update()
    {
        if ((currentCard.type == typecard.unit_silver) || (currentCard.type == typecard.lure))
        {
            powerText.text = " " + realPower;
            if(realPower > currentCard.power)
            {
                powerText.color = Color.green;
            }
            if (realPower < currentCard.power)
            {
                powerText.color = Color.red;
            }
        }

        if (onField)
        {
            cardBack = false;
            staticCardBack = cardBack;
        }
        else
        {
            if (GameManager.player1.turn)
            {
                cardBack = false;
                powerText.enabled = true;
            }
            else
            {
                cardBack = true;
                powerText.enabled = false;
            }
            staticCardBack = cardBack;
        }
    }
}