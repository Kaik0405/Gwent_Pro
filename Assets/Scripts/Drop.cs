    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

public class Drop : MonoBehaviour,IDropHandler
{
    public ControlPanels controlPanels;
    private AudioSource audioActivCard;


    void Start()
    {
        audioActivCard = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Drag drg = eventData.pointerDrag.GetComponent<Drag>();
        if (drg != null)
        {
            Debug.Log("Es Colocable: "+ controlPanels.CanPlaceCard(drg.cardType, drg.cardFact));
            Debug.Log("Lugar en el campo: " + drg.cardType + "\nFaccion de la carta: " + drg.cardFact);
            if (controlPanels.CanPlaceCard(drg.cardType,drg.cardFact))
            {
                drg.parentReturn = this.transform;

                if(audioActivCard != null)
                {
                    audioActivCard.Play();
                }
            }
        }
    }
}