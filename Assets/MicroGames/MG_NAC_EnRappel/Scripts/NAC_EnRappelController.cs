using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAC_EnRappelController : MonoBehaviour, ITickable
{

    private bool hasEnded;

    private void Awake()
    {
        hasEnded = false;
        GameManager.Register();
        GameController.Init(this);
    }

    private void Start()
    {
        SetDifficulty();
    }

    private void SetDifficulty() 
    {
        switch (GameController.difficulty) 
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }

    public void CheckEndGame(bool result) 
    {
        hasEnded = true;
        if (result)
        {
            GameController.FinishGame(true);
            Debug.Log("True");
        }
        else 
        {
            GameController.FinishGame(false);
            Debug.Log("False");
        }
    }


    public void OnTick()
    {
        Debug.Log(GameController.currentTick);
        if (GameController.currentTick == 5) 
        {
            GameController.FinishGame(false);
        }
    }

    public bool getHasEnded() 
    {
        return hasEnded;
    }

}
