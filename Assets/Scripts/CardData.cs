using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public static List<Card> deckShadows = new List<Card>();
    public static List<Card> deckHeavenly = new List<Card>();
    void Awake()
    {
        //deck de Sombras
        //carta Lider
        deckShadows.Add(new Card(00, "Song Jing Woo", "deswcrip", Card.typecard.leader, Card.typefield.fleader, Card.typefaction.shadows, Resources.Load<Sprite>("Lidertype0")));
        //Cartas de Unidad
        //Cartas Oro

        deckShadows.Add(new Card(01, "Bellion", "descrip",10, Card.typecard.unit_gold, Card.typefield.MS, Card.typefaction.shadows, Resources.Load<Sprite>("MD")));
        deckShadows.Add(new Card(02, "Ingris", "descrip",10, Card.typecard.unit_gold, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("MDS")));
        deckShadows.Add(new Card(03, "The Codice", "descrip",10, Card.typecard.unit_gold, Card.typefield.MD, Card.typefaction.shadows, Resources.Load<Sprite>("MD1")));
        deckShadows.Add(new Card(04, "Kaisel", "descrip",10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.shadows, Resources.Load<Sprite>("MDS1")));
        deckShadows.Add(new Card(05, "Arcane", "descrip",10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1")));
        //Cartas Plata
        deckShadows.Add(new Card(06, "Kamish", "descrip",5, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.shadows, Resources.Load<Sprite>("D1(x2)")));
        deckShadows.Add(new Card(06, "Kamish", "descrip",5, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.shadows, Resources.Load<Sprite>("D1(x2)")));
        deckShadows.Add(new Card(07, "Bellion Low", "descrip",7, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.shadows, Resources.Load<Sprite>("D2(x2)")));
        deckShadows.Add(new Card(07, "Bellion Low", "descrip",7, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.shadows, Resources.Load<Sprite>("D2(x2)")));
        deckShadows.Add(new Card(08, "Beru", "descrip",8, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)")));
        deckShadows.Add(new Card(08, "Beru", "descrip",8, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)")));
        deckShadows.Add(new Card(08, "Beru", "descrip",8, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)")));
        deckShadows.Add(new Card(09, "Greed", "descrip",3, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)")));
        deckShadows.Add(new Card(09, "Greed", "descrip",3, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)")));
        deckShadows.Add(new Card(10, "Uleni", "descrip",4, Card.typecard.unit_silver, Card.typefield.siege, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)")));
        deckShadows.Add(new Card(10, "Uleni", "descrip",4, Card.typecard.unit_silver, Card.typefield.siege, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)")));
        deckShadows.Add(new Card(10, "Uleni", "descrip",4, Card.typecard.unit_silver, Card.typefield.siege, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)")));
        deckShadows.Add(new Card(11, "Tusk", "descrip",0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Lure(x2)")));
        deckShadows.Add(new Card(11, "Tusk", "descrip",0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Lure(x2)")));
        //Cartas
        deckShadows.Add(new Card(12, "Hell", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.none, Resources.Load<Sprite>("InfiernoMelee(S)")));
        deckShadows.Add(new Card(13, "Fog of de dark", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.none, Resources.Load<Sprite>("NieblaDist(S)")));
        deckShadows.Add(new Card(14, "Judgment Meteors", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.none, Resources.Load<Sprite>("LluviaMetSiege(S)")));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)")));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)")));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)")));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)")));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)")));
        deckShadows.Add(new Card(16, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.none, Resources.Load<Sprite>("Despeje(S)")));
        deckShadows.Add(new Card(16, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.none, Resources.Load<Sprite>("Despeje(S)")));

        //deck de Celestiales
        //carta Despeje(S)
        deckHeavenly.Add(new Card(01, "Aureliana", "descrip", 10, Card.typecard.unit_gold, Card.typefield.MS, Card.typefaction.heavenly, Resources.Load<Sprite>("Lider")));
        //Cartas de Unidad
        //Cartas Oro
        deckHeavenly.Add(new Card(01, "Raphaelius", "descrip", 10, Card.typecard.unit_gold, Card.typefield.MS, Card.typefaction.heavenly, Resources.Load<Sprite>("DS(P2)")));
        deckHeavenly.Add(new Card(02, "Zadkielus", "descrip", 10, Card.typecard.unit_gold, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("MD(P2)")));
        deckHeavenly.Add(new Card(03, "Gabrioth", "descrip", 10, Card.typecard.unit_gold, Card.typefield.MD, Card.typefaction.heavenly, Resources.Load<Sprite>("MD1(P2)")));
        deckHeavenly.Add(new Card(04, "Pyraethus", "descrip", 10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.heavenly, Resources.Load<Sprite>("MDS(P2)")));
        deckHeavenly.Add(new Card(05, "Aerovane", "descrip", 10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.heavenly, Resources.Load<Sprite>("MDS1(P2)")));
        //Cartas Plata
        deckHeavenly.Add(new Card(06, "Aetherion", "descrip", 5, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist(x2)P2")));
        deckHeavenly.Add(new Card(06, "Aetherion", "descrip", 5, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist(x2)P2")));
        deckHeavenly.Add(new Card(07, "Celestrox", "descrip", 7, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist2(x2)P2")));
        deckHeavenly.Add(new Card(07, "Celestrox", "descrip", 7, Card.typecard.unit_silver, Card.typefield.distance, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist2(x2)P2")));
        deckHeavenly.Add(new Card(08, "Nebulon", "descrip", 8, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee(x3)P2")));
        deckHeavenly.Add(new Card(08, "Nebulon", "descrip", 8, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee(x3)P2")));
        deckHeavenly.Add(new Card(08, "Nebulon", "descrip", 8, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee(x3)P2")));
        deckHeavenly.Add(new Card(09, "Divinara", "descrip", 3, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee2(x2)P2")));
        deckHeavenly.Add(new Card(09, "Divinara", "descrip", 3, Card.typecard.unit_silver, Card.typefield.melee, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee2(x2)P2")));
        deckHeavenly.Add(new Card(10, "Luminastra", "descrip", 4, Card.typecard.unit_silver, Card.typefield.siege, Card.typefaction.heavenly, Resources.Load<Sprite>("Siege(x3)P2")));
        deckHeavenly.Add(new Card(10, "Luminastra", "descrip", 4, Card.typecard.unit_silver, Card.typefield.siege, Card.typefaction.heavenly, Resources.Load<Sprite>("Siege(x3)P2")));
        deckHeavenly.Add(new Card(10, "Luminastra", "descrip", 4, Card.typecard.unit_silver, Card.typefield.siege, Card.typefaction.heavenly, Resources.Load<Sprite>("Siege(x3)P2")));
        deckHeavenly.Add(new Card(11, "Eternae", "descrip", 0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Lure(x2)P2")));
        deckHeavenly.Add(new Card(11, "Eternae", "descrip", 0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Lure(x2)P2")));
        //Cartas
        deckHeavenly.Add(new Card(12, "Hell", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.none, Resources.Load<Sprite>("infiernoMelee(S)")));
        deckHeavenly.Add(new Card(13, "Fog of de dark", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.none, Resources.Load<Sprite>("NieblaDist(S)")));
        deckHeavenly.Add(new Card(14, "Judgment Meteors", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.none, Resources.Load<Sprite>("LluviaMetSiege(S)")));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3")));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3")));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3")));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3")));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3")));
        deckHeavenly.Add(new Card(16, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.none, Resources.Load<Sprite>("Despeje(S)")));
        deckHeavenly.Add(new Card(16, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.none, Resources.Load<Sprite>("Despeje(S)")));

    }
}
