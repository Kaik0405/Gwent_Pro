using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public readonly string nameP;
    public bool turn = false;
    public bool round;
    public int pointM = 0;
    public int pointD = 0;
    public int pointS = 0;
    public int pointTotal = 0;
    public List<Card> deck = new List<Card>();
    public List<GameObject> handZone = new List<GameObject>();
    public List<GameObject> meeleZone = new List<GameObject>();
    public List<GameObject> distanceZone = new List<GameObject>();
    public List<GameObject> siegeZone = new List<GameObject>();
    
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
