using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CardToHand2 : MonoBehaviour
{
    public GameObject Hand2;
    public GameObject HandCard2;

    public GameObject LeaderZ2;
    public GameObject LeaderCard2;

    void Start()
    {
        if (HandCard2.GetComponent<DisplayCard2>().currentCard2.type != Card.typecard.leader)
        {
            Hand2 = GameObject.Find("HandP2");
            HandCard2.transform.SetParent(Hand2.transform);
            HandCard2.transform.localScale = Vector3.one;
            HandCard2.transform.position = new Vector3(transform.position.x, transform.position.y, -40);
            HandCard2.transform.eulerAngles = new Vector3(25, 0, 0);

            ControlPanels controlPanels = Hand2.GetComponent<ControlPanels>();
            ControlPanelsAdd(HandCard2, controlPanels);
        }
        else
        {
            LeaderZ2 = GameObject.Find("LeaderZone2");

            LeaderCard2.transform.SetParent(LeaderZ2.transform);
            LeaderCard2.transform.localScale = Vector3.one;
            LeaderCard2.transform.position = new Vector3(transform.position.x, transform.position.y, -40);
            LeaderCard2.transform.eulerAngles = new Vector3(25, 0, 0);

            LeaderCard2.GetComponent<Drag>().enabled = false;
            LeaderCard2.GetComponent<DisplayCard2>().onField2 = true;
            ControlPanels controlPanels = LeaderZ2.GetComponent<ControlPanels>();
            ControlPanelsAdd(LeaderCard2, controlPanels);
        }

    }
    void ControlPanelsAdd(GameObject card,ControlPanels controlPanels)
    {
        if (controlPanels != null) { controlPanels.cardInPanel.Add(card); } 
    }
}
