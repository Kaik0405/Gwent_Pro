
### **Introducción**

 El presente reposito es el primer proyecto de programación de la Facultad de Matemática y Computación de la Universidad de La Habana con el título mostrado anteriormente. Con este se pretende crear un juego de cartas en la plataforma de desarrollo de juegos Unity. Este juego de cartas tiene una temática relacionada directamente la popular serie Solo Leveling,  usa dinamicas de otros jugos de cartas como el Gwynt de el juego de The Witcher, además del popular juego de cartas de Yu-Gi-Oh  del cual se extrajeron ideas para el desarrollo de este proyecto.

### El Juego

El Juego consiste en jugar una carta por turno con el objetivo de crear una fuerza de ataque decente en el campo. El jugador tiene el deber de usar sabiamente cada carta pues cada una tiene su efecto el cual lo puede beneficiar o perjudicar de una forma u otra. Para ganar el jugador debe ganar dos rondas, en caso de empate ambos jugadores se le marca la ronda como ganada.

#### Tipos de Cartas

- **Cartas de Lider :** Estas cartas son las insignias de las facciones.
- **Cartas de Plata :**  Estas pueden ocupar tres lugares en el campo (Melee, Distancia, Asedio).
- **Cartas Heroes o Cartas Doradas :**  Estas cartas no pueden ser afectadas por efectos de otras cartas. 
- **Cartas de Aumento :** Incrementan en poder de la fila del jugador donde es activada.
- **Cartas de Clima :** Penaliza reduciendo el poder de ataque una fila en especifico de ambos jugadores.
- **Cartas de Despeje :** Destruye un clima sobre el campo. 

### Desarollo
En este apartado me gustaria compartir como se logro llegar a obtener este maravilloso resultado de poco más de un mes de esfuerzo y noches de desvelo por lo que a continuacion se motrarar algunos de los scrips que son pilares del funcionamiento de este proyecto.

Lo más impresindible para este proyecto y la raíz del crecimiento de este proyecto es la clase Carta esta es la que contiene las caracteristicas fundamentales que debe tener cada objeto de tipo carta, esta clase se encuentra heredando como se muestra a continuacion de Scriptable Object que es una clase de unity que en pocas palabras hace mas dinamico el trabajo con valores a los cuales se les va a asignar a un objecto en escena.
```
public class Card : ScriptableObject
```
Esta clase contiene las diferentes propiedades que necesita una carta en el juego para su correcto funcionamiento
```
public int ID;                            
public new string name; 
public string description;
public int power;

public Sprite spriteImage;

public typecard type;                     // establece si la carta es de tipo oro, plata, señuelo, aumento, lider, clima o despeje 
public typefield pos_field;               // estable si la carta se coloca en la zona de cuerpo a cuerpo, distancia, asedio, aumento, clima o lider
public typefaction faction;               // establece si la carta es de la faccion de las sombras o de los celestiales 

public delegate void EffectCall(params object[] param);
public EffectCall effect;

public enum typecard { unit_silver, unit_gold, lure, leader, climate, increase, clear }
public enum typefield { M, D, S, MD, MS, DS, MDS, fincrease, fclimate, fleader }
public enum typefaction { shadows, heavenly, none }
```
En estas propiedades es de destacar el uso de los enum para establecer un encapsulamiento en el tipo de carta (Si es de lider,oro, plata, señuelo, aumento, clima o despeje). Tambien se utilizan el enum para el lugar donde se puede colocar la carta, asi como la faccion. Pero lo mas destacable en esta clase es el uso del delegado para la logica de los efectos que este de una forma muy dinamica almacena un metodo estatico de una clase estatica la cual es nombrada como **"Effect"** de la cual se hablara mas adelante.
```
public delegate void EffectCall(params object[] param);
public EffectCall effect;
```
Con todas estas propiedades se puede llamar de forma correcta al constructor siguiente que se encargara de asignarle correctamente sus propiedades a cada carta
```
public Card(int ID ,string name, string description, int power, typecard type, typefield pos_field, typefaction faction, Sprite SpriteImage,EffectCall effect) //constructor para cartas monstruo
{
    this.ID = ID;
    this.name = name;
    this.description = description;
    this.power = power;
    this.type = type;
    this.pos_field = pos_field;
    this.faction = faction;
    spriteImage = SpriteImage;
    this.effect = effect;
}
```
El proximo Scrip que es necesario conocer es el encargado de almacenar todas las cartas **(ScriptablesObjects)** en una "base de datos" supuestamente, este Scrip es:
```
public class CardData : MonoBehaviour // scrip de la base de datos de las cartas
```
Este contiene dos listas estaticas que van a almacenar las cartas de los deck las cuales seran usadas posteriormente para la instanciacion de las cartas en la mano y en el campo, ademas de que contiene un array de strings con las descripciones de todas las cartas del deck.
```
public static List<Card> deckShadows = new List<Card>();
public static List<Card> deckHeavenly = new List<Card>();
string[] Descritions = { "....,...."}
```
Las cartas deben ser agregadas a las listas dentro del metodo **Awake()** de Unity que permite agragarlas antes de que se ejecuten los metodos **Start()**. A continuacion se muestra un breve fragmento de codigo de el uso del **Awake()**, de la creacion de los objetos de tipo carta y de como se agregan a las listas de tipo carta:
```
 void Awake()
 {
         deckShadows.Add(new Card(02, "Ingris", descriptions[2],10, Card.typecard.unit_gold, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("MDS"),Effect.DrawCard));
 }
```
Y como se pueden ver las imagenes de las cartas?? me alegra que me hagas esa pregunta pues para eso esta el proximo Scrip **"DisplayCard"** que en realidad son dos pero los dos hacen exactamente lo mismo, con la unica diferencia de que se usan para decks distintos
```
public class DisplayCard : MonoBehaviour
```
Este scrip contiene las siguientes variables que se muestran a continuacion y que esta explicado el uso de cada una en los comentarios 
```
public Card currentCard; // Referencia a la carta actual

string power;
public int realPower;    // maneja el poder real de la carta en el juego

public Sprite SpriteImage;  // variable que recibe el sprite de la clase card
public Image artImage;      // variable que hace referencia al componente imagen de la carta para asignarle el sprite 

public TMP_Text powerText;     // variable que recibe el texto del poder para las cartas que no son de unidad
public TMP_Text realPowerText; // variable que recibe el texto del poder para las cartas de unidad

public bool cardBack;     // controla si se muestra o no la parte de atras de la carta  
public static bool staticCardBack;

Color orig;
public bool onField; // detecta si la carta esta en el campo o no
```
Con todo esto declarado ya se le puede dar vida a las cartas una ves estas sean instanciadas correctamente como objetos en unity y el metodo **Start()** es uno de nuestros protagonistas cuando se trata de eso
```
void Start()
{
 if ((currentCard.type == typecard.unit_gold) || (currentCard.type == typecard.unit_silver) || (currentCard.type == typecard.lure)) // si la carte M D A muestra el poder
     {
          power = currentCard.power.ToString();
          realPower = currentCard.power;

          powerText.text = " " + power;
          realPowerText.text = " " + realPower; 

         SpriteImage = currentCard.spriteImage;
         artImage.sprite = SpriteImage;
     }
}
```
Con este fragmento del metodo si se cumple la condicion de que la carta sea de oro o de plata o señuelo se le asigne la imgen de la carta asi como el poder de la misma  tal y cpmo se ve en las lineas 113 y 114 en el caso del poder, y en el caso de la imagen en la linea 119 y 120

Llegados a este punto es momento de hablar del jugador pues este tambien tiene su Scrip:
```
public class Player: MonoBehaviour 
```
En esta clase se almacenan las principales propiedades y metodos que se van a utilizar para el correcto funcionamiento de la logica del juego , donde encontraremos por ejemplo el turno(turn),  que es una variable de tipo bool para identificar si es el turno del jugador o no, otra para identificar si el jugador gano o no (win), asi como las listas del deck y de las cartas en cada zona de su campo ya sea (Melee, Distancia, o Asedio) tal y como se muetra a continuacion:
```
public readonly string nameP;
public bool turn = false;
public bool win = false;
public int roundWin = 0;
public int pointM = 0;
public int pointD = 0;
public int pointS = 0;
public int pointTotal;
public List<Card> deck = new List<Card>();
public List<GameObject> handZone = new List<GameObject>();
public List<GameObject> meeleZone = new List<GameObject>();
public List<GameObject> distanceZone = new List<GameObject>();
public List<GameObject> siegeZone = new List<GameObject>();
public List<GameObject> graveyard = new List<GameObject>();
 
```
Contiene varios metodos para ayudar a manejar la logica del juego pero como lo prometido es deuda esta clase posee el metodo que va a crear los objetos en la escena de unity y es el metodo **Draw()** que utiliza un metodo de unity llamado Instantiate que basicamente instancia un objeto en una posicion dada en este caso en el inspector de unity se le asigno la mano y ademas que al mismo objeto se le asignan los parametros de la cartas que se guardaron previamente en la lista **deck**.
```
    public void Draw()  // Metodo para instanciar las cartas en la mano del jugador
    {
        if (deck.Count > 0)
        {
            if (nameP == "Jugador1")
            {
                GameObject cardToHand = Instantiate(GameManager.HandP1, GameManager.HandP1.transform.position, GameManager.HandP1.transform.rotation);
                DisplayCard displayCardS = cardToHand.GetComponent<DisplayCard>();

                if (displayCardS != null)
                {
                    displayCardS.currentCard = deck[0];
                    Drag dragComponent = cardToHand.GetComponent<Drag>();
                    if (dragComponent != null)
                    {
                        dragComponent.cardPlayer = GameManager.player1;
                    }
                }
                AudioSource audioSource = cardToHand.GetComponent<AudioSource>();
                audioSource.Play();
                deck.RemoveAt(0);
            }
       }
}
```
Con todo esto listo es mometo de hablar de la logica del juego y de como manejarla de forma muy breve y para ello tenemos el Scrip  **GameManager** que se muestra a continuacion 
```
public class GameManager : MonoBehaviour
```
Este scrip contiene una cantidad un poco extensa de variables pero en su mayoria tienen asignados objetos y paneles de la escena para mejorar la experiencia visual del jugador, me gustaria citar entre todas las variables las que se muestran a continuacion junto con la creacion de los objetos de tipo player:
```
public GameObject HandP1NS;
public GameObject HandP2NS;

static public GameObject HandP1;
static public GameObject HandP2;

//Creacion de los jugadores
static public Player player1 = new Player("Jugador1", true); 
static public Player player2 = new Player("Jugador2", false); 
```
Las primeras variables no estaticas son las que reciben desde el inspector de Unity el parent de las cartas que seran posteriormente instanciadas.

En el metodo **"Start()"** es donde da inicio a la logica del juego en un primer momento se llama un audio bastante llamativo y nostalgicos para los que en algun momento de nuestras vidas vimos la serie original de Yu-Gi-Oh , a continuacion las variables estaticas toma las referencias de los objetos en escena, segidamente la ronda se marca como 1 es decir comienza la primera ronda se llama al metodo **"FillDeck()"** para llenar los decks de ambos jugadores , se instancian los lideres en el campo llamando al metodo correspondiente y se llama a la corutina de la Fase de robo para que los jugadores obtengan sus 10 cartas al inicio del juego:
```
void Start()
{
    StartCoroutine(StartDuel());

    HandP1 = HandP1NS;
    HandP2 = HandP2NS;

    countRounds = 1;

    FillDeck(CardData.deckShadows, player1);
    FillDeck(CardData.deckHeavenly, player2);

    InstantiateLeader(player1 , player2);
    StartCoroutine(DrawPhase());
}
```
Los metodos mencionados anteriormente son los que se muestran a continuacion:
```
 public void FillDeck(List<Card> deck,Player player)
 public void SuffleDeck(List<Card> deck) // Desordena el deck
 public void InstantiateLeader(Player player1,Player player2) //Instancia los lideres en el      campo
 public void InstantiateLeader(Player player1,Player player2) //Instancia los lideres en el campo
```
Los dos metodos que se muestran a continuacion son los encargados de manejar la logica de turnos y de ronda estos metodos son llamados mediante botones en escena , cabe aclarar que se sustentan de multiples metodos que seria algo tedioso explicarlos uno a uno por lo que se invita al lector a indagar en ellos en el reposito...
```
public void EndTurn() // Metodo para terminar el turno
{
    player1.SwitchTurn();
    player2.SwitchTurn();
    Drop.invoke = false;
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
        HandleGameOver(); // maneja la logica de finalizacion del duelo
    }
}
```
Entre los metodos y enum que ayudan a que esto funcione se encuentran los que aparecen a continuacion:
```
public enum GameState // Este enum controla el estado del juego (si hay ganador o empate)
IEnumerator Retard(GameState winner) // con esta corutina salen los paneles de informacion al finalizar la ronda
private bool GameOver() // Detecta si hay un ganador del juego
private void ToggleEndRoundButton(bool active) // Metodo que controla el botton para activar o desactivar el boton de terminar ronda
private GameState DetermineWinner() // metodo para determinar el jugador con la mayor fuerza de ataque en el campo
private void HandleRoundEnd(GameState winner) // Metodo para controlar lo que sucede en dependencia de que el jugador gane o exista empate 
private void HandlePlayerWin(Player playerW,Player playerL) // determina todo lo que va a suceder en el campo cuando un jugador gane
private void HandleDraw(Player currentPlayer) // metodo para determinar que sucede en caso de empate
private void DrawCards() //Metodo para robar dos cartas al finalizar una ronda
private void HandleGameOver() //Metodo de finalizacion del juego
```
Ahora debe surgir la duda de como se logran jugar las cartas. Pues para eso se usa la dinamica del **Drag**(Arrastrar) y el **Drop**(Soltar) con estos dos Scrip se maneja bien esto pero haremos mas enfasis en este documento en el Drop que es el encargado de hacer la supuesta "invocacion" para llegar a ese punto primero veremos un Scrip que permitira controlar las cartas que se juegen en el campo o en la zona correspondiente.
Este Scrip es nombrado **ControlPanels()** y contiene un metodo que sin el se rompe toda la logica de invocacion toda la jugabilidad del juego valga la redundancia..
```
public class ControlPanels : MonoBehaviour // scrip de control de invocacion en las zonas respectivas
```
Este Scrip contiene una variable que basicamente va a almacenar el panel(zona) y una lista que va contener las cartas que se logren jugar en el panel(zona)
```
public GameObject panelField;
public List<GameObject> cardInPanel = new List<GameObject>();
```
El metodo principal del control de invocacion recibe varios parametros los cuales les van a permitir saber si la carta es invocable para ello recible el panel donde la carta se puede jugar que viene directamente de la clase **Card**,verifica la faccion a la que pertenece, verfica si la carta fue invocada, si la carta esta en el campo. Si todas las condiciones las cumple correctamente las carta es Dropeada(invocada) ya que retorna true el metodo...
```
public bool CanPlaceCard(Card.typefield panel, Card.typefaction faction, DisplayCard onField, DisplayCard2 onField2,GameObject cardDrg)
```
Ademas, este Scrip posee un metodo para agregar las cartas invocadas a la lista previamente mencionada:
```
public void AddCardToPanelHand(GameObject card) // metodo para agregar la carta a cardInPanel en caso de ser colocada
  {
      cardInPanel.Add(card);
  }
```
A pesar de que el proyecto en el punto donde se esta redactando este documeto contiene 24 Scrips quisiera cerrar con dos ultimos Scrips que estan muy vinculados, esto no implica que los otros Scrips sean menos importantes, sin embargo estos que se mencionaron son los necesesarios para poder enteder la base de lo que es el funcionamiento del juego.

Estos Scrips son **Drop** y **Effect**:
El Scrip **Drop** es el encargado de manejar la logica de invocacion este Hereda ademas del clasico **MonoBehaviour** una clase que maneja eventos de Unity (**IDropHandler**)
```
public class Drop : MonoBehaviour, IDropHandler // Scrip de invocacion
```
Entre las principales propiedades se encuentran las que aparecen a continuacion
```
 private AudioSource audioActivCard; //audio de invocacion o activacion de carta
 public GameObject audioEffect;      //audio de activacion de efecto

 static public bool invoke = false;  //detector de invocacion
 private GameObject cardDrop;

 public GameObject cardEffectBig;  // objeto al cual se le asigna la imagen de la carta al activarse su efecto
 GameObject CardP;  // objecto que hace referencia a la carta arrastrada
 Image imageCard ;  // imagen de la carta arrastrada
 Sprite spriteCard; // strite de la carta arrastrada
```
Todas contribuyen en el correcto funcionamiento del Drop sin embargo la funcion mas interesante que tiene el drop se que permite llamar a los efectos  para ello se utiliza el metodo **EffectActive()** que en pocas palabras en dependencia de la carta que se juege va a asignarle los valores a la propiedad effect del ScriptableObject.
```
private void EffectActive(DisplayCard card1, DisplayCard2 card2, GameObject eventData, GameObject panelObject)
if (card1 != null)
{
    if ((card1.currentCard.ID == 12) || (card1.currentCard.ID == 13) || (card1.currentCard.ID == 14) || (card1.currentCard.ID == 7) || (card1.currentCard.ID == 6)||(card1.currentCard.ID == 9))
    { card1.currentCard.effect(eventData); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }
}
```
Con este metodo se llama correctamente al efecto el cual se encuentra en la **clase estatica Effect**.Esta clase contine 15 metodos estaticos que son los efectos que se le asignan al ScriptableObject Card los cuales tienen diversas funciones en el juego..
```
public static void LeaderEffect1(params object[] paramtry)     // Robar una carta extra en cada ronda
public static void LeaderEffect2(params object[] paramtry)     // Robar una carta extra al inicio  
public static void Increse(params object[] paramtry)           // Aumenta el poder de ataque de una fila en el campo del jugador por 5 pts
public static void DestroyCardStrong(params object[] paramtry) // Destruye la carta mas fuerte en el campo
public static void DestroyCardWeak(params object[] paramtry)   // Destrye la carta mas debil del adversario
public static void Climate(params object[] paramtry)           // disminuye el poder de las cartas de unidad a 1 de la misma fila de ambos jugadores
public static void ClearRowLess(params object[] paramtry)      // Limpia la fila con menos unidades
public static void DrawCard(params object[] paramtry)          // Robar una carta
public static void ActivateIncrese(params object[] paramtry)   // Activa una carta de aumento que fortalece la zona donde es jugada
public static void ActivateClimate(params object[] paramtry)   // Activa una carta clima para que afecte la zona con mayor fuerza de atak del adversario
public static void MultiplicatePower(params object[] paramtry) // Multiplica por n el ataque de la carta siendo n la cantidad de cartas iguales a ella en el campo
public static void Average(params object[] paramtry)           // Calcula el promedio de todas las cartas en el campo y luego iguala el poder de todas las cartas en el campo a ese promedio
public static void IncreseRouw(params object[] paramtry)       // Aumenta en 2 los puntos de ataque de la fila con menos poder en el campo del jugador
public static void Clearance(params object[] paramtry)         // Quita un clima
```
Entre todos estos efectos me gustaria mostrar el metodo **Increase()** el cual se encarga de aumentar en 5 pts el poder de la fila donde es colocado.
```
public static void Increse(params object[] paramtry)           // Aumenta el poder de ataque de una fila en el campo del jugador por 5 pts
{
    string[] positions = { "IncreseM1", "IncreseD1", "IncreseS1", "IncreseM2", "IncreseD2", "IncreseS2" };
    string[] zones = { "MeleeP1", "DistanceP1", "SiegeP1", "MeleeP2", "DistanceP2", "SiegeP2" };

    if (paramtry[0] is GameObject card)
    {
        for (int i = 0; i < 6; i++)
        {
            if (GameObject.Find(positions[i]).GetComponent<ControlPanels>().cardInPanel.Contains(card))
            {
                foreach (GameObject item in GameObject.Find(zones[i]).GetComponent<ControlPanels>().cardInPanel)
                {
                    if ((item.GetComponent<DisplayCard>() != null) && ((item.GetComponent<DisplayCard>().currentCard.type != Card.typecard.unit_gold)))
                        item.GetComponent<DisplayCard>().realPower += 5;
                    
                    else if ((item.GetComponent<DisplayCard2>() != null) && ((item.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.unit_gold)))
                        item.GetComponent<DisplayCard2>().realPower2 += 5;
                }
            }
        }
    }
}
```
### Conclusiones
El resultado final es algo que realmente nunca pense que tendria y en aquel entonces nunca pense que llegaria a tal punto, pero este proyecto no solo me enseño Unity, me enseño que con esfuerzo y dedicacion no existen limites. Y si llegaste a hasta aqui debo agradecer por haberte sumergido en esta locura a continuacion dejare el link para la descarga del rar del ejecutable del juego

##### Link de Descarga
https://github.com/Kaik0405/Gwent_Pro/blob/master/Gwent-Pro/GwentPro%20Version%201.0.rar
