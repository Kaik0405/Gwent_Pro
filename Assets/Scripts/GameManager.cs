using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class GameManager : MonoBehaviour
{
    public GameObject HandP1NS;
    public GameObject HandP2NS;

    static public GameObject HandP1;
    static public GameObject HandP2;

    public GameObject duelstart;

    public GameObject Leader1;
    public GameObject Leader2;

    public GameObject bottonEndR;

    public GameObject PanelP1WinR;
    public GameObject PanelP2WinR;
    public GameObject PanelDrawR;

    public GameObject PanelGameOver;
    public GameObject PanelP1Win;
    public GameObject PanelP2Win;
    public GameObject PanelDrawGame;

    public GameObject slot1W;
    public GameObject slot2W;
    public GameObject slot3W;
    public GameObject slot4W;

    int countRounds;
    bool roundpass;

    //Creacion de los jugadores
    static public Player player1 = new Player("Jugador1", true); 
    static public Player player2 = new Player("Jugador2", false); 
    
    Player currentPlayer;
    
    void Start()
    {
        StartCoroutine(StartDuel());

        HandP1 = HandP1NS;
        HandP2 = HandP2NS;

        countRounds = 1;
        roundpass = true;

        FillDeck(CardData.deckShadows, player1);
        FillDeck(CardData.deckHeavenly, player2);

        InstantiateLeader(player1 , player2);
       
        StartCoroutine(DrawPhase());
        currentPlayer = player1;
    }
    IEnumerator StartDuel()
    {
        yield return new WaitForSeconds(1.0f);
        duelstart.SetActive(true);
        duelstart.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3.2f);
        duelstart.SetActive(false);
    }
    private void FillDeck(List<Card> deck,Player player) // Agrega las cartas de la base de datos al deck
    {
        for (int i = 0; i < deck.Count; i++)
            player.deck.Add(deck[i]);
    } 
    private void SuffleDeck(List<Card> deck) // Desordena el deck
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int r = Random.Range(i, deck.Count);
            Card temp = deck[i];
            deck[i] = deck[r];
            deck[r] = temp;
        }
    } 
    private void InstantiateLeader(Player player1,Player player2) //Instancia los lideres en el campo 
    {
        GameObject leader1 = Instantiate(HandP1, transform.position, transform.rotation);
        DisplayCard displayCardL = leader1.GetComponent<DisplayCard>();
        displayCardL.currentCard = player1.deck[0];
        player1.deck.RemoveAt(0);
        SuffleDeck(player1.deck);
        
        GameObject leader2 = Instantiate(HandP2, transform.position, transform.rotation);
        DisplayCard2 displaycardL2 = leader2.GetComponent<DisplayCard2>();
        displaycardL2.currentCard2 = player2.deck[0];
        player2.deck.RemoveAt(0);
        SuffleDeck(player2.deck);
        displayCardL.currentCard.effect(player1); //Activacion del efecto del lider del jugador 1
    }
    IEnumerator DrawPhase() // Instancia las cartas en las manos de ambos jugadores
    {
        for (int i = 0; i <= 9; i++)
        {
            yield return new WaitForSeconds(0.12f);
            player1.Draw();
        }
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i <= 9; i++)
        {
            yield return new WaitForSeconds(0.12f);
            player2.Draw();
        }
    } 
 
    public void EndTurn() // Metodo para terminar el turno
    {
        player1.SwitchTurn();
        player2.SwitchTurn();
        Drop.invoke = false;
    }

    public enum GameState 
    {
        Player1Win,
        Player2Win,
        Draw
    }

    public void EndRound() //  Metodo de control de Rondas
    {
        if (!GameOver())    // llama a ese metodo para determinar si el juego no ha terminado 
        {
            if (roundpass)  // verificacion de cambio de ronda  
            {
                EndTurn();   
                ToggleEndRoundButton(false); //desactiva el boton de cambio de turno  
                roundpass = false;           //con esto obliga a entrar en el else al volver a apretar el boton 
            }
            else            
            {
                ToggleEndRoundButton(true); //activa el boton de cambio de turno 
                GameState winner = DetermineWinner();
                StartCoroutine(Retard(winner)); 
                HandleRoundEnd(winner);
            }
        }
        else
        {
            HandleGameOver();
        }
    }
    IEnumerator Retard(GameState winner)
    {
        if(winner == GameState.Player1Win)
        {
            PanelP1WinR.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            PanelP1WinR.SetActive(false);
        }
        else if(winner == GameState.Player2Win)
        {
            PanelP2WinR.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            PanelP2WinR.SetActive(false);
        }
        else
        {
            PanelDrawR.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            PanelDrawR.SetActive(false);
        }
    }
    private bool GameOver() // Detecta si hay un ganador del juego
    {
        return player1.win || player2.win;
    }
    private void ToggleEndRoundButton(bool active)
    {
        bottonEndR.SetActive(active);
    }
    private GameState DetermineWinner() // metodo para determinar el jugador con la mayor fuerza de ataque en el campo
    {
        if (player1.PowerFull() > player2.PowerFull()) return GameState.Player1Win;
        
        else if (player1.PowerFull() < player2.PowerFull()) return GameState.Player2Win;
        
        else return GameState.Draw;
    }
    
    private void HandleRoundEnd(GameState winner) // Metodo para controlar lo que sucede en dependencia de que el jugador gane o exista empate  
    {
        switch (winner)
        {
            case GameState.Player1Win:
                player1.roundWin++;
                slot1W.SetActive(true);
                Debug.Log("Jugador 1 WinRound");
                HandlePlayerWin(player1, player2);
                break;
            case GameState.Player2Win:
                player2.roundWin++;
                slot3W.SetActive(true);
                Debug.Log("Jugador 2 WinRound");
                HandlePlayerWin(player2,player1);

                break;
            case GameState.Draw:
                Debug.Log("Empate");
                slot1W.SetActive(true);
                slot3W.SetActive(true);
                HandleDraw(currentPlayer);
                break;
        }
    }
    private void HandlePlayerWin(Player playerW,Player playerL) // determina todo lo que va a suceder en el campo cuando un jugador gane
    {
        SendGraveyard();      
        playerW.turn = true;   
        playerL.turn = false; 
        Drop.invoke = false;  
        roundpass = true;     
        currentPlayer = playerW;

        if (playerW.roundWin == 2)
        {
            Debug.Log(currentPlayer.nameP + " Win Game");
            playerW.win = true;
            HandleGameOver();
        }
        else DrawCards(); 
    }
    private void HandleDraw(Player currentPlayer) // metodo para determinar que sucede en caso de empate
    {
        player1.roundWin++;
        player2.roundWin++;

        if (player1.roundWin == 2 && player2.roundWin == 2)
        {
            Debug.Log("Empate GAME");
            HandleGameOver();
            slot2W.SetActive(true);
            slot4W.SetActive(true);
        }
        else if (player1.roundWin == 2)
        {
            Debug.Log("Jugador1 Win Game");
            player1.win = true;
            slot2W.SetActive(true);
            slot3W.SetActive(true);
            HandleGameOver();
        }
        else if (player2.roundWin == 2)
        {
            Debug.Log("Jugador2 Win Game");
            player2.win = true;
            slot4W.SetActive(true);
            slot1W.SetActive(true);
            HandleGameOver();
        }
        else
        {
            if (currentPlayer == player1) HandlePlayerWin(player1, player2);

            else HandlePlayerWin(player2, player1);
        }
    }
    private void DrawCards()
    {
        countRounds++;
        for (int i = 0; i < 2; i++)
        {
            player1.Draw();
            player2.Draw();
        }
    }
    private void HandleGameOver() //Metodo de finalizacion del juego
    {
        player1.turn = false;
        player2.turn = false;
        roundpass = false;
        Drop.invoke = true;
        bottonEndR.SetActive(false);
        GameObject.Find("RoundEnd").SetActive(false);
        SendGraveyard();
        Debug.Log("Game Over");
        PanelGameOver.SetActive(true);

        if (player1.win)
        {
            PanelP1Win.SetActive(true);
            slot2W.SetActive(true);
        }
        else if (player2.win)
        {
            PanelP2Win.SetActive(true);
            slot4W.SetActive(true);
        }
        else PanelDrawGame.SetActive(true);
    }
    private void SendGraveyard() //metodo que envia todas las cartas del campo para el cementerio al finalizar la ronda
    {
        string[] playerZones = { "MeleeP1", "DistanceP1", "SiegeP1", "IncreseM1", "IncreseD1", "IncreseS1", "MeleeP2", "DistanceP2", "SiegeP2", "IncreseM2", "IncreseD2", "IncreseS2" };
        string[] graveyardNames = { "GraveyardP1", "GraveyardP2" };

        for (int i = 0; i < playerZones.Length; i++)
        {
            string zoneName = playerZones[i];
            string graveyardName = i < 6 ? graveyardNames[0] : graveyardNames[1];
            
            List<GameObject> cards = GameObject.Find(zoneName).GetComponent<ControlPanels>().cardInPanel.ToList();

            foreach (GameObject card in cards)
            {
                Player player = i < 6 ? player1 : player2;
                player.graveyard.Add(card);


                GameObject.Find(zoneName).GetComponent<ControlPanels>().cardInPanel.Remove(card);
                card.transform.SetParent(GameObject.Find(graveyardName).transform);
                card.SetActive(false);
            }
        }

        List<GameObject> climateCards = GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.ToList();
        foreach (GameObject card in climateCards)
        {
            Player player = card.GetComponent<DisplayCard>() != null ? player1 : player2;
            player.graveyard.Add(card);

            GameObject.Find("ClimateZone").GetComponent<ControlPanels>().cardInPanel.Remove(card);
            card.transform.SetParent(GameObject.Find(player == player1 ? "GraveyardP1" : "GraveyardP2").transform);
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
