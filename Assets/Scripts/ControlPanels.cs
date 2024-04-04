using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanels : MonoBehaviour
{
    public GameObject panelField;

    public bool CanPlaceCard(Card.typefield panel)
    {
        switch (panel)
        {
            case Card.typefield.M:
                if(panelField.name == "MeleeP1") return true;
                else return false;

            case Card.typefield.D:
                if (panelField.name == "DistanceP1") return true;
                else return false;

            case Card.typefield.S:
                if (panelField.name == "SiegeP1") return true;
                else return false;

            case Card.typefield.MS:
                if ((panelField.name == "MeleeP1")|| (panelField.name == "SiegeP1")) return true;
                else return false;

            case Card.typefield.DS:
                if ((panelField.name == "DistanceP1") || (panelField.name == "SiegeP1")) return true;
                else return false;

            case Card.typefield.MDS:
                if ((panelField.name == "MeleeP1")||(panelField.name == "DistanceP1")||(panelField.name == "SiegeP1")) return true;
                else return false;

            case Card.typefield.fincrease:
                if ((panelField.name == "IncreseM1") || (panelField.name == "IncreseD1") || (panelField.name == "IncreseS1")) return true;
                else return false;

            case Card.typefield.fclimate:
                if ((panelField.name == "ClimateZone")) return true;
                else return false;

            default: return false;
        }
    }
}
