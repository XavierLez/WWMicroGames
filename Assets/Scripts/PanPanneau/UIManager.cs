using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] signSprites = new Sprite[3];
    [SerializeField] private SpriteRenderer trueSigneSprite;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMP_Text resultText;

    public void InitializeTrueSign(int trueSign)
    {
        trueSigneSprite.sprite = signSprites[trueSign];
    }

    public void UpdateTimer(int nbTickLeft) 
    {
        timerText.text = nbTickLeft.ToString();
    }

    public void EnableEndScreen(bool result) 
    {
        if (result) resultText.text = "Victoire !";
        else resultText.text = "Défaite !";

        endScreen.SetActive(true);
    }
}
