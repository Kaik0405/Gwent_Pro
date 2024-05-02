using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player: MonoBehaviour 
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
        if (nameP == "Jugador1")
        {
            foreach (GameObject card in siegeZone)
            {
                pointTotal += card.GetComponent<DisplayCard>().realPower;
            }
            foreach (GameObject card in meeleZone)
            {
                pointTotal += card.GetComponent<DisplayCard>().realPower;
            }
            foreach (GameObject card in distanceZone)
            {
                pointTotal += card.GetComponent<DisplayCard>().realPower;
            }            
        }
        else
        {
            foreach (GameObject card in siegeZone)
            {
                pointTotal += card.GetComponent<DisplayCard2>().realPower2;
            }
            foreach (GameObject card in meeleZone)
            {
                pointTotal += card.GetComponent<DisplayCard2>().realPower2;
            }
            foreach (GameObject card in distanceZone)
            {
                pointTotal += card.GetComponent<DisplayCard2>().realPower2;
            }
        }
        return pointTotal;
    }
    public void Draw()
    {
        if (deck.Count > 0)
        {

            if (nameP == "Jugador1")
            {
                GameObject cardToHand = Instantiate(GameManager.HandP1, GameManager.HandP1.transform.position, GameManager.HandP1.transform.rotation);
                DisplayCard displayCardS = cardToHand.GetComponent<DisplayCard>();

                if (displayCardS != null)
                {
                    displayCardS.currentCard = deck[0];
                    Drag dragComponent = cardToHand.GetComponent<Drag>();
                    if (dragComponent != null)
                    {
                        dragComponent.cardPlayer = GameManager.player1;
                    }
                }
                AudioSource audioSource = cardToHand.GetComponent<AudioSource>();
                audioSource.Play();
                deck.RemoveAt(0);
            }
            if (nameP == "Jugador2")
            {
                GameObject cardToHand = Instantiate(GameManager.HandP2, GameManager.HandP2.transform.position, GameManager.HandP2.transform.rotation);
                DisplayCard2 displayCardS = cardToHand.GetComponent<DisplayCard2>();

                if (displayCardS != null)
                {
                    displayCardS.currentCard2 = deck[0];
                    Drag dragComponent = cardToHand.GetComponent<Drag>();
                    if (dragComponent != null)
                    {
                        dragComponent.cardPlayer = GameManager.player2;
                    }
                }
                AudioSource audioSource = cardToHand.GetComponent<AudioSource>();
                audioSource.Play();
                deck.RemoveAt(0);
            }
        }
        else
        {
            Debug.Log("DeckClear");
        }
    }

}
