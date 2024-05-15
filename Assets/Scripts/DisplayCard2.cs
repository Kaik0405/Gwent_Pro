using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Card;

public class DisplayCard2 : MonoBehaviour
{
    // Este scrip es el espejo de DisplayCard
    public Card currentCard2; 

    string power2;
    public int realPower2;

    public Sprite SpriteImage2;
    public Image artImage2;

    public TMP_Text powerText2;
    public TMP_Text realPowerText2;

    public bool cardBack2 = false;
    public static bool staticCardBack2 = false;

    public int numCardInDeck2;
    public GameObject Hand2;
    Color orig;
    public bool onField2;

    void Start()
    {
        Drag dragComponent = this.GetComponent<Drag>();
        orig = powerText2.color;
        if (dragComponent != null && currentCard2 != null)
        {
            dragComponent.cardType = currentCard2.pos_field;
            dragComponent.cardFact = currentCard2.faction;
        }
        if ((currentCard2.type == typecard.unit_gold) || (currentCard2.type == typecard.unit_silver)||(currentCard2.type == typecard.lure))
        {
            power2 = currentCard2.power.ToString();
            realPower2 = currentCard2.power;

            powerText2.text = " " + power2;
            realPowerText2.text = " " + realPower2;
            
            SpriteImage2 = currentCard2.spriteImage;
            artImage2.sprite = SpriteImage2;
        }
        else
        {
            power2 = currentCard2.power.ToString();
            realPower2 = currentCard2.power;

            powerText2.text = " " + power2;
            realPowerText2.text = " " + realPower2;
            
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
        if ((currentCard2.type == typecard.unit_silver) || (currentCard2.type == typecard.lure))
        { 
            powerText2.text = " " + realPower2;

            if (realPower2 > currentCard2.power)
                powerText2.color = Color.green;
            
            if (realPower2 < currentCard2.power)
                powerText2.color = Color.red;
            
            else if(realPower2 == currentCard2.power)
                powerText2.color = orig;
        }

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