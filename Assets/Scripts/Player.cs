using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player 
{
    public readonly string nameP;
    public bool turn = false;
    public bool win = false;
    public int roundWin = 0;
    public int pointM = 0;
    public int pointD = 0;
    public int pointS = 0;
    public int pointTotal;
    public List<Card> deck = new List<Card>();
    public List<GameObject> handZone = new List<GameObject>();
    public List<GameObject> meeleZone = new List<GameObject>();
    public List<GameObject> distanceZone = new List<GameObject>();
    public List<GameObject> siegeZone = new List<GameObject>();
    public List<GameObject> graveyard = new List<GameObject>();
    
    public Player(string nameP,bool turn)
    {
        this.nameP = nameP;
        this.turn = turn;
    }
    public void SwitchTurn()
    {
        turn = !turn;
    }
    public int PowerFull()
    {
        pointTotal = 0;
        if (handZone != null) {
            if (handZone[0].GetComponent<DisplayCard>() != null)
            {
                foreach (GameObject card in siegeZone)
                {
                    pointTotal += card.GetComponent<DisplayCard>().currentCard.power;
                }
                foreach (GameObject card in meeleZone)
                {
                    pointTotal += card.GetComponent<DisplayCard>().currentCard.power;
                }
                foreach (GameObject card in distanceZone)
                {
                    pointTotal += card.GetComponent<DisplayCard>().currentCard.power;
                }            
            }
            else
            {
                foreach (GameObject card in siegeZone)
                {
                    pointTotal += card.GetComponent<DisplayCard2>().currentCard2.power;
                }
                foreach (GameObject card in meeleZone)
                {
                    pointTotal += card.GetComponent<DisplayCard2>().currentCard2.power;
                }
                foreach (GameObject card in distanceZone)
                {
                    pointTotal += card.GetComponent<DisplayCard2>().currentCard2.power;
                }
            }
        }
        return pointTotal;
    }

    public void Destroy()
    {

    }


}
