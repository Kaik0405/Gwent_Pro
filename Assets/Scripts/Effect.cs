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
            for(int i = 0; i < 6; i++)
            {
                if (card == GameObject.Find(positions[i]))
                {
                    foreach (GameObject item in GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if ((item.GetComponent<DisplayCard>() != null) && ((item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)))
                            item.GetComponent<DisplayCard>().realPower += 5;
                        
                        if ((item.GetComponent<DisplayCard2>() != null) && ((item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)))
                        {
                            item.GetComponent<DisplayCard2>().realPower2 += 5;
                        }                  
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
                        }
                    }
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
                        }
                    }
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
    public static void ClearRowLess(params object[] paramtry)      // Limpia la fila con menos unidades
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
    public static void ActivateIncrese(params object[] paramtry)   // Activa una carta de Aumento
    {
        Debug.Log("Effecto Activado");
    }
    public static void ActivateClimate(params object[] paramtry)   // Activa un clima 
    {
        Debug.Log("Effecto Activado");
    }
    public static void MultiplicatePower(params object[] paramtry) // Multiplica por n el ataque de la carta siendo n la cantidad de cartas iguales a ella en el campo
    {
        Debug.Log("Effecto Activado");
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
