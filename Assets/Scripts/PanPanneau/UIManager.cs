using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text trueSignText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMP_Text resultText;

    public void InitializeTrueSign(int trueSign)
    {
        trueSignText.text = (trueSign + 1).ToString();
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
