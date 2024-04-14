using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public readonly string nameP;
    public bool turn;
    public bool round;
    public int pointM = 0;
    public int pointD = 0;
    public int pointS = 0;
    public int pointTotal = 0;
    public List<Card> deck = new List<Card>();
    public List<Card> handZone = new List<Card>();
    public List<Card> meeleZone = new List<Card>();
    public List<Card> distanceZone = new List<Card>();
    public List<Card> siegeZone = new List<Card>();
    
    public Player(string nameP,bool turn)
    {
        this.nameP = nameP;
        this.turn = turn;
    }
    public void SwitchTurn()
    {
        turn = !turn;
    }
}
