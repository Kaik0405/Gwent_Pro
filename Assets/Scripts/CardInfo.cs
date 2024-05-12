using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardInfo : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler // scrip para la actualizacion del panel de al lado para mostrar la carta en grande con info
{
    GameObject cardInfo; 
    public GameObject card;
    
    void Start()
    {
        cardInfo = GameObject.Find("CardInfo");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UpdateCardInfo();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       
    }
    public void UpdateCardInfo()
    {
        Image imageCard = cardInfo.GetComponent<Image>();
        Sprite spriteCard = null;
        
        if (card.GetComponent<DisplayCard>() != null)
        {
            if (!card.GetComponent<DisplayCard>().cardBack)
            {
                cardInfo.transform.Find("powerCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard>().currentCard.power.ToString();
                cardInfo.transform.Find("nameCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard>().currentCard.name;
                cardInfo.transform.Find("descriptionCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard>().currentCard.description;
                cardInfo.transform.Find("typeCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard>().currentCard.type.ToString();
                cardInfo.transform.Find("fieldCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard>().currentCard.pos_field.ToString();
                cardInfo.transform.Find("factionCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard>().currentCard.faction.ToString();
                
                spriteCard = card.GetComponent<DisplayCard>().currentCard.spriteImage;
                imageCard.sprite = spriteCard;
            }
        }
        else if (card.GetComponent<DisplayCard2>() != null)
        {
            if (!card.GetComponent<DisplayCard2>().cardBack2)
            {
                cardInfo.transform.Find("powerCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard2>().currentCard2.power.ToString();
                cardInfo.transform.Find("nameCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard2>().currentCard2.name;
                cardInfo.transform.Find("descriptionCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard2>().currentCard2.description;
                cardInfo.transform.Find("typeCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard2>().currentCard2.type.ToString();
                cardInfo.transform.Find("fieldCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard2>().currentCard2.pos_field.ToString();
                cardInfo.transform.Find("factionCard").GetComponent<TMP_Text>().text = card.GetComponent<DisplayCard2>().currentCard2.faction.ToString();
                
                spriteCard = card.GetComponent<DisplayCard2>().currentCard2.spriteImage;
                imageCard.sprite = spriteCard;
            }
        }
    }
}
