using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanPanneauController : MonoBehaviour, ITickable
{
    [SerializeField] private int difficulty;
    private int nbBalls;
    private int tickSecondPhase; //Le tick durant lequel est affiché le menu de sélection des réponses
    [SerializeField] private MoveBall[] balls;
    [SerializeField] private Color[] colors;

    [SerializeField] private GameObject awnserMenu;

    private int goodAwnser;

    private void Awake()
    {
        Ticker.Register(this);
        balls[0].SetYOffset(Random.Range(0f, 10f)); 
    }

    private int rand;
    private MoveBall tempBall;

    private void Start()
    {
        SetDifficulty();
        rand = -1;
    }

    private void SetDifficulty() 
    {
        switch (difficulty) 
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
        Debug.Log(Ticker.currentTick);
        if (Ticker.currentTick == 1)
        {
            LaunchBall(0);
        }
        if (Ticker.currentTick == 2) 
        {
            if (difficulty > 1) 
            {
                LaunchBall(1);
            }
        }
        if (Ticker.currentTick == 5) 
        {
            awnserMenu.SetActive(true);
        }
    }

    private int newRand;

    private void LaunchBall(int idx)
    {
        balls[idx].SetCanMove(true);
        RandomColorIndex(idx);
        goodAwnser = rand;
        balls[idx].GetComponent<SpriteRenderer>().color = colors[rand];
    }

    private void RandomColorIndex(int idx)
    {
        do
        {
            newRand = Random.Range(0, colors.Length - idx);
        } while (rand == newRand);
        rand = newRand;
    }

    public void CheckAwnser(int awnser) 
    {
        if (awnser == goodAwnser) GameController.FinishGame(true);
        else GameController.FinishGame(false);
    }
}
