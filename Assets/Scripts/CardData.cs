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
        deckShadows.Add(new Card(00, "Sung Jing Woo", "deswcrip", Card.typecard.leader, Card.typefield.fleader, Card.typefaction.shadows, Resources.Load<Sprite>("Lidertype0"),Effect.LeaderEffect1));
        //Cartas de Unidad
        //Cartas Oro
        deckShadows.Add(new Card(01, "Bellion", "descrip",10, Card.typecard.unit_gold, Card.typefield.MS, Card.typefaction.shadows, Resources.Load<Sprite>("MD"),Effect.DestroyCardWeak));
        deckShadows.Add(new Card(02, "Ingris", "descrip",10, Card.typecard.unit_gold, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("MDS"),Effect.DrawCard));
        deckShadows.Add(new Card(03, "The Codice", "descrip",10, Card.typecard.unit_gold, Card.typefield.MD, Card.typefaction.shadows, Resources.Load<Sprite>("MD1"),Effect.ClearRowLess));
        deckShadows.Add(new Card(04, "Kaisel", "descrip",10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.shadows, Resources.Load<Sprite>("MDS1"),Effect.DestroyCardStrong));
        deckShadows.Add(new Card(05, "Arcane", "descrip",10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1"),Effect.DrawCard));
        //Cartas Plata
        deckShadows.Add(new Card(06, "Kamish", "descrip",5, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.shadows, Resources.Load<Sprite>("D1(x2)"),Effect.ActivateClimate));
        deckShadows.Add(new Card(06, "Kamish", "descrip",5, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.shadows, Resources.Load<Sprite>("D1(x2)"),Effect.ActivateClimate));
        deckShadows.Add(new Card(07, "Bellion Low", "descrip",7, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.shadows, Resources.Load<Sprite>("D2(x2)"),Effect.ActivateIncrese));
        deckShadows.Add(new Card(07, "Bellion Low", "descrip",7, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.shadows, Resources.Load<Sprite>("D2(x2)"),Effect.ActivateIncrese));
        deckShadows.Add(new Card(08, "Beru", "descrip",8, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)"),Effect.IncreseRouw));
        deckShadows.Add(new Card(08, "Beru", "descrip",8, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)"),Effect.IncreseRouw));
        deckShadows.Add(new Card(09, "Greed", "descrip",3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)"),Effect.MultiplicatePower));
        deckShadows.Add(new Card(09, "Greed", "descrip",3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)"),Effect.MultiplicatePower));
        deckShadows.Add(new Card(09, "Greed", "descrip",3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)"),Effect.MultiplicatePower));
        deckShadows.Add(new Card(10, "Uleni", "descrip",4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)"),Effect.Average));
        deckShadows.Add(new Card(10, "Uleni", "descrip",4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)"),Effect.Average));
        deckShadows.Add(new Card(10, "Uleni", "descrip",4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)"),Effect.Average));
        deckShadows.Add(new Card(11, "Tusk", "descrip",0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Lure(x2)"),Effect.LureEffect));
        deckShadows.Add(new Card(11, "Tusk", "descrip",0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Lure(x2)"),Effect.LureEffect));
        //Cartas
        deckShadows.Add(new Card(12, "Hell", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.shadows, Resources.Load<Sprite>("InfiernoMelee(S)"),Effect.Climate));
        deckShadows.Add(new Card(13, "Fog of de dark", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.shadows, Resources.Load<Sprite>("NieblaDist(S)"),Effect.Climate));
        deckShadows.Add(new Card(14, "Judgment Meteors", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.shadows, Resources.Load<Sprite>("LluviaMetSiege(S)"),Effect.Climate));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(15, "The Power of Iron", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(16, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Despeje(S)"),Effect.Clearance));
        deckShadows.Add(new Card(16, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Despeje(S)"),Effect.Clearance));
        //deck de Celestiales
        //carta Lider
        deckHeavenly.Add(new Card(00, "Aureliana", "descrip", Card.typecard.leader, Card.typefield.fleader, Card.typefaction.heavenly, Resources.Load<Sprite>("Lider"),Effect.LeaderEffect2));
        //Cartas de Unidad
        //Cartas Oro
        deckHeavenly.Add(new Card(01, "Raphaelius", "descrip", 10, Card.typecard.unit_gold, Card.typefield.MS, Card.typefaction.heavenly, Resources.Load<Sprite>("DS(P2)"),Effect.DestroyCardWeak));
        deckHeavenly.Add(new Card(02, "Zadkielus", "descrip", 10, Card.typecard.unit_gold, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("MD(P2)"),Effect.DrawCard));
        deckHeavenly.Add(new Card(03, "Gabrioth", "descrip", 10, Card.typecard.unit_gold, Card.typefield.MD, Card.typefaction.heavenly, Resources.Load<Sprite>("MD1(P2)"),Effect.ClearRowLess));
        deckHeavenly.Add(new Card(04, "Pyraethus", "descrip", 10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.heavenly, Resources.Load<Sprite>("MDS(P2)"),Effect.DestroyCardStrong));
        deckHeavenly.Add(new Card(05, "Aerovane", "descrip", 10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.heavenly, Resources.Load<Sprite>("MDS1(P2)"),Effect.DrawCard));
        //Cartas Plata
        deckHeavenly.Add(new Card(06, "Aetherion", "descrip", 5, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist(x2)P2"),Effect.ActivateClimate));
        deckHeavenly.Add(new Card(06, "Aetherion", "descrip", 5, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist(x2)P2"),Effect.ActivateClimate));
        deckHeavenly.Add(new Card(07, "Celestrox", "descrip", 7, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist2(x2)P2"),Effect.ActivateIncrese));
        deckHeavenly.Add(new Card(07, "Celestrox", "descrip", 7, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist2(x2)P2"),Effect.ActivateIncrese));
        deckHeavenly.Add(new Card(08, "Nebulon", "descrip", 8, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee(x3)P2"),Effect.IncreseRouw));
        deckHeavenly.Add(new Card(08, "Nebulon", "descrip", 8, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee(x3)P2"),Effect.IncreseRouw));
        deckHeavenly.Add(new Card(09, "Divinara", "descrip", 3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee2(x2)P2"),Effect.MultiplicatePower));
        deckHeavenly.Add(new Card(09, "Divinara", "descrip", 3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee2(x2)P2"),Effect.MultiplicatePower));
        deckHeavenly.Add(new Card(09, "Divinara", "descrip", 3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee2(x2)P2"),Effect.MultiplicatePower));
        deckHeavenly.Add(new Card(10, "Luminastra", "descrip", 4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.heavenly, Resources.Load<Sprite>("Siege(x3)P2"),Effect.Average));
        deckHeavenly.Add(new Card(10, "Luminastra", "descrip", 4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.heavenly, Resources.Load<Sprite>("Siege(x3)P2"),Effect.Average));
        deckHeavenly.Add(new Card(10, "Luminastra", "descrip", 4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.heavenly, Resources.Load<Sprite>("Siege(x3)P2"),Effect.Average));
        deckHeavenly.Add(new Card(11, "Eternae", "descrip", 0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Lure(x2)P2"),Effect.LureEffect));
        deckHeavenly.Add(new Card(11, "Eternae", "descrip", 0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Lure(x2)P2"),Effect.LureEffect));
        //Cartas
        deckHeavenly.Add(new Card(12, "Hell", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.heavenly, Resources.Load<Sprite>("infiernoMelee(S)"),Effect.Climate));
        deckHeavenly.Add(new Card(13, "Fog of de dark", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.heavenly, Resources.Load<Sprite>("NieblaDist(S)"),Effect.Climate));
        deckHeavenly.Add(new Card(14, "Judgment Meteors", "descrip", Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.heavenly, Resources.Load<Sprite>("LluviaMetSiege(S)"),Effect.Climate));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", "descrip", Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(16, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Despeje(S)"),Effect.Clearance));
        deckHeavenly.Add(new Card(16, "The Dawn After the Sunset", "descrip", Card.typecard.clear, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Despeje(S)"),Effect.Clearance));
    }
}
