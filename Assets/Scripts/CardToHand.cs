using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject HandCard;

    public GameObject LeaderZ;
    public GameObject LeaderCard;

    void Start()
    {
        if (HandCard.GetComponent<DisplayCard>().currentCard.type != Card.typecard.leader)
        {
            Hand = GameObject.Find("HandP1");
            HandCard.transform.SetParent(Hand.transform);
            HandCard.transform.localScale = Vector3.one;
            HandCard.transform.position = new Vector3(transform.position.x, transform.position.y, -40);
            HandCard.transform.eulerAngles = new Vector3(25, 0, 0);

            ControlPanels controlPanels = Hand.GetComponent<ControlPanels>();
            ControlPanelsAdd(HandCard, controlPanels);
        }
        else
        {
            LeaderZ = GameObject.Find("LeaderZone1");

            LeaderCard.transform.SetParent(LeaderZ.transform);
            LeaderCard.transform.localScale = Vector3.one;
            LeaderCard.transform.position = new Vector3(transform.position.x, transform.position.y, -40);
            LeaderCard.transform.eulerAngles = new Vector3(25,0, 0);

            LeaderCard.GetComponent<Drag>().enabled = false;
            LeaderCard.GetComponent<DisplayCard>().onField = true;
            ControlPanels controlPanels = LeaderZ.GetComponent<ControlPanels>();
            ControlPanelsAdd(LeaderCard, controlPanels);
        }
    }
    void ControlPanelsAdd(GameObject card, ControlPanels controlPanels)
    {
        if (controlPanels != null) { controlPanels.cardInPanel.Add(card); }
    }
}
