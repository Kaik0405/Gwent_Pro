using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeck2 : MonoBehaviour
{
    public List<Card> container2 = new List<Card>();
    public List<Card> deck2 = new List<Card>();

    public static int deckSize2;
    public static List<Card> staticDeck2 = new List<Card>();

    public GameObject CardToHand2;
    public GameObject Hand2;

    void Start()
    {
        deckSize2 = CardData.deckHeavenly.Count;

        for (int i = 1; i <= CardData.deckHeavenly.Count - 1; i++)
        {
            deck2.Add(CardData.deckHeavenly[i]);
        }

        // Desordenar el mazo
        for (int i = 0; i < deck2.Count; i++)
        {
            int r = Random.Range(i, deck2.Count);
            Card temp = deck2[i];
            deck2[i] = deck2[r];
            deck2[r] = temp;
        }

        StartCoroutine(StartGame());
    }

    void Update()
    {
        staticDeck2 = deck2;
    }

    IEnumerator StartGame()
    {
        //yield return new WaitForSeconds(1.2f);
        for (int i = 0; i <= 9; i++)
        {
            if (deck2.Count > 0)
            {
                yield return new WaitForSeconds(0.12f);
                GameObject cardToHand2 = Instantiate(CardToHand2, transform.position, transform.rotation);
                DisplayCard2 displayCardScript2 = cardToHand2.GetComponent<DisplayCard2>();
                if (displayCardScript2 != null)
                {
                    displayCardScript2.currentCard2 = deck2[0]; // Pasa la referencia de la carta actual
                }
                deck2.RemoveAt(0); // Elimina la carta de la lista para evitar repeticiones
                deckSize2--;
            }
            else
            {
                break;
            }
        }
    }
}
