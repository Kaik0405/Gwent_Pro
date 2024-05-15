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

    string power;
    public int realPower;    // maneja el poder real de la carta en el juego

    public Sprite SpriteImage;  // variable que recibe el sprite de la clase card
    public Image artImage;      // variable que hace referencia al componente imagen de la carta para asignarle el sprite 

    public TMP_Text powerText;     // variable que recibe el texto del poder para las cartas que no son de unidad
    public TMP_Text realPowerText; // variable que recibe el texto del poder para las cartas de unidad

    public bool cardBack;     // controla si se muestra o no la parte de atras de la carta  
    public static bool staticCardBack;

    public int numCardInDeck;
    public GameObject Hand;
    Color orig;
    public bool onField; // detecta si la carta esta en el campo o no

    void Start()
    {    
        Drag dragComponent = this.GetComponent<Drag>();
        orig = powerText.color;
        if (dragComponent != null && currentCard != null)
        {
            dragComponent.cardType = currentCard.pos_field;
            dragComponent.cardFact = currentCard.faction;
        }
        if ((currentCard.type == typecard.unit_gold) || (currentCard.type == typecard.unit_silver) || (currentCard.type == typecard.lure)) // si la carte M D A muestra el poder
        {
            power = currentCard.power.ToString();
            realPower = currentCard.power;

            powerText.text = " " + power;
            realPowerText.text = " " + realPower; 

            SpriteImage = currentCard.spriteImage;
            artImage.sprite = SpriteImage;
        }
        else  // muestra un texto para identificar si es Aumento Despeje Clima o Lider
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
        if ((currentCard.type == typecard.unit_silver) || (currentCard.type == typecard.lure)) // detecta si la carta es de unidad
        {
            powerText.text = " " + realPower;

            if(realPower > currentCard.power) // si el poder es mayor al original cambia el color de texto a verde
                powerText.color = Color.green;

            if (realPower < currentCard.power) // si el poder es menor al original cambia el color de texto a rojo
                powerText.color = Color.red;

            else if (realPower == currentCard.power) // si el poder es igual al original asignale su color original
                powerText.color = orig;
        }

        if (onField) // si la carta esta en el campo el cardback siempre sera false
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