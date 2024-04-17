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

    public string Power2;
    public Sprite SpriteImage2;

    public TMP_Text powerText2;
    public Image artImage2;

    public bool cardBack2;
    public static bool staticCardBack2;

    public int numCardInDeck2;
    public GameObject Hand2;

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
            Power2 = currentCard2.power.ToString();
            powerText2.text = " " + Power2;

            SpriteImage2 = currentCard2.spriteImage;
            artImage2.sprite = SpriteImage2;
        }
        else
        {
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
 
    
    }
    void Update()
    {
        if (GameManager.player2.turn)
        { cardBack2 = false; }
        else { cardBack2 = true; }

        staticCardBack2 = cardBack2;
    }
}