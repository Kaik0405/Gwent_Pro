using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeck1 : MonoBehaviour
{
    public List<Card> deck1 = new List<Card>();
    
     
    void Start()
    {
        

        for (int i = 1; i <= CardData.deckShadows.Count-1; i++) 
        {
            deck1[i-1] = CardData.deckShadows[i];
        }
        int posmess = Random.Range(0, deck1.Count);

        Card aux = null;

        for (int i = 0; i < deck1.Count; i++) 
        {
            aux = deck1[i];
            deck1[i] = deck1[posmess];
            deck1[posmess] = aux; 
        }



    }


    void Update()
    {
        
    }
}
