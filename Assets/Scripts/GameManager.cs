using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    public GameObject HandP1;
    public GameObject HandP2;
    int countRounds;
    static public Player player1 = new Player("Jugador1", true); //
    static public Player player2 = new Player("Jugador2", false); //
    Player currentPlayer;

    void Start()
    {
        countRounds = 1;

        FillDeck(CardData.deckShadows, player1);
        FillDeck(CardData.deckHeavenly, player2);

        SuffleDeck(player1.deck);
        SuffleDeck(player2.deck);
        
        StartCoroutine(DrawPhase(player1, player2));
        currentPlayer = player1;
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
    void Draw(List<Card> deck, Player player)
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
                    Drag dragComponent = cardToHand.GetComponent<Drag>();
                    if (dragComponent != null)
                    {
                        dragComponent.cardPlayer = player1;
                    }
                }
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
                    Drag dragComponent = cardToHand.GetComponent<Drag>();
                    if (dragComponent != null)
                    {
                        dragComponent.cardPlayer = player2;
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

    IEnumerator DrawPhase(Player player1,Player player2)
    {
        for (int i = 0; i <= 9; i++)
        {
            yield return new WaitForSeconds(0.12f);
            Draw(player1.deck,player1);
        }
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i <= 9; i++)
        {
            yield return new WaitForSeconds(0.12f);
            Draw(player2.deck, player2);
        }

    }
    public void SwitchPlayerTurn()
    {

    }

    public void EndTurn()
    {
        player1.SwitchTurn();
        player2.SwitchTurn();
    }

    public void EndRound()
    {
       

          
    }
    void Update()
    {

        player1.handZone = GameObject.Find("HandP1").GetComponent<ControlPanels>().cardInPanel;
        player1.meeleZone = GameObject.Find("MeleeP1").GetComponent<ControlPanels>().cardInPanel;
        player1.distanceZone = GameObject.Find("DistanceP1").GetComponent<ControlPanels>().cardInPanel;
        player1.siegeZone = GameObject.Find("SiegeP1").GetComponent<ControlPanels>().cardInPanel;

        player2.handZone = GameObject.Find("HandP2").GetComponent<ControlPanels>().cardInPanel;
        player2.meeleZone = GameObject.Find("MeleeP2").GetComponent<ControlPanels>().cardInPanel;
        player2.distanceZone = GameObject.Find("DistanceP2").GetComponent<ControlPanels>().cardInPanel;
        player2.siegeZone = GameObject.Find("SiegeP2").GetComponent<ControlPanels>().cardInPanel;


    }
}


