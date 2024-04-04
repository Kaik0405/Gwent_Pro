using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDeckCard2 : MonoBehaviour
{
    public TMP_Text TextcantOfCardD2;
    public int CardCount2;

    void Update()
    {
        CardCount2 = playerDeck2.deckSize2 - 1;
        TextcantOfCardD2.text = CardCount2.ToString();
    }
}
