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
    string realPower;

    public Sprite SpriteImage;
    public Image artImage;


    public TMP_Text powerText;
    public TMP_Text realPowerText;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TMP_Text typeText;
    public TMP_Text fieldText;
    public TMP_Text factionText;

    public bool cardBack;
    public static bool staticCardBack;

    public int numCardInDeck;
    public GameObject Hand;

    void Start()
    {
        numCardInDeck = playerDeck1.deckSize;

        Drag dragComponent = this.GetComponent<Drag>();
        if (dragComponent != null && currentCard != null)
        {
            dragComponent.cardType = currentCard.pos_field;
            dragComponent.cardFact = currentCard.faction;
        }
        if ((currentCard.type == typecard.unit_gold) || (currentCard.type == typecard.unit_silver) || (currentCard.type == typecard.lure))
        {
            nameC = currentCard.name;
            descriptionC = currentCard.description;
            typeC = currentCard.type.ToString();
            fieldC = currentCard.pos_field.ToString();
            factionC = currentCard.faction.ToString();
            power = currentCard.power.ToString();
            realPower = currentCard.power.ToString();

            powerText.text = " " + power;
            realPowerText.text = " " + realPower;
            nameText.text = " " + nameC;
            descriptionText.text = " " + descriptionC;
            typeText.text = " " + typeC;
            fieldText.text = " " + fieldC;
            factionText.text = " " + factionC;

            SpriteImage = currentCard.spriteImage;
            artImage.sprite = SpriteImage;
        }
        else
        {
            nameC = currentCard.name;
            descriptionC = currentCard.description;
            typeC = currentCard.type.ToString();
            fieldC = currentCard.pos_field.ToString();
            factionC = currentCard.faction.ToString();
            power = currentCard.power.ToString();
            realPower = currentCard.power.ToString();

            powerText.text = " " + power;
            realPowerText.text = " " + realPower;
            nameText.text = " " + nameC;
            descriptionText.text = " " + descriptionC;
            typeText.text = " " + typeC;
            fieldText.text = " " + fieldC;
            factionText.text = " " + factionC;

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
    }
    void Update()
    {
        Hand = GameObject.Find("HandP1");

        if (this.transform.parent == Hand.transform.parent)
        { cardBack = false; }

        staticCardBack = cardBack;

        //if (this.tag == "Clone")
        //{
        //    if (numCardInDeck > 0 && numCardInDeck <= playerDeck1.staticDeck.Count)
        //    {
        //        currentCard = playerDeck1.staticDeck[numCardInDeck - 1];
        //        numCardInDeck -= 1;
        //        playerDeck1.deckSize -= 1;
        //        cardBack = false;
        //        this.tag = "Untagged";
        //    }
        //}
    }
}