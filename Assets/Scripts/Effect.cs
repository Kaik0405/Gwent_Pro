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
                if(card.transform.parent == GameObject.Find(positions[i]))
                {
                    foreach(GameObject item in GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if ((item.GetComponent<DisplayCard>() != null) && ((item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)))
                            item.GetComponent<DisplayCard>().currentCard.power += 5;
                        
                        if ((item.GetComponent<DisplayCard2>() != null) && ((item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)))
                        {
                            item.GetComponent<DisplayCard2>().currentCard2.power += 5;
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
            for(int i = 0;i < 3; i++)
            {
                int powerMax1=0;
                int powerMax2=0;

                foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                {
                    if(item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                    {
                        if (item.GetComponent<DisplayCard>().currentCard.power > powerMax1)
                            powerMax1 = item.GetComponent<DisplayCard>().currentCard.power; 
                    }
                }
                foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                {
                    if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                    {
                        if (item.GetComponent<DisplayCard2>().currentCard2.power > powerMax2)
                            powerMax2 = item.GetComponent<DisplayCard2>().currentCard2.power;
                    }
                }
                if(powerMax1 > powerMax2)
                {
                    foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if (item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)
                        {
                            if(item.GetComponent<DisplayCard>().currentCard.power == powerMax1)
                            {
                                player.graveyard.Add(item);
                                GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Remove(item);
                                item.transform.SetParent(GameObject.Find("GraveyardP1").transform);
                                item.SetActive(false);
                            }
                        }
                    }
                }
                if(powerMax2 > powerMax1)
                {
                    foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                        {
                            if(item.GetComponent<DisplayCard2>().currentCard2.power == powerMax2)
                            {
                                opponet.graveyard.Add(item);
                                GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Remove(item);
                                item.transform.SetParent(GameObject.Find("GraveyardP2").transform);
                                item.SetActive(false);
                            }
                        }
                    }
                }
                else
                {
                    foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                        {
                            if (item.GetComponent<DisplayCard2>().currentCard2.power == powerMax2)
                            {
                                opponet.graveyard.Add(item);
                                GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel.Remove(item);
                                item.transform.SetParent(GameObject.Find("GraveyardP2").transform);
                                item.SetActive(false);
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
                        if ((item.GetComponent<DisplayCard2>().currentCard2.power < min)&&(item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)) 
                            min = item.GetComponent<DisplayCard2>().currentCard2.power;
                    }
                }
                for(int i = 0;i < 3; i++)
                {
                    foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if(item.GetComponent<DisplayCard2>().currentCard2.power == min)
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
                        if ((item.GetComponent<DisplayCard>().currentCard.power < min)&&(item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)) 
                            min = item.GetComponent<DisplayCard>().currentCard.power;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    foreach (GameObject item in GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel)
                    {
                        if (item.GetComponent<DisplayCard>().currentCard.power == min)
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
                                item.GetComponent<DisplayCard>().currentCard.power = 1;

                        foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                            if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                item.GetComponent<DisplayCard2>().currentCard2.power = 1;
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
                                item.GetComponent<DisplayCard>().currentCard.power = 1;

                        foreach (GameObject item in GameObject.Find(cardZonesP2[i]).GetComponent<ControlPanels>().cardInPanel)
                            if (item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)
                                item.GetComponent<DisplayCard2>().currentCard2.power = 1;
                    }
                }
            }
        }
    }
    public static void ClearRowLess(params object[] paramtry)      // Limpia la fila con menos unidades
    {
        string[] cardZonesP1 = { "MeleeP1", "DistanceP1", "SiegeP1" };
        string[] cardZonesP2 = { "MeleeP2", "DistanceP2", "SiegeP2" };
        int Max = 0;

        if ((paramtry[0] is Player player1) && (paramtry[1] is Player player2))
        {
            for (int i = 0; i < 6; i++)
            {
                if (GameObject.Find(cardZonesP1[i]).GetComponent<ControlPanels>().cardInPanel.Count > Max)
                {

                }
            }
        }

    }
    public static void DrawCard(params object[] paramtry) 
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
    public static void MultiplicatePower(params object[] paramtry) // Multiplica n el ataque de la carta siendo n la cantidad de cartas iguales a ella en el campo
    {
        Debug.Log("Effecto Activado");
    }
    public static void Average(params object[] paramtry)           // Calcula el promedio de todas las cartas en el campo y luego iguala el poder de todas las cartas en el campo a ese promedio
    {
        Debug.Log("Effecto Activado");
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
