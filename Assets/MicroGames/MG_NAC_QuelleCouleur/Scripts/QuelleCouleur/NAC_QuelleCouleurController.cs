using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAC_QuelleCouleurController : MonoBehaviour, ITickable
{
    [SerializeField] private int difficulty;
    private int nbBalls;
    private int tickSecondPhase; //Le tick durant lequel est affich� le menu de s�lection des r�ponses
    [SerializeField] private NAC_MoveBall[] balls;
    //[SerializeField] private Color[] colors;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private NAC_AnswerManager answerManager;
    [SerializeField] private GameObject answerMenu;
    [SerializeField] private GameObject defeat, victory;

    private int[] goodColors;
    private bool result;
    private int goodAnswer;
    public AudioClip audioClip,audioClip2;

    private void Awake()
    {
        GameManager.Register();
        GameController.Init(this);
        GameController.Register();
        balls[0].SetYOffset(Random.Range(0f, 10f));

        goodColors = new int[] {-1,-1};
    }

    private int rand;

    private void Start()
    {
        SetDifficulty();
        rand = -1;
      
    }

    private void SetDifficulty() 
    {
        switch (GameController.difficulty) 
        {
            case 1:
                nbBalls = 1;
                break;
            case 2:
                nbBalls = 2;
                break;
            case 3:
                nbBalls = 2;
                break;
            default:
                nbBalls = 1;
                break; 
        }
    }
    public void OnTick()
    {
        if (GameController.currentTick == 1)
        {
            LaunchBall(0);
            if(GameController.difficulty > 1)
                LaunchBall(1);
        }
        if (GameController.currentTick == 2) 
        {
            answerManager.GenerateAnswers(goodColors);
        }
        if (GameController.currentTick == 3) 
        {
            answerMenu.SetActive(true);
        }
        if (GameController.currentTick == 8) 
        {
            GameController.FinishGame(result);
        }
    }

    private int newRand;

    private void LaunchBall(int idx)
    {
        AudioManager.PlaySound(audioClip,1);
        balls[idx].SetCanMove(true);
        RandomColorIndex(idx);
        goodColors[idx] = rand;
        balls[idx].GetComponent<SpriteRenderer>().sprite = sprites[rand];
    }

    private void RandomColorIndex(int idx)
    {
        do
        {
            newRand = Random.Range(0, sprites.Length - idx);
        } while (rand == newRand);
        rand = newRand;
    }

    public void CheckAwnser(int awnser) 
    {
        goodAnswer = answerManager.GetGoodAnswer();
        if (awnser == goodAnswer)
        {
            GameController.FinishGame(true);
            answerMenu.SetActive(false);
            victory.SetActive(true);
            Debug.Log("TRUE");
        }
        else 
        {
            GameController.FinishGame(false);
            Debug.Log("FALSE");
            answerMenu.SetActive(false);
            defeat.SetActive(true);
            AudioManager.PlaySound(audioClip2, 1);
        }
    }
}
