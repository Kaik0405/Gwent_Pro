using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDeckCard2 : MonoBehaviour
{
    public TMP_Text TextcantOfCardD2;
    public TMP_Text TextcantOfCardGY2;

    public int CardCount2;
    public int CardCountGY2;

    void Update()
    {
        if (TextcantOfCardD2 != null)
        {
            CardCount2 = GameManager.player2.deck.Count - 1;
            TextcantOfCardD2.text = CardCount2.ToString();
        }
        if (TextcantOfCardGY2 != null)
        {
            CardCountGY2 = GameManager.player2.graveyard.Count;
            TextcantOfCardGY2.text = CardCountGY2.ToString();
        }
    }
}
