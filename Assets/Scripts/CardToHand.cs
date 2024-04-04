using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject HandCard;

    void Start()
    {
        Hand = GameObject.Find("HandP1");              //busca el panel Hand1
        HandCard.transform.SetParent(Hand.transform);  //Establece a Hand como el padre de HandCard
        HandCard.transform.localScale = Vector3.one;   //Ajusta la escala x,y,z a 1 es decir que preserve su tamano original
        HandCard.transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        HandCard.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
