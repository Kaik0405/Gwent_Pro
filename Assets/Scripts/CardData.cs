using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public static List<Card> deckShadows = new List<Card>();
    public static List<Card> deckHeavenly = new List<Card>();

    string[] descriptions =
    {
        "Conocido desde las misma creacion del universo como el Monarca de las Sombras.\nEfecto: Al comenzar el duelo el jugador que posea esta carta roba una carta extra",
        "Reencarnad0 desde la ultima guerra, conocido como el guerrero mas fuerte del ejercito de sombras.\nEfecto: Destruye la carta mas debil del campo del adversario",
        "El caballero que mas lealtad le tiene al Monarca de las Sombras.\nEfecto: Cuando esta carta es invocada el jugador roba una carta",
        "La sombra mas conocida del ejercito por su basra sabiduria.\nEfecto: Destruye todas las cartas de la fila mas debil del campo",
        "Dragon de gran fortaleza cuyas llamaradas evapora los lagos mas profunos.\nEfecto: Destruye la carta mas fuerte sobre el campo",
        "El dragon mas sabio del ejercito de sombras del Monarca de las Sombras cuya edad se remonta a los inicios de la creacion.\nEfecto: Cuando esta carta es invocada el jugador roba una carta",
        "Conocida como la sobra de la ultima mirada la cual lleva a los mortales a la locura con su simple presencia.\nEfecto: Cuando esta carta es invocada en el campo, el jugador activa una carta clima de la mano",
        "La version mas joven de Bellion el cual era el primer integrante del ejercito del Monarca de las sombras.\nEfecto: Cuando esta carta es invocada en el campo, el jugador activa un carta de incremento de la mano",
        "El rey hormiga de una antigua mazmorra de rango S, cuyo hizo temblar a cientos de cazadore de rango S.\nEffecto: Aumenta en 2 los puntos de ataque de la fila con menos poder en el campo del jugador",
        "Antiguo cazador de Rango S que no pudo evadir la muerte tras enfrentarse al Monarca de las Sombras el cual fue convertido en sombra por admiracion del monarca.\nEfecto: Multiplica por n el ataque de la carta siendo n la cantidad de cartas iguales a ella en el campo",
        "Cazador de rango S con las habilidades curativas mas increibles de los mortales el cual fue reencarnado por el Monarca de las Sombras.\nEfecto: Calcula el promedio de todas las cartas en el campo y luego iguala el poder de todas las cartas en el campo a ese promedio",
        "Antiguo jefe de una mazmora de ogros cuyos hechizos eran muy venerados por los cazadores mas audaces.\nEfecto Señuelo: Cuando esta carta es invocada selecciona una carta en el campo del jugador y la manda para la mano",
        
        "Efecto de Carta Clima: Convierte el ataque de todas las cartas de unidad en la zona de ataque Cuerpo a Cuerpo en 1",
        "Efecto de Carta Clima: Convierte el ataque de todas las cartas de unidad en la zona de ataque a Distance en 1",
        "Efecto de Carta Clima: Convierte el ataque de todas las cartas de unidad en la zona de Asedio en 1",
        "Efecto de Aumento: Incrementa el poder de ataque de las cartas de unidad en la fila donde es colocada",
        "Efecto de Despeje: Elimina un clima en el campo",

        "Una guerrera de luz dorada, conocida por su valentía y su baston brillante que ilumina a la oscuridad más profunda.\nEfecto: Al inicio de cada ronda el jugador roba una carta extra",
        "Un sabio arcangel con un conocimiento vasto del universo, capaz de predecir eventos futuros con una precisión asombrosa.\nEfecto: Destruye la carta mas debil del campo del adversario",
        "Un misterioso viajero que tiene la habilidad de manipular el tiempo, siempre aparece en el momento justo para cambiar el curso de los eventos.\nEfecto: Cuando esta carta es invocada el jugador roba una carta",
        "Un poderoso mago que controla los elementos, su magia es tan fuerte que puede cambiar el clima con un simple gesto.\nEfecto: Destruye todas las cartas de la fila mas debil del campo",
        "Un guerrero de luz, su ira es tan intensa como una supernova, y su espada de luz puede derretir cualquier armadura.\nEfecto: Destruye la carta mas fuerte sobre el campo",
        "Un ágil explorador con la habilidad de controlar el viento, puede volar a través del cielo con la velocidad de un huracán.\nEfecto: Cuando esta carta es invocada el jugador roba una carta",
        "Un ser celestial que brilla con una luz etérea, su presencia trae paz y armonía a todos los que lo rodean.\nEfeccto: Cuando esta carta es invocada en el campo, el jugador activa una carta clima de la mano",
        "Un arquero que nunca falla y que posee una bondad capaz de hacer perder los deseos de combatir al mas furioso de los guerreros\nEfecto: Cuando esta carta es invocada en el campo, el jugador activa un carta de incremento de la mano",
        "Un poderoso angel que posee un hacha capaz de cortar las dimansiones.\nEfecto: Aumenta en 2 los puntos de ataque de la fila con menos poder en el campo del jugador",
        "Un angel de la belleza y la gracia, su presencia puede cautivar a cualquiera que la mire.\nEfecto: Multiplica por n el ataque de la carta siendo n la cantidad de cartas iguales a ella en el campo",
        "Una princesa de la luz estelar, su brillo puede iluminar la noche más oscura.\nEfecto: Calcula el promedio de todas las cartas en el campo y luego iguala el poder de todas las cartas en el campo a ese promedio",
        "Un ser inmortal que ha existido desde el inicio del tiempo, su sabiduría es tan profunda como el océano\nEfecto Señuelo: Cuando esta carta es invocada selecciona una carta en el campo del jugador y la manda para la mano"
    };
    
    void Awake()
    {
        //deck de Sombras
        //carta Lider
        deckShadows.Add(new Card(00, "Sung Jing Woo", descriptions[0], Card.typecard.leader, Card.typefield.fleader, Card.typefaction.shadows, Resources.Load<Sprite>("Lidertype0"),Effect.LeaderEffect1));
        //Cartas de Unidad
        //Cartas Oro
        deckShadows.Add(new Card(01, "Bellion", descriptions[1],10, Card.typecard.unit_gold, Card.typefield.MS, Card.typefaction.shadows, Resources.Load<Sprite>("MD"),Effect.DestroyCardWeak));
        deckShadows.Add(new Card(02, "Ingris", descriptions[2],10, Card.typecard.unit_gold, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("MDS"),Effect.DrawCard));
        deckShadows.Add(new Card(03, "The Codice", descriptions[3], 10, Card.typecard.unit_gold, Card.typefield.MD, Card.typefaction.shadows, Resources.Load<Sprite>("MD1"),Effect.ClearRowLess));
        deckShadows.Add(new Card(04, "Kaisel", descriptions[4],10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.shadows, Resources.Load<Sprite>("MDS1"),Effect.DestroyCardStrong));
        deckShadows.Add(new Card(05, "Arcane", descriptions[5],10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.shadows, Resources.Load<Sprite>("DS1"),Effect.DrawCard));
        //Cartas Plata
        deckShadows.Add(new Card(06, "Kamish", descriptions[6],5, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.shadows, Resources.Load<Sprite>("D1(x2)"),Effect.ActivateClimate));
        deckShadows.Add(new Card(06, "Kamish", descriptions[6],5, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.shadows, Resources.Load<Sprite>("D1(x2)"),Effect.ActivateClimate));
        deckShadows.Add(new Card(07, "Bellion Low", descriptions[7],7, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.shadows, Resources.Load<Sprite>("D2(x2)"),Effect.ActivateIncrese));
        deckShadows.Add(new Card(07, "Bellion Low", descriptions[7],7, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.shadows, Resources.Load<Sprite>("D2(x2)"),Effect.ActivateIncrese));
        deckShadows.Add(new Card(08, "Beru", descriptions[8],8, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)"),Effect.IncreseRouw));
        deckShadows.Add(new Card(08, "Beru", descriptions[8],8, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M1(x3)"),Effect.IncreseRouw));
        deckShadows.Add(new Card(09, "Greed", descriptions[9],3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)"),Effect.MultiplicatePower));
        deckShadows.Add(new Card(09, "Greed", descriptions[9],3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)"),Effect.MultiplicatePower));
        deckShadows.Add(new Card(09, "Greed", descriptions[9],3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.shadows, Resources.Load<Sprite>("M2(x2)"),Effect.MultiplicatePower));
        deckShadows.Add(new Card(10, "Uleni", descriptions[10],4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)"),Effect.Average));
        deckShadows.Add(new Card(10, "Uleni", descriptions[10],4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)"),Effect.Average));
        deckShadows.Add(new Card(10, "Uleni", descriptions[10],4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.shadows, Resources.Load<Sprite>("S1(x3)"),Effect.Average));
        deckShadows.Add(new Card(11, "Tusk", descriptions[11],0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Lure(x2)"),Effect.LureEffect));
        deckShadows.Add(new Card(11, "Tusk", descriptions[11],0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Lure(x2)"),Effect.LureEffect));
        //Cartas
        deckShadows.Add(new Card(12, "Hell", descriptions[12], Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.shadows, Resources.Load<Sprite>("InfiernoMelee(S)"),Effect.Climate));
        deckShadows.Add(new Card(13, "Fog of de dark", descriptions[13], Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.shadows, Resources.Load<Sprite>("NieblaDist(S)"),Effect.Climate));
        deckShadows.Add(new Card(14, "Judgment Meteors", descriptions[14], Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.shadows, Resources.Load<Sprite>("LluviaMetSiege(S)"),Effect.Climate));
        deckShadows.Add(new Card(15, "The Power of Iron", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(15, "The Power of Iron", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(15, "The Power of Iron", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(15, "The Power of Iron", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(15, "The Power of Iron", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.shadows, Resources.Load<Sprite>("AumX3(S)"),Effect.Increse));
        deckShadows.Add(new Card(16, "The Dawn After the Sunset", descriptions[16], Card.typecard.clear, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Despeje(S)"),Effect.Clearance));
        deckShadows.Add(new Card(16, "The Dawn After the Sunset", descriptions[16], Card.typecard.clear, Card.typefield.MDS, Card.typefaction.shadows, Resources.Load<Sprite>("Despeje(S)"),Effect.Clearance));
        //deck de Celestiales
        //carta Lider
        deckHeavenly.Add(new Card(00, "Aureliana", descriptions[17], Card.typecard.leader, Card.typefield.fleader, Card.typefaction.heavenly, Resources.Load<Sprite>("Lider"),Effect.LeaderEffect2));
        //Cartas de Unidad
        //Cartas Oro
        deckHeavenly.Add(new Card(01, "Raphaelius", descriptions[18], 10, Card.typecard.unit_gold, Card.typefield.MS, Card.typefaction.heavenly, Resources.Load<Sprite>("DS(P2)"),Effect.DestroyCardWeak));
        deckHeavenly.Add(new Card(02, "Zadkielus", descriptions[19], 10, Card.typecard.unit_gold, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("MD(P2)"),Effect.DrawCard));
        deckHeavenly.Add(new Card(03, "Gabrioth", descriptions[20], 10, Card.typecard.unit_gold, Card.typefield.MD, Card.typefaction.heavenly, Resources.Load<Sprite>("MD1(P2)"),Effect.ClearRowLess));
        deckHeavenly.Add(new Card(04, "Pyraethus", descriptions[21], 10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.heavenly, Resources.Load<Sprite>("MDS(P2)"),Effect.DestroyCardStrong));
        deckHeavenly.Add(new Card(05, "Aerovane", descriptions[22], 10, Card.typecard.unit_gold, Card.typefield.DS, Card.typefaction.heavenly, Resources.Load<Sprite>("MDS1(P2)"),Effect.DrawCard));
        //Cartas Plata
        deckHeavenly.Add(new Card(06, "Aetherion", descriptions[23], 5, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist(x2)P2"),Effect.ActivateClimate));
        deckHeavenly.Add(new Card(06, "Aetherion", descriptions[23], 5, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist(x2)P2"),Effect.ActivateClimate));
        deckHeavenly.Add(new Card(07, "Celestrox", descriptions[24], 7, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist2(x2)P2"),Effect.ActivateIncrese));
        deckHeavenly.Add(new Card(07, "Celestrox", descriptions[24], 7, Card.typecard.unit_silver, Card.typefield.D, Card.typefaction.heavenly, Resources.Load<Sprite>("Dist2(x2)P2"),Effect.ActivateIncrese));
        deckHeavenly.Add(new Card(08, "Nebulon", descriptions[25], 8, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee(x3)P2"),Effect.IncreseRouw));
        deckHeavenly.Add(new Card(08, "Nebulon", descriptions[25], 8, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee(x3)P2"),Effect.IncreseRouw));
        deckHeavenly.Add(new Card(09, "Divinara", descriptions[26], 3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee2(x2)P2"),Effect.MultiplicatePower));
        deckHeavenly.Add(new Card(09, "Divinara", descriptions[26], 3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee2(x2)P2"),Effect.MultiplicatePower));
        deckHeavenly.Add(new Card(09, "Divinara", descriptions[26], 3, Card.typecard.unit_silver, Card.typefield.M, Card.typefaction.heavenly, Resources.Load<Sprite>("Melee2(x2)P2"),Effect.MultiplicatePower));
        deckHeavenly.Add(new Card(10, "Luminastra", descriptions[27], 4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.heavenly, Resources.Load<Sprite>("Siege(x3)P2"),Effect.Average));
        deckHeavenly.Add(new Card(10, "Luminastra", descriptions[27], 4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.heavenly, Resources.Load<Sprite>("Siege(x3)P2"),Effect.Average));
        deckHeavenly.Add(new Card(10, "Luminastra", descriptions[27], 4, Card.typecard.unit_silver, Card.typefield.S, Card.typefaction.heavenly, Resources.Load<Sprite>("Siege(x3)P2"),Effect.Average));
        deckHeavenly.Add(new Card(11, "Eternae", descriptions[28], 0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Lure(x2)P2"),Effect.LureEffect));
        deckHeavenly.Add(new Card(11, "Eternae", descriptions[28], 0, Card.typecard.lure, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Lure(x2)P2"),Effect.LureEffect));
        //Cartas
        deckHeavenly.Add(new Card(12, "Hell", descriptions[12], Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.heavenly, Resources.Load<Sprite>("infiernoMelee(S)"),Effect.Climate));
        deckHeavenly.Add(new Card(13, "Fog of de dark", descriptions[13], Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.heavenly, Resources.Load<Sprite>("NieblaDist(S)"),Effect.Climate));
        deckHeavenly.Add(new Card(14, "Judgment Meteors", descriptions[14], Card.typecard.climate, Card.typefield.fclimate, Card.typefaction.heavenly, Resources.Load<Sprite>("LluviaMetSiege(S)"),Effect.Climate));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(15, "Rise of the Golden Wings", descriptions[15], Card.typecard.increase, Card.typefield.fincrease, Card.typefaction.heavenly, Resources.Load<Sprite>("AUM(C)x3"),Effect.Increse));
        deckHeavenly.Add(new Card(16, "The Dawn After the Sunset", descriptions[16], Card.typecard.clear, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Despeje(S)"),Effect.Clearance));
        deckHeavenly.Add(new Card(16, "The Dawn After the Sunset", descriptions[16], Card.typecard.clear, Card.typefield.MDS, Card.typefaction.heavenly, Resources.Load<Sprite>("Despeje(S)"),Effect.Clearance));
    }
}
