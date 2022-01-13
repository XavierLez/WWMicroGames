using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAC_EnRappelController : MonoBehaviour, ITickable
{

    [SerializeField] private GameObject[] easyLayouts;
    [SerializeField] private GameObject[] mediumLayouts;
    [SerializeField] private GameObject[] hardLayouts;

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
                easyLayouts[Random.Range(0, easyLayouts.Length)].SetActive(true);
                break;
            case 2:
                mediumLayouts[Random.Range(0, easyLayouts.Length)].SetActive(true);
                break;
            case 3:
                hardLayouts[Random.Range(0, easyLayouts.Length)].SetActive(true);
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
