using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    List<Card> cardList = new List<Card>();

    private void Awake()
    {
        //deck de Sombras
        //Cartas de Unidad
        //Cartas Oro
        cardList.Add(new Card(01, "Bellion", "descrip",10, Card.typecard.unit_gold, Card.typefield.MS, Card.typefaction.shadows, Resources.Load<Sprite>("MD")));
        cardList.Add(new Card(02, "Ingris", "descrip",10, Card.typecard.unit_gold, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("MDS")));
        cardList.Add(new Card(03, "The Codice", "descrip",10, Card.typecard.unit_gold, Card.typefield.MD, Card.typefaction.shadows, Resources.Load<Sprite>("MD1")));
        cardList.Add(new Card(04, "Kaisel", "descrip",10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.shadows, Resources.Load<Sprite>("MDS1")));
        cardList.Add(new Card(05, "Arcane", "descrip",10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        //Cartas Plata
        cardList.Add(new Card(06, "Kamish", "descrip",5, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.shadows, Resources.Load<Sprite>("D1(x2)")));
        cardList.Add(new Card(06, "Kamish", "descrip",5, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.shadows, Resources.Load<Sprite>("D1(x2)")));
        cardList.Add(new Card(07, "Bellion Low", "descrip",7, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.shadows, Resources.Load<Sprite>("D2(x2)")));
        cardList.Add(new Card(07, "Bellion Low", "descrip",7, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.shadows, Resources.Load<Sprite>("D2(x2)")));
        cardList.Add(new Card(08, "Beru", "descrip",8, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)")));
        cardList.Add(new Card(08, "Beru", "descrip",8, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)")));
        cardList.Add(new Card(08, "Beru", "descrip",8, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)")));
        cardList.Add(new Card(09, "Greed", "descrip",3, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)")));
        cardList.Add(new Card(09, "Greed", "descrip",3, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)")));
        cardList.Add(new Card(10, "Uleni", "descrip",4, Card.typecard.unit_silver, Card.typefield.siege, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)")));
        cardList.Add(new Card(10, "Uleni", "descrip",4, Card.typecard.unit_silver, Card.typefield.siege, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)")));
        cardList.Add(new Card(10, "Uleni", "descrip",4, Card.typecard.unit_silver, Card.typefield.siege, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)")));
        cardList.Add(new Card(11, "Tusk", "descrip",0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Lure(x2)")));
        cardList.Add(new Card(11, "Tusk", "descrip",0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Lure(x2)")));
        //Cartas
        cardList.Add(new Card(06, "Hell", "descrip", Card.typecard.climate, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        cardList.Add(new Card(06, "Fog of de dark", "descrip", Card.typecard.climate, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        cardList.Add(new Card(06, "Judgment Meteors", "descrip", Card.typecard.climate, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        cardList.Add(new Card(06, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        cardList.Add(new Card(06, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        cardList.Add(new Card(06, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        cardList.Add(new Card(06, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        cardList.Add(new Card(06, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        cardList.Add(new Card(06, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        cardList.Add(new Card(06, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));

    }
}
