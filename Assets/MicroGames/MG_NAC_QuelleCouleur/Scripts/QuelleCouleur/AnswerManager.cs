using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    [SerializeField] private QuelleCouleurController qcController;

    [SerializeField] private string[] answerText;
    [SerializeField] private TMP_Text[] buttonTexts;
    private int goodAnswer;
    private int answer;

    private void Start()
    {
        goodAnswer = Random.Range(0,3);
    }

    private int falseAnswer;

    public void GenerateAnswers(int[] goodColors) 
    {
        Debug.Log(goodColors[0] +" / "+ goodColors[1]);
        Debug.Log("Good answer = " + goodAnswer);
        falseAnswer = 1;
        for (int i = 0; i < buttonTexts.Length; i++)
        {
            if (i == goodAnswer)
            {
                buttonTexts[i].text = answerText[goodColors[0]] + (GameController.difficulty > 1 ? "/" + answerText[goodColors[1]] : "");
            }
            else
            {
                buttonTexts[i].text = answerText[(goodColors[0] + falseAnswer) % answerText.Length] + (GameController.difficulty > 1 ? "/" + answerText[(goodColors[1] + falseAnswer) % answerText.Length] : "");
                falseAnswer++;
            }
        }
    }

    public int GetGoodAnswer() 
    {
        return goodAnswer;
    }

    public void Answer1() 
    {
        qcController.CheckAwnser(0);
    }

    public void Anwser2() 
    {
        qcController.CheckAwnser(1);
    }
    public void Anwser3()
    {
        qcController.CheckAwnser(2);
    }
}
