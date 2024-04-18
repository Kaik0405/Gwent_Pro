using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ControlPanels : MonoBehaviour
{
    public GameObject panelField;
    public List<GameObject> cardInPanel = new List<GameObject>();

    public bool CanPlaceCard(Card.typefield panel, Card.typefaction faction) //Metodo que es llamado para verificar la posicion en el campo que ocupa la carta
    {
        if ((faction == Card.typefaction.shadows) && (GameManager.player1.turn) && !(Drop.invoke))
        {
            switch (panel)
            {
                case Card.typefield.M:
                    if (((panelField.name == "MeleeP1") & (cardInPanel.Count < 5)) || (panelField.name == "HandP1"))
                    {
                        return true;
                    }     
                    else return false;


                case Card.typefield.D:
                    if (((panelField.name == "DistanceP1") & (cardInPanel.Count < 5)) || (panelField.name == "HandP1"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.S:
                    if (((panelField.name == "SiegeP1") & (cardInPanel.Count < 5)) || (panelField.name == "HandP1"))
                    {
                        return true;
                    }
                    else return false;
                
                case Card.typefield.MD:
                    if (((panelField.name == "MeleeP1") & (cardInPanel.Count < 5)) || ((panelField.name == "DistanceP1") & (cardInPanel.Count < 5)) || (panelField.name == "HandP1"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.MS:
                    if (((panelField.name == "MeleeP1") & (cardInPanel.Count < 5)) || ((panelField.name == "SiegeP1") & (cardInPanel.Count < 5)) || (panelField.name == "HandP1"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.DS:
                    if (((panelField.name == "DistanceP1") & (cardInPanel.Count < 5)) || ((panelField.name == "SiegeP1") & (cardInPanel.Count < 5)) || (panelField.name == "HandP1"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.MDS:
                    if (((panelField.name == "MeleeP1") & (cardInPanel.Count < 5)) || ((panelField.name == "DistanceP1") & (cardInPanel.Count < 5)) || ((panelField.name == "SiegeP1") & (cardInPanel.Count < 5)) || (panelField.name == "HandP1"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.fincrease:
                    if (((panelField.name == "IncreseM1") & (cardInPanel.Count < 1)) || ((panelField.name == "IncreseD1") & (cardInPanel.Count < 1)) || ((panelField.name == "IncreseS1") & (cardInPanel.Count < 1)) || (panelField.name == "HandP1"))
                    {
                        return true;
                    }
                    else return false;
                 
                case Card.typefield.fclimate:
                    if ((panelField.name == "ClimateZone") & (cardInPanel.Count < 3))
                    {
                        return true;
                    }
                    else return false;

                default: return false;
            }
        }
        if ((faction == Card.typefaction.heavenly) && (GameManager.player2.turn) && !(Drop.invoke))
        {
            switch (panel)
            {
                case Card.typefield.M:
                    if (((panelField.name == "MeleeP2") & (cardInPanel.Count < 5)) || (panelField.name == "HandP2"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.D:
                    if (((panelField.name == "DistanceP2") & (cardInPanel.Count < 5)) || (panelField.name == "HandP2"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.S:
                    if (((panelField.name == "SiegeP2") & (cardInPanel.Count < 5)) || (panelField.name == "HandP2"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.MD:
                    if (((panelField.name == "MeleeP2") & (cardInPanel.Count < 5)) || ((panelField.name == "DistanceP2") & (cardInPanel.Count < 5)) || (panelField.name == "HandP2"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.MS:
                    if (((panelField.name == "MeleeP2") & (cardInPanel.Count < 5)) || ((panelField.name == "SiegeP2") & (cardInPanel.Count < 5)) || (panelField.name == "HandP2"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.DS:
                    if (((panelField.name == "DistanceP2") & (cardInPanel.Count < 5)) || ((panelField.name == "SiegeP2") & (cardInPanel.Count < 5)) || (panelField.name == "HandP2"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.MDS:
                    if (((panelField.name == "MeleeP2")&(cardInPanel.Count<5)) || ((panelField.name == "DistanceP2") & (cardInPanel.Count < 5)) || ((panelField.name == "SiegeP2") & (cardInPanel.Count < 5)) || (panelField.name == "HandP2"))
                    {
                        return true;
                    }
                    else return false;

                case Card.typefield.fincrease:
                    if (((panelField.name == "IncreseM2") & (cardInPanel.Count < 1)) || ((panelField.name == "IncreseD2") & (cardInPanel.Count < 1)) || ((panelField.name == "IncreseS2") & (cardInPanel.Count < 1)) || (panelField.name == "HandP2"))
                    {
                        return true;
                    }
                    else return false;
                case Card.typefield.fclimate:
                    if ((panelField.name == "ClimateZone") && (cardInPanel.Count < 3))
                    {
                        return true ;
                    }
                    else return false;

                default: return false;
            }
        }
        else
        {
            return false; 
        }    
    } 

    public void AddCardToPanelHand(GameObject card)
    {
        cardInPanel.Add(card);
    }

}
