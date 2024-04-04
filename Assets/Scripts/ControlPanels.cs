using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ControlPanels : MonoBehaviour
{
    public GameObject panelField;
    public bool CanPlaceCard(Card.typefield panel, Card.typefaction faction)
    {
        if ((faction == Card.typefaction.shadows))
        {
            switch (panel)
            {
                case Card.typefield.M:
                    if (panelField.name == "MeleeP1") return true;
                    else return false;

                case Card.typefield.D:
                    if (panelField.name == "DistanceP1") return true;
                    else return false;

                case Card.typefield.S:
                    if (panelField.name == "SiegeP1") return true;
                    else return false;

                case Card.typefield.MS:
                    if ((panelField.name == "MeleeP1") || (panelField.name == "SiegeP1")) return true;
                    else return false;

                case Card.typefield.DS:
                    if ((panelField.name == "DistanceP1") || (panelField.name == "SiegeP1")) return true;
                    else return false;

                case Card.typefield.MDS:
                    if ((panelField.name == "MeleeP1") || (panelField.name == "DistanceP1") || (panelField.name == "SiegeP1")) return true;
                    else return false;

                case Card.typefield.fincrease:
                    if ((panelField.name == "IncreseM1") || (panelField.name == "IncreseD1") || (panelField.name == "IncreseS1")) return true;
                    else return false;

                default: return false;
            }
        }
        if (faction == Card.typefaction.heavenly) 
        {
            switch (panel)
            {
                case Card.typefield.M:
                    if (panelField.name == "MeleeP2") return true;
                    else return false;

                case Card.typefield.D:
                    if (panelField.name == "DistanceP2") return true;
                    else return false;

                case Card.typefield.S:
                    if (panelField.name == "SiegeP2") return true;
                    else return false;

                case Card.typefield.MS:
                    if ((panelField.name == "MeleeP2") || (panelField.name == "SiegeP2")) return true;
                    else return false;

                case Card.typefield.DS:
                    if ((panelField.name == "DistanceP2") || (panelField.name == "SiegeP2")) return true;
                    else return false;

                case Card.typefield.MDS:
                    if ((panelField.name == "MeleeP2") || (panelField.name == "DistanceP2") || (panelField.name == "SiegeP2")) return true;
                    else return false;

                case Card.typefield.fincrease:
                    if ((panelField.name == "IncreseM2") || (panelField.name == "IncreseD2") || (panelField.name == "IncreseS2")) return true;
                    else return false;
                    
                default: return false;
            }
        }
        else
        {
            if ((panelField.name == "ClimateZone")) return true;
            else return false; 
        }    
    }
}
