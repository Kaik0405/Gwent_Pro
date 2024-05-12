using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Effect
{
    public static void Increse(params object[] paramtry)           // Aumenta el poder de ataque de una fila en el campo del jugador por 5 pts
    {
        string[] positions = { "IncreseM1", "IncreseD1", "IncreseS1", "IncreseM2", "IncreseD2", "IncreseS2" };
        string[] zones = { "MeleeP1", "DistanceP1", "SiegeP1", "MeleeP2", "DistanceP2", "SiegeP2" };

        if (paramtry[0] is GameObject card)
        {
            for (int i = 0; i < 6; i++)
            {
                if (GameObject.Find(positions[i]).GetComponent<ControlPanels>().cardInPanel.Contains(card))
                {
                    foreach (GameObject item in GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if ((item.GetComponent<DisplayCard>() != null) && ((item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)))
                            item.GetComponent<DisplayCard>().realPower += 5;
                        
                        else if ((item.GetComponent<DisplayCard2>() != null) && ((item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)))
                            item.GetComponent<DisplayCard2>().realPower2 += 5;
                    }
                }
            }
        }
    }
    public static void DestroyCardStrong(params object[] paramtry) // Destruye la carta mas fuerte en el campo
    {
        string[] cardZonesP1 = { "MeleeP1", "DistanceP1", "SiegeP1" };
        string[] cardZonesP2 = { "MeleeP2", "DistanceP2", "SiegeP2" };

        if ((paramtry[0] is Player player) && (paramtry[1] is Player opponet))
        {
            int powerMax1 = 0;
            int powerMax2 = 0;
            for (int i = 0;i < 3; i++)
            {
                foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                {
                    if(item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                    {
                        if (item.GetComponent<DisplayCard>().realPower > powerMax1)
                            powerMax1 = item.GetComponent<DisplayCard>().realPower; 
                    }
                }
                foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                {
                    if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                    {
                        if (item.GetComponent<DisplayCard2>().realPower2 > powerMax2)
                            powerMax2 = item.GetComponent<DisplayCard2>().realPower2;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (powerMax1 > powerMax2)
                {
                    for (int j = 0; j < GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
                    {
                        GameObject item = GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel[j];
                        if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                        {
                            if (item.GetComponent<DisplayCard>().realPower == powerMax1)
                            {
                                GameManager.player1.graveyard.Add(item);
                                GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Remove(item);
                                item.transform.SetParent(GameObject.Find("GraveyardP1").transform);
                                item.SetActive(false);
                                break;
                            }
                        }
                    }
                }
                if (powerMax2 > powerMax1)
                {
                    for (int j = 0; j < GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
                    {
                        GameObject item = GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel[j];

                        if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                        {
                            if (item.GetComponent<DisplayCard2>().realPower2 == powerMax2)
                            {
                                GameManager.player2.graveyard.Add(item);
                                GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Remove(item);
                                item.transform.SetParent(GameObject.Find("GraveyardP2").transform);
                                item.SetActive(false);
                                break;
                            }
                        }
                    }
                }
                if (powerMax1 == powerMax2)
                {
                    if (GameManager.player1.turn)
                    {
                        for (int j = 0; j < GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
                        {
                            GameObject item = GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel[j];
                            if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                            {
                                if (item.GetComponent<DisplayCard2>().realPower2 == powerMax2)
                                {
                                    GameManager.player2.graveyard.Add(item);
                                    GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Remove(item);
                                    item.transform.SetParent(GameObject.Find("GraveyardP2").transform);
                                    item.SetActive(false);
                                    break;
                                }
                            }
                        }
                    }
                    if (GameManager.player2.turn)
                    {
                        for (int j = 0; j < GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
                        {
                            GameObject item = GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel[j];
                            if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                            {
                                if (item.GetComponent<DisplayCard>().realPower == powerMax1)
                                {
                                    GameManager.player1.graveyard.Add(item);
                                    GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Remove(item);
                                    item.transform.SetParent(GameObject.Find("GraveyardP1").transform);
                                    item.SetActive(false);
                                    break;

                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public static void DestroyCardWeak(params object[] paramtry)   // Destrye la carta mas debil del adversario
    {
        if ((paramtry[0] is GameObject card) && (paramtry[1] is Player opponet))
        {
            bool bin = false;
            int min = int.MaxValue;
            string[] cardZonesP1 = { "MeleeP1", "DistanceP1", "SiegeP1" };
            string[] cardZonesP2 = { "MeleeP2", "DistanceP2", "SiegeP2" };

            if (card.GetComponent<DisplayCard>() != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if ((item.GetComponent<DisplayCard2>().realPower2 < min)&&(item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)) 
                            min = item.GetComponent<DisplayCard2>().realPower2;
                    }
                }
                for(int i = 0;i < 3; i++)
                {
                    for (int j = 0; j < GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Count;j++)
                    {
                        GameObject item = GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel[j];
                        if (item.GetComponent<DisplayCard2>().realPower2 == min)
                        {
                            opponet.graveyard.Add(item);
                            GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Remove(item);
                            item.transform.SetParent(GameObject.Find("GraveyardP2").transform);
                            item.SetActive(false);
                            bin = true;
                            break;
                        }
                    }
                    if (bin) break;
                }
            }
            if(card.GetComponent<DisplayCard2>() != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if ((item.GetComponent<DisplayCard>().realPower < min)&&(item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)) 
                            min = item.GetComponent<DisplayCard>().realPower;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0;j < GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Count;j++)
                    {
                        GameObject item = GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel[j];
                        if (item.GetComponent<DisplayCard>().realPower == min)
                        {
                            opponet.graveyard.Add(item);
                            GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Remove(item);
                            item.transform.SetParent(GameObject.Find("GraveyardP1").transform);
                            item.SetActive(false);
                            bin = true;
                            break;
                        }
                    }
                    if (bin) break;
                }
            }
            
        }
    }
    public static void Climate(params object[] paramtry)           // disminuye el poder de las cartas de unidad a 1 de la misma fila de ambos jugadores
    {
        if (paramtry[0] is GameObject card)
        {
            string[] nameClimate = { "Hell", "Fog of de dark", "Judgment Meteors" };
            string[] cardZonesP1 = { "MeleeP1", "DistanceP1", "SiegeP1" };
            string[] cardZonesP2 = { "MeleeP2", "DistanceP2", "SiegeP2" };

            if (card.GetComponent<DisplayCard>() != null)
            {
                for(int i = 0; i < 3; i++)
                {
                    if (card.GetComponent<DisplayCard>().currentCard.name == nameClimate[i])
                    {
                        foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                            if(item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                                item.GetComponent<DisplayCard>().realPower = 1;

                        foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                            if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                item.GetComponent<DisplayCard2>().realPower2 = 1;
                    }
                }
            }
            if (card.GetComponent<DisplayCard2>() != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (card.GetComponent<DisplayCard2>().currentCard2.name == nameClimate[i])
                    {
                        foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                            if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                                item.GetComponent<DisplayCard>().realPower = 1;

                        foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                            if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                item.GetComponent<DisplayCard2>().realPower2 = 1;
                    }
                }
            }
        }
    }
    public static void ClearRowLess(params object[] paramtry)      // Limpia la fila con menos unidades******
    {
        if ((paramtry[0] is Player player1) && (paramtry[1] is Player player2) && (paramtry[2] is GameObject card))
        {
            Debug.Log("Efecto lLamado!!!!!!!!!!!");

            string[] cardZonesP1 = { "MeleeP1", "DistanceP1", "SiegeP1" };
            string[] cardZonesP2 = { "MeleeP2", "DistanceP2", "SiegeP2" };

            int MinP1 = int.MaxValue;
            int MinP2 = int.MaxValue;
            
            for (int i = 0; i < 3; i++)
                if ((GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Count < MinP1)&&(GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Count > 1))
                    MinP1 = GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Count;

            for (int i = 0; i < 3; i++)
                if ((GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Count < MinP2)&&(GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Count > 1))
                    MinP2 = GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Count;

            Debug.Log("menor cantidad de unidades Jugador1: " + MinP1);
            Debug.Log("menor cantidad de unidades Jugador2: " + MinP2);

            if (MinP1 < MinP2)
            {
                Debug.Log("Jugador1 destroyyyyyyyy");
                for (int i = 0; i < 3; i++)
                {
                    if (GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Count == MinP1)
                    {
                        for(int j = 0; j < GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
                        {
                            GameObject item = GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel[j];
                            if(item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold) 
                            {
                                player1.graveyard.Add(item);
                                item.transform.SetParent(GameObject.Find("GraveyardP1").transform);
                                item.SetActive(false);
                            }
                        }
                        break;
                    }
                }
            }
            else if(MinP2 < MinP1)
            {
                Debug.Log("Jugador2 destroyyyyyyyy");
                for (int i = 0; i < 3; i++)
                {
                    if (GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Count == MinP1)
                    {
                        for (int j = 0; j < GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
                        {
                            GameObject item = GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel[j];
                            if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                            {
                                player2.graveyard.Add(item);
                                item.transform.SetParent(GameObject.Find("GraveyardP2").transform);
                                item.SetActive(false);
                            }
                        }
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("Algo pasa");
            }
        }
    }
    public static void DrawCard(params object[] paramtry)          // Robar una carta
    {
        if (paramtry[0] is Player player) player.Draw();
    }
    public static void ActivateIncrese(params object[] paramtry)   // Activa una carta de aumento que fortalece la zona donde es jugada
    {
        if (paramtry[0] is GameObject card)
        {
            if(card.GetComponent<DisplayCard>() != null)
            {
                for (int i = 0; i < GameManager.player1.handZone.Count; i++)
                {
                    GameObject item = GameManager.player1.handZone[i];
                    if(item.GetComponent<DisplayCard>().currentCard.type == Card.typecard.increase && GameObject.Find("IncreseD1").GetComponent<ControlPanels>().cardInPanel.Count < 1)
                    {
                        item.transform.SetParent(GameObject.Find("IncreseD1").transform);
                        GameObject.Find("IncreseD1").GetComponent<ControlPanels>().AddCardToPanelHand(item);
                        item.GetComponent<DisplayCard>().onField = true;

                        for(int j = 0;j < GameObject.Find("DistanceP1").GetComponent<ControlPanels>().cardInPanel.Count; j++)
                        {
                            GameObject cards = GameObject.Find("DistanceP1").GetComponent<ControlPanels>().cardInPanel[j];
                            if (cards.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                                cards.GetComponent<DisplayCard>().realPower += 5;
                        }
                        break;
                    }
                }
            }
            else if(card.GetComponent<DisplayCard2>() != null)
            {
                for (int i = 0; i < GameManager.player2.handZone.Count; i++)
                {
                    GameObject item = GameManager.player2.handZone[i];
                    if (item.GetComponent<DisplayCard2>().currentCard2.type == Card.typecard.increase && GameObject.Find("IncreseD1").GetComponent<ControlPanels>().cardInPanel.Count < 1)
                    {
                        item.transform.SetParent(GameObject.Find("IncreseD2").transform);
                        GameObject.Find("IncreseD2").GetComponent<ControlPanels>().AddCardToPanelHand(item);
                        item.GetComponent<DisplayCard2>().onField2 = true;

                        for (int j = 0; j < GameObject.Find("DistanceP2").GetComponent<ControlPanels>().cardInPanel.Count; j++)
                        {
                            GameObject cards = GameObject.Find("DistanceP2").GetComponent<ControlPanels>().cardInPanel[j];
                            if (cards.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                cards.GetComponent<DisplayCard2>().realPower2 += 5;
                        }
                        break;
                    }
                }
            }
        }
    }
    public static void ActivateClimate(params object[] paramtry)   // Activa una carta clima para que afecte la zona con mayor fuerza de atak del adversario 
    {
        if(paramtry[0] is GameObject card)
        {
            string[] nameClimate = { "Hell", "Fog of de dark", "Judgment Meteors" };
            string[] cardZonesP1 = { "MeleeP1", "DistanceP1", "SiegeP1" };
            string[] cardZonesP2 = { "MeleeP2", "DistanceP2", "SiegeP2" };
            string zoneMP="";

            int rowmForce = 0, max = 0;

            if (card.GetComponent<DisplayCard>() != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                        rowmForce += item.GetComponent<DisplayCard2>().realPower2;

                    if (max < rowmForce)
                    { max = rowmForce; zoneMP = cardZonesP2[i]; rowmForce = 0; }
                }
                Debug.Log("Atake maximo del adversario " + max);
                Debug.Log("Zona en la que esta " + zoneMP);
                switch (zoneMP)
                {
                    case "MeleeP2":
                        for (int i = 0; i < GameManager.player1.handZone.Count; i++)
                        {
                            GameObject item = GameManager.player1.handZone[i];
                            if ((item.GetComponent<DisplayCard>().currentCard.name == nameClimate[0]) && (!GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Contains(item) && GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Count < 3))
                            {
                                item.transform.SetParent(GameObject.Find("ClimateZone").transform);
                                GameObject.Find("ClimateZone").GetComponent<ControlPanels>().AddCardToPanelHand(item);
                                item.GetComponent<DisplayCard>().onField = true;
                            }
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard>().realPower = 1;

                            foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard2>().realPower2 = 1;
                        }
                        break;

                    case "DistanceP2":
                        for (int i = 0; i < GameManager.player1.handZone.Count; i++)
                        {
                            GameObject item = GameManager.player1.handZone[i];
                            if ((item.GetComponent<DisplayCard>().currentCard.name == nameClimate[1]) && (!GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Contains(item) && GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Count < 3))
                            {
                                item.transform.SetParent(GameObject.Find("ClimateZone").transform);
                                GameObject.Find("ClimateZone").GetComponent<ControlPanels>().AddCardToPanelHand(item);
                                item.GetComponent<DisplayCard>().onField = true;
                            }
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard>().realPower = 1;

                            foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard2>().realPower2 = 1;
                        }
                        break;

                    case "SiegeP2":
                        for (int i = 0; i < GameManager.player1.handZone.Count; i++)
                        {
                            GameObject item = GameManager.player1.handZone[i];
                            if ((item.GetComponent<DisplayCard>().currentCard.name == nameClimate[2]) && (!GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Contains(item) && GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Count < 3))
                            {
                                item.transform.SetParent(GameObject.Find("ClimateZone").transform);
                                GameObject.Find("ClimateZone").GetComponent<ControlPanels>().AddCardToPanelHand(item);
                                item.GetComponent<DisplayCard>().onField = true;
                            }
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard>().realPower = 1;

                            foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard2>().realPower2 = 1;
                        }
                        break;

                }

            }
            else if (card.GetComponent<DisplayCard2>() != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                        rowmForce += item.GetComponent<DisplayCard>().realPower;

                    if (max < rowmForce)
                    { max = rowmForce; zoneMP = cardZonesP1[i]; rowmForce = 0; }
                }
                Debug.Log("Atake maximo del adversario " + max);
                Debug.Log("Zona en la que esta " + zoneMP);
                switch (zoneMP)
                {
                    case "MeleeP2":
                        for (int i = 0; i < GameManager.player2.handZone.Count; i++)
                        {
                            GameObject item = GameManager.player2.handZone[i];
                            if ((item.GetComponent<DisplayCard2>().currentCard2.name == nameClimate[0]) && (!GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Contains(item) && GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Count < 3))
                            {
                                item.transform.SetParent(GameObject.Find("ClimateZone").transform);
                                GameObject.Find("ClimateZone").GetComponent<ControlPanels>().AddCardToPanelHand(item);
                                item.GetComponent<DisplayCard2>().onField2 = true;
                            }
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard>().realPower = 1;

                            foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard2>().realPower2 = 1;
                        }
                        break;

                    case "DistanceP2":
                        for (int i = 0; i < GameManager.player2.handZone.Count; i++)
                        {
                            GameObject item = GameManager.player2.handZone[i];
                            if ((item.GetComponent<DisplayCard2>().currentCard2.name == nameClimate[1]) && (!GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Contains(item) && GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Count < 3))
                            {
                                item.transform.SetParent(GameObject.Find("ClimateZone").transform);
                                GameObject.Find("ClimateZone").GetComponent<ControlPanels>().AddCardToPanelHand(item);
                                item.GetComponent<DisplayCard2>().onField2 = true;
                            }
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard>().realPower = 1;

                            foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard2>().realPower2 = 1;
                        }
                        break;

                    case "SiegeP2":
                        for (int i = 0; i < GameManager.player2.handZone.Count; i++)
                        {
                            GameObject item = GameManager.player2.handZone[i];
                            if ((item.GetComponent<DisplayCard2>().currentCard2.name == nameClimate[2]) && (!GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Contains(item) && GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Count < 3))
                            {
                                item.transform.SetParent(GameObject.Find("ClimateZone").transform);
                                GameObject.Find("ClimateZone").GetComponent<ControlPanels>().AddCardToPanelHand(item);
                                item.GetComponent<DisplayCard>().onField = true;
                            }
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard>().realPower = 1;

                            foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                                if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                    item.GetComponent<DisplayCard2>().realPower2 = 1;
                        }
                        break;
                }
            }
        }
    }
    public static void MultiplicatePower(params object[] paramtry) // Multiplica por n el ataque de la carta siendo n la cantidad de cartas iguales a ella en el campo
    {
        if(paramtry[0] is GameObject card)
        {
            int cantCig = 0; 
            if (card.GetComponent<DisplayCard>() != null)
            {
                foreach(GameObject item in GameObject.Find("MeleeP1").GetComponent<ControlPanels>().cardInPanel)
                {
                    if(item.GetComponent<DisplayCard>().currentCard.name == card.GetComponent<DisplayCard>().currentCard.name)
                    {
                        cantCig++;
                    }
                }
                foreach(GameObject item in GameObject.Find("MeleeP1").GetComponent<ControlPanels>().cardInPanel)
                {
                    if(item.GetComponent<DisplayCard>().currentCard.name == card.GetComponent<DisplayCard>().currentCard.name)
                    {
                        switch (cantCig)
                        {
                            case 1:
                                item.GetComponent<DisplayCard>().realPower = 3;
                                break;
                            case 2:
                                item.GetComponent<DisplayCard>().realPower = 6;
                                break;
                            case 3:
                                item.GetComponent<DisplayCard>().realPower = 9;
                                break;
                        }
                    }
                }
            }
            else if (card.GetComponent<DisplayCard2>() != null)
            {
                foreach (GameObject item in GameObject.Find("MeleeP2").GetComponent<ControlPanels>().cardInPanel)
                {
                    if (item.GetComponent<DisplayCard2>().currentCard2.name == card.GetComponent<DisplayCard2>().currentCard2.name)
                    {
                        cantCig++;
                    }
                }
                foreach (GameObject item in GameObject.Find("MeleeP2").GetComponent<ControlPanels>().cardInPanel)
                {
                    if (item.GetComponent<DisplayCard2>().currentCard2.name == card.GetComponent<DisplayCard2>().currentCard2.name)
                    {
                        switch (cantCig)
                        {
                            case 1:
                                item.GetComponent<DisplayCard2>().realPower2 = 3;
                                break;
                            case 2:
                                item.GetComponent<DisplayCard2>().realPower2 = 6;
                                break;
                            case 3:
                                item.GetComponent<DisplayCard2>().realPower2 = 9;
                                break;
                        }
                    }
                }
            }
        }
    }
    public static void Average(params object[] paramtry)           // Calcula el promedio de todas las cartas en el campo y luego iguala el poder de todas las cartas en el campo a ese promedio
    {
        string[] zones = { "MeleeP1", "DistanceP1", "SiegeP1", "MeleeP2", "DistanceP2", "SiegeP2" };
        int countCards = 0, atkTotal = 0, average;
        

        for(int i = 0; i < zones.Length; i++)
            countCards += GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel.Count;
        
        for(int i = 0;i < 3; i++)
        {
            for(int j = 0;j < GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
            {
                GameObject item = GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel[j];
                atkTotal += item.GetComponent<DisplayCard>().realPower;
            }
        }
        for (int i = 3; i < 6; i++)
        {
            for (int j = 0; j < GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
            {
                GameObject item = GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel[j];
                atkTotal += item.GetComponent<DisplayCard2>().realPower2;
            }
        }

        average = atkTotal / countCards;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
            {
                GameObject item = GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel[j];
                item.GetComponent<DisplayCard>().realPower = average;
            }
        }
        for (int i = 3; i < 6; i++)
        {
            for (int j = 0; j < GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel.Count; j++)
            {
                GameObject item = GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel[j];
                item.GetComponent<DisplayCard2>().realPower2 = average;
            }
        }
    }          
    public static void IncreseRouw(params object[] paramtry)       // Aumenta en 2 los puntos de ataque de la fila con menos poder en el campo del jugador
    {
        Debug.Log("Effecto Activado");
    }
    public static void LureEffect(params object[] paramtry)        // Cuando es colocada en el campo manda a la mano una carta   
    {
        Debug.Log("Effecto Activado");
    }
    public static void Clearance(params object[] paramtry)         // Quita un clima 
    {
        Debug.Log("Effecto Activado");
    }
    public static void LeaderEffect1(params object[] paramtry)     // Robar una carta extra en cada ronda
    {
        if (paramtry[0] is Player player)
        {
            player.Draw();
            Debug.Log("Efecto de lider de player1 Activado");
        }
    }
    public static void LeaderEffect2(params object[] paramtry)     // Robar una carta extra al inicio   
    {
        if (paramtry[0] is Player player)
        {
            player.Draw();
            Debug.Log("Efecto de lider de player2 Activado");
        }
    }
}
