using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeck1 : MonoBehaviour
{
    public List<Card> container = new List<Card>();
    public List<Card> deck1 = new List<Card>();

    public static int deckSize;
    public static List<Card> staticDeck = new List<Card>();

    public GameObject CardToHand;
    public GameObject[] Clone;
    public GameObject Hand;

    void Start()
    {
        deckSize = 29;

        for (int i = 1; i <= CardData.deckShadows.Count-1; i++) 
        {
            deck1.Add(CardData.deckShadows[i]);
        }
        int posmess = Random.Range(0, deck1.Count);

        Card aux = null;

        for (int i = 0; i < deck1.Count; i++) 
        {
            aux = deck1[i];
            deck1[i] = deck1[posmess];
            deck1[posmess] = aux; 
        }
        StartCoroutine(StartGame());
    }

    void Update()
    {
        staticDeck = deck1;
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i <= 9; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
}
