using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class GameManager : MonoBehaviour
{
    public GameObject HandP1;
    public GameObject HandP2;

    static public Player player1 = new Player("Jugador1", true);
    static public Player player2 = new Player("Jugador2", false);

    void Start()
    {
        FillDeck(CardData.deckShadows, player1);
        FillDeck(CardData.deckHeavenly, player2);

        SuffleDeck(player1.deck);
        SuffleDeck(player2.deck);

        StartCoroutine(DrawPhase(player1, player2));
    }



        
    void FillDeck(List<Card> deck,Player player)
    {
        for (int i = 1; i < deck.Count; i++)
            player.deck.Add(deck[i]);
    }
    void SuffleDeck(List<Card> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int r = Random.Range(i, deck.Count);
            Card temp = deck[i];
            deck[i] = deck[r];
            deck[r] = temp;
        }
    }
    void Draw(List<Card> deck,Player player)
    {
        if (deck.Count > 0)
        {
            if (player.nameP == "Jugador1")
            {
                GameObject cardToHand = Instantiate(HandP1, transform.position, transform.rotation);
                DisplayCard displayCardS = cardToHand.GetComponent<DisplayCard>();
                if (displayCardS != null)
                {
                    displayCardS.currentCard = deck[0];
                }
                player.handZone.Add(deck[0]);
                AudioSource audioSource = cardToHand.GetComponent<AudioSource>();
                audioSource.Play();
                deck.RemoveAt(0);
            }
            if (player.nameP == "Jugador2")
            {
                GameObject cardToHand = Instantiate(HandP2, transform.position, transform.rotation);
                DisplayCard2 displayCardS = cardToHand.GetComponent<DisplayCard2>();
                if (displayCardS != null)
                {
                    displayCardS.currentCard2 = deck[0];
                }
                player.handZone.Add(deck[0]);
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
    IEnumerator DrawPhase(Player player1,Player player2)
    {
        for (int i = 0; i <= 9; i++)
        {
            yield return new WaitForSeconds(0.12f);
            Draw(player1.deck,player1);
        }
        yield return new WaitForSeconds(1.5f);
        for(int i = 0; i <= 9; i++)
        {
            yield return new WaitForSeconds(0.12f);
            Draw(player2.deck, player2);
        }
    }
    public void SwitchPlayerTurn()
    {
        if (player1.turn)
        {
            player1.turn = false;
            player2.turn = true;
        }
        if (player2.turn)
        {
            player2.turn = false;
            player1.turn = true;
        }
    }
}


