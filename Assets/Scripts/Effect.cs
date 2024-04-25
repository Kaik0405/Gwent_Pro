using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Effect
{
    public static void Increse(params object[] paramtry)           // Aumenta el poder de ataque de una fila en el campo del jugador por 10 pts
    {

    }
    public static void DestroyCardStrong(params object[] paramtry) // Destruye la carta mas fuerte en el campo
    {

    }
    public static void DestroyCardWeak(params object[] paramtry)   // Destrye la carta mas debil del adversario
    {

    }
    public static void DrawCard(params object[] paramtry)          // roba una carta
    {
        if (paramtry[0] is Player player) player.Draw();
    }
    public static void Climate(params object[] paramtry)           // disminuye el poder de las cartas de unidad a 1 de la misma fila de ambos jugadores
    {
        
    }
    public static void ClearRowLess(params object[] paramtry)      // Limpia la fila con menos unidades
    {

    }
    public static void ActivateIncrese(params object[] paramtry)   // Activa una carta de Aumento
    {

    }
    public static void ActivateClimate(params object[] paramtry)   // Activa un clima 
    {

    }
    public static void MultiplicatePower(params object[] paramtry) // Multiplica n el ataque de la carta siendo n la cantidad de cartas iguales a ella en el campo
    {

    }
    public static void Average(params object[] paramtry)           // Calcula el promedio de todas las cartas en el campo y luego iguala el poder de todas las cartas en el campo a ese promedio
    {

    }          
    public static void IncreseRouw(params object[] paramtry)       // Aumenta en 2 los puntos de ataque de la fila con menos poder en el campo del jugador
    {

    }
    public static void LureEffect(params object[] paramtry)        // Cuando es colocada en el campo manda a la mano una carta   
    {

    }
    public static void Clearance(params object[] paramtry)         // Quita un clima 
    {

    }
    public static void LeaderEffect1(params object[] paramtry)     // Robar una carta extra en cada ronda
    {

        if (paramtry[0] is Player player)
        {
            player.Draw();
            Debug.Log("Efecto de lider de player1 Activado");
        }
    }
    public static void LeaderEffect2(params object[] paramtry)     // Robar una carta extra al inicio   
    {
        if (paramtry[0] is Player player)
        {
            player.Draw();
            Debug.Log("Efecto de lider de player2 Activado");
        }
    }



}
