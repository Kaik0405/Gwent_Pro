using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDeckCard : MonoBehaviour
{
    public TMP_Text TextcantOfCardD;
    public int CardCount;

    void Update()
    {
        //CardCount = GameManager.player1.deck.Count - 1;
        TextcantOfCardD.text = CardCount.ToString();
    }
}
