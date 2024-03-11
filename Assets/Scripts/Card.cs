using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//[System.Serializable]

[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public int ID;                            // Me gustaria declarle mi amor pero solo puedo declarar variables :(
    public new string name; 
    public string description;

    public int power;

    public Sprite spriteImage;

    public typecard type;                     // establece si la carta es de tipo oro, plata, señuelo, aumento, lider, clima o despeje 
    public typefield pos_field;               // estable si la carta se coloca en la zona de cuerpo a cuerpo, distancia, asedio, aumento, clima o lider
    public typefaction faction;               // establece si la carta es de la faccion de las sombras o de los celestiales
    public typeclimate type_climate;          //establece si la carta  clima 

    public enum typecard { unit_silver, unit_gold, lure, leader, climate, increase, clear }
    public enum typefield { melee, distance, siege, MD, MS, DS, MDS, fincrease, fclimate, fleader }
    public enum typefaction { shadows, heavenly, none }
    public enum typeclimate { afectBB, afectD, afectS }

    public Card()
    {

    }

    public Card(int ID ,string name, string description, int power, typecard type, typefield pos_field, typefaction faction, Sprite SpriteImage) //constructor para cartas monstruo
    {
        this.ID = ID;
        this.name = name;
        this.description = description;
        this.power = power;
        this.type = type;
        this.pos_field = pos_field;
        this.faction = faction;
        spriteImage = SpriteImage;
    }
    public Card(int ID, string name, string description, typecard type, typefield pos_field, typefaction faction, Sprite SpriteImage) //constructor para cartas sin atk
    {
        this.ID= ID;
        this.name = name;
        this.description = description;
        this.type = type;
        this.pos_field = pos_field;
        this.faction = faction;
        spriteImage = SpriteImage;
    }
}

