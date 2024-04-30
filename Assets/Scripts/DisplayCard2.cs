using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Card;

public class DisplayCard2 : MonoBehaviour
{
    public Card currentCard2; // Referencia a la carta actual

    string nameC2;
    string descriptionC2;
    string typeC2;
    string fieldC2;
    string factionC2;
    string power2;
    string realPower2;

    public Sprite SpriteImage2;
    public Image artImage2;

    public TMP_Text powerText2;
    public TMP_Text realPowerText2;
    public TMP_Text nameText2;
    public TMP_Text descriptionText2;
    public TMP_Text typeText2;
    public TMP_Text fieldText2;
    public TMP_Text factionText2;

    public bool cardBack2 = false;
    public static bool staticCardBack2 = false;

    public int numCardInDeck2;
    public GameObject Hand2;

    public bool onField2;

    void Start()
    {
        Drag dragComponent = this.GetComponent<Drag>();
        if (dragComponent != null && currentCard2 != null)
        {
            dragComponent.cardType = currentCard2.pos_field;
            dragComponent.cardFact = currentCard2.faction;
        }
        if ((currentCard2.type == typecard.unit_gold) || (currentCard2.type == typecard.unit_silver)||(currentCard2.type == typecard.lure))
        {
            nameC2 = currentCard2.name;
            descriptionC2 = currentCard2.description;
            typeC2 = currentCard2.type.ToString();
            fieldC2 = currentCard2.pos_field.ToString();
            factionC2 = currentCard2.faction.ToString();
            power2 = currentCard2.power.ToString();
            realPower2 = currentCard2.power.ToString();

            powerText2.text = " " + power2;
            realPowerText2.text = " " + realPower2;
            nameText2.text = " " + nameC2;
            descriptionText2.text = " " + descriptionC2;
            typeText2.text = " " + typeC2;
            fieldText2.text = " " + fieldC2;
            factionText2.text = " " + factionC2;

            SpriteImage2 = currentCard2.spriteImage;
            artImage2.sprite = SpriteImage2;
        }
        else
        {
            nameC2 = currentCard2.name;
            descriptionC2 = currentCard2.description;
            typeC2 = currentCard2.type.ToString();
            fieldC2 = currentCard2.pos_field.ToString();
            factionC2 = currentCard2.faction.ToString();
            power2 = currentCard2.power.ToString();
            realPower2 = currentCard2.power.ToString();

            powerText2.text = " " + power2;
            realPowerText2.text = " " + realPower2;
            nameText2.text = " " + nameC2;
            descriptionText2.text = " " + descriptionC2;
            typeText2.text = " " + typeC2;
            fieldText2.text = " " + fieldC2;
            factionText2.text = " " + factionC2;

            switch (currentCard2.type)
            {
                case typecard.leader:
                    powerText2.text = " " + "L";

                    SpriteImage2 = currentCard2.spriteImage;
                    artImage2.sprite = SpriteImage2;
                    break;
                case typecard.climate:
                    powerText2.text = " " + "C";

                    SpriteImage2 = currentCard2.spriteImage;
                    artImage2.sprite = SpriteImage2;
                    break;
                case typecard.clear:
                    powerText2.text = " " + "D";

                    SpriteImage2 = currentCard2.spriteImage;
                    artImage2.sprite = SpriteImage2;
                    break;
                case typecard.increase:
                    powerText2.text = " " + "I";

                    SpriteImage2 = currentCard2.spriteImage;
                    artImage2.sprite = SpriteImage2;
                    break;
            }
        }
        onField2 = currentCard2.type == typecard.leader ? true : false;
    }
    void Update()
    {
        if (onField2)
        {
            cardBack2 = false;
            staticCardBack2 = cardBack2;
        }   
        else
        {
            if (GameManager.player2.turn)
            {
                cardBack2 = false;
                powerText2.enabled = true;
            }
            else 
            {
                cardBack2 = true;
                powerText2.enabled = false;
            }
            staticCardBack2 = cardBack2;
        }
    }
}