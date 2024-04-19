using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    public GameObject HandP1;
    public GameObject HandP2;
    public GameObject bottonEndR;

    int countRounds;
    bool roundpass;

    static public Player player1 = new Player("Jugador1", true); //
    static public Player player2 = new Player("Jugador2", false); //
    
    Player currentPlayer;
    

    void Start()
    {
        countRounds = 1;
        roundpass = true;

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

    public void EndTurn()
    {
        player1.SwitchTurn();
        player2.SwitchTurn();
        Drop.invoke = false;
    }

    public void EndRound()
    {

        if(!(player1.win||player2.win))
        {
            if (roundpass)
            {
                EndTurn();
                bottonEndR.SetActive(false);
                roundpass = false;
            }
            else
            {
                bottonEndR.SetActive(true);
                if (player1.PowerFull() > player2.PowerFull())
                {
                    Debug.Log("Player1 Win");
                    player1.roundWin++;
                    SendGraveyard();
                    player1.turn = true;
                    player2.turn = false;
                    Drop.invoke = false;
                    roundpass = true;
                    currentPlayer = player1;
                    if (player1.roundWin == 2)
                    {
                        player1.turn = false;
                        player2.turn = false;
                        Drop.invoke = true;
                        roundpass = false;
                        player1.win = true;
                        Debug.Log("Jugador1 gana");
                        bottonEndR.SetActive(false);
                        GameObject.Find("RoundEnd").SetActive(false);
                    }
                    else
                    {
                        countRounds++;
                        for (int i = 0; i < 2; i++)
                        {
                            Draw(player1.deck, player1);
                            Draw(player2.deck, player2);
                        }
                    }

                }
                else if(player1.PowerFull() < player2.PowerFull())
                {
                
                    Debug.Log("Player2 Win");
                    player2.roundWin++;
                    SendGraveyard();
                    player2.turn = true;
                    player1.turn = false;
                    Drop.invoke = false;
                    roundpass = true;
                    currentPlayer = player2;
                    if (player2.roundWin == 2)
                    {
                        roundpass = false;
                        player2.win = true;
                        player1.turn = false;
                        player2.turn = false;
                        Drop.invoke = true;
                        Debug.Log("Jugador2 gana");
                        bottonEndR.SetActive(false);
                        GameObject.Find("RoundEnd").SetActive(false);
                    }
                    else
                    {
                        countRounds++;
                        for (int i = 0; i < 2; i++)
                        {
                            Draw(player1.deck, player1);
                            Draw(player2.deck, player2);
                        }
                    }
                        
                }
                
                else
                {
                    player1.roundWin++;
                    player2.roundWin++;
                    if (player1.roundWin > player2.roundWin)
                    {
                        Debug.Log("Empate1.0");
                        SendGraveyard();
                        Drop.invoke = false;
                        roundpass = true;
                        if (player1.roundWin == 2)
                        {

                            roundpass = false;
                            player1.win = true;
                            player1.turn = false;
                            player2.turn = false;
                            Drop.invoke = true;
                            Debug.Log("Jugador1 gana");
                            bottonEndR.SetActive(false);
                            GameObject.Find("RoundEnd").SetActive(false);
                        }
                        else
                        {
                            if(currentPlayer == player1)
                            {
                                player1.turn = true;
                                player2.turn = false;
                            }
                            else
                            {
                                player1.turn = false;
                                player2.turn = true;
                            }
                            countRounds++;
                            for (int i = 0; i < 2; i++)
                            {
                                Draw(player1.deck, player1);
                                Draw(player2.deck, player2);
                            }
                        }

                    }

                    else if (player1.roundWin < player2.roundWin)
                    {
                        Debug.Log("Empate2.0");
                        SendGraveyard();
                        Drop.invoke = false;
                        roundpass = true;
                        currentPlayer = player2;
                    
                        if (player2.roundWin == 2)
                        {
                            roundpass = false;
                            player2.win = true;
                            player1.turn = false;
                            player2.turn = false;
                            Drop.invoke = true;
                            Debug.Log("Jugador2 gana");
                            bottonEndR.SetActive(false);
                            GameObject.Find("RoundEnd").SetActive(false);
                        }
                        else
                        {
                            if (currentPlayer == player1)
                            {
                                player1.turn = true;
                                player2.turn = false;
                            }
                            else
                            {
                                player1.turn = false;
                                player2.turn = true;
                            }
                            countRounds++;
                            for (int i = 0; i < 2; i++)
                            {
                                Draw(player1.deck, player1);
                                Draw(player2.deck, player2);
                            }
                        }                       
                    }
                    else
                    {
                        if(currentPlayer == player1)
                        {
                            Debug.Log("Empate1");
                            SendGraveyard();
                            Drop.invoke = false;
                            roundpass = true;
                            player1.turn = true;
                            player2.turn = false;
                            countRounds++;
                            for (int i = 0; i < 2; i++)
                            {
                                Draw(player1.deck, player1);
                                Draw(player2.deck, player2);
                            }
                        }
                        else
                        {
                            Debug.Log("Empate2");
                            SendGraveyard();
                            Drop.invoke = false;
                            roundpass = true;
                            player2.turn = true;
                            player1.turn = false;
                            countRounds++;
                            for (int i = 0; i < 2; i++)
                            {
                                Draw(player1.deck, player1);
                                Draw(player2.deck, player2);
                            }
                        }
                    }
                }

            }
        }
        else
        {
            if(player1.roundWin > player2.roundWin)
            {
                Debug.Log("Jugador1 gana8797879879");
                bottonEndR.SetActive(false);
                GameObject.Find("RoundEnd").SetActive(false);
            }
            else
            {
                Debug.Log("Jugador2 gana80980989809809");
                bottonEndR.SetActive(false);
                GameObject.Find("RoundEnd").SetActive(false);
            }
        }
    }

    public void SendGraveyard()
    {
        // Copia de las listas para iterar
        List<GameObject> meleeP1Cards = GameObject.Find("MeleeP1").GetComponent<ControlPanels>().cardInPanel.ToList();
        List<GameObject> distanceP1Cards = GameObject.Find("DistanceP1").GetComponent<ControlPanels>().cardInPanel.ToList();
        List<GameObject> siegeP1Cards = GameObject.Find("SiegeP1").GetComponent<ControlPanels>().cardInPanel.ToList();

        List<GameObject> meleeP2Cards = GameObject.Find("MeleeP2").GetComponent<ControlPanels>().cardInPanel.ToList();
        List<GameObject> distanceP2Cards = GameObject.Find("DistanceP2").GetComponent<ControlPanels>().cardInPanel.ToList();
        List<GameObject> siegeP2Cards = GameObject.Find("SiegeP2").GetComponent<ControlPanels>().cardInPanel.ToList();

        // Mandar las cartas al cementerio del jugador 1
        foreach (GameObject card in meleeP1Cards)
        {
            player1.graveyard.Add(card);
            GameObject.Find("MeleeP1").GetComponent<ControlPanels>().cardInPanel.Remove(card);
            card.transform.SetParent(GameObject.Find("GraveyardP1").transform);
            card.SetActive(false);
        }
        foreach (GameObject card in distanceP1Cards)
        {
            player1.graveyard.Add(card);
            GameObject.Find("DistanceP1").GetComponent<ControlPanels>().cardInPanel.Remove(card);
            card.transform.SetParent(GameObject.Find("GraveyardP1").transform);
            card.SetActive(false);
        }
        foreach (GameObject card in siegeP1Cards)
        {
            player1.graveyard.Add(card);
            GameObject.Find("SiegeP1").GetComponent<ControlPanels>().cardInPanel.Remove(card);
            card.transform.SetParent(GameObject.Find("GraveyardP1").transform);
            card.SetActive(false);
        }

        // Mandar las cartas al Cementerio del jugador 2 
        foreach (GameObject card in meleeP2Cards)
        {
            player2.graveyard.Add(card);
            GameObject.Find("MeleeP2").GetComponent<ControlPanels>().cardInPanel.Remove(card);
            card.transform.SetParent(GameObject.Find("GraveyardP2").transform);
            card.SetActive(false);
        }
        foreach (GameObject card in distanceP2Cards)
        {
            player2.graveyard.Add(card);
            GameObject.Find("DistanceP2").GetComponent<ControlPanels>().cardInPanel.Remove(card);
            card.transform.SetParent(GameObject.Find("GraveyardP2").transform);
            card.SetActive(false);
        }
        foreach (GameObject card in siegeP2Cards)
        {
            player2.graveyard.Add(card);
            GameObject.Find("SiegeP2").GetComponent<ControlPanels>().cardInPanel.Remove(card);
            card.transform.SetParent(GameObject.Find("GraveyardP2").transform);
            card.SetActive(false);
        }
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


