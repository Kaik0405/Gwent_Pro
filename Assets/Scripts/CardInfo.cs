using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardInfo : MonoBehaviour
{
    public GameObject cardObj;
    public Sprite spriteCard;
    public Image imageCard;

    public TMP_Text nameT;
    public TMP_Text descriptionT;
    public TMP_Text typeT;
    public TMP_Text fieldT;
    public TMP_Text factionT;
    public TMP_Text powerT;

    void OnMouseOver()
    {
        if (gameObject.CompareTag("CardToHand(Clone)"))
            {
            Debug.Log("CartaPasadaXencima");
            cardObj = gameObject;
            DisplayCard cardInfo = cardObj.GetComponent<DisplayCard>();

            if (cardInfo != null)
            {
                nameT.text = " " + cardInfo.powerText;
                descriptionT.text = " " + cardInfo.descriptionText;
                typeT.text = " " + cardInfo.typeText;
                fieldT.text = " " + cardInfo.fieldText;
                factionT.text = " " + cardInfo.factionText;
                powerT.text = " " + cardInfo.realPowerText;
            }
        }
    }
}
