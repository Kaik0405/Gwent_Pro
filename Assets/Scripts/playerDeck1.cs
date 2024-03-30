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
    public GameObject Hand;

    void Start()
    {
        deckSize = CardData.deckShadows.Count;

        for (int i = 1; i <= CardData.deckShadows.Count - 1; i++)
        {
            deck1.Add(CardData.deckShadows[i]);
        }

        // Desordenar el mazo
        for (int i = 0; i < deck1.Count; i++)
        {
            int r = Random.Range(i, deck1.Count);
            Card temp = deck1[i];
            deck1[i] = deck1[r];
            deck1[r] = temp;
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
            if (deck1.Count > 0)
            {
                yield return new WaitForSeconds(0.3f);
                GameObject cardToHand = Instantiate(CardToHand, transform.position, transform.rotation);
                DisplayCard displayCardScript = cardToHand.GetComponent<DisplayCard>();
                if (displayCardScript != null)
                {
                    displayCardScript.currentCard = deck1[0]; // Pasa la referencia de la carta actual
                }
                deck1.RemoveAt(0); // Elimina la carta de la lista para evitar repeticiones
                deckSize--;
            }
            else
            {
                break;
            }
        }
    }
}
