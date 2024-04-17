using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CardToHand2 : MonoBehaviour
{
    public GameObject Hand2;
    public GameObject HandCard2;

    void Start()
    {
        Hand2 = GameObject.Find("HandP2");              //busca el panel Hand1
        HandCard2.transform.SetParent(Hand2.transform);  //Establece a Hand como el padre de HandCard
        HandCard2.transform.localScale = Vector3.one;   //Ajusta la escala x,y,z a 1 es decir que preserve su tamano original
        HandCard2.transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        HandCard2.transform.eulerAngles = new Vector3(25, 0, 0);

        ControlPanels controlPanels = Hand2.GetComponent<ControlPanels>();
        if (controlPanels != null)
        {
            controlPanels.cardInPanel.Add(HandCard2);
        }
        else
        {
            Debug.LogError("El componente ControlPanels no está adjunto al GameObject Hand.");
        }
    }
}
