using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack2 : MonoBehaviour
{
    public GameObject cardBack2;

    void Update()
    {
        if (DisplayCard2.staticCardBack2)
        {
            cardBack2.SetActive(true);
        }
        else
        {
            cardBack2.SetActive(false);
        }
    }
}
