using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDeckCard : MonoBehaviour
{
    public TMP_Text TextcantOfCardD;
    public TMP_Text TextcantOfCardGY;

    public int CardCount;
    public int CardCountGY;

    void Update()
    {
        if (TextcantOfCardD != null)
        {
            CardCount = GameManager.player1.deck.Count - 1;
            TextcantOfCardD.text = CardCount.ToString();
        }
        if (TextcantOfCardGY != null)
        {
            CardCountGY = GameManager.player1.graveyard.Count;
            TextcantOfCardGY.text = CardCountGY.ToString();
        }
    }
}
