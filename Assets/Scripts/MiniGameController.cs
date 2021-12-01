using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour, ITickable
{
    [SerializeField] private UIManager uiManager;
    //[SerializeField] private SoundManager soundManager;

    [SerializeField] private int difficulty;
    //[SerializeField] private float tickTime;
    private int nbButtonPerSign;
    private int nbTickMax;
    [SerializeField] private List<GameObject> signs;
    [SerializeField] private Sprite[] xboxButtonSprites = new Sprite[4];
    [SerializeField] private string[] inputs = new string[] { "A", "B", "X", "Y" };
    public string[,] trueInputs;
    public int[] inputStreak;

    private SpriteRenderer buttonSpriteRenderer;
    private int rand;
    private int trueSign;

    private bool hasStarted;
    private bool hasEnded;
    private bool result;

    private void Awake()
    {
        hasStarted = false;

        SetDifficulty();

        InitializeArray();

        CreateSigns();
    }

    public void Start() 
    {
        Ticker.Register(this);
        uiManager.UpdateTimer(nbTickMax - Ticker.currentTick);
        hasStarted = true;

    }

    /* IEnumerator TimerCoroutine(float t) 
     {
         yield return new WaitForSeconds(t);
         nbTick++;
         uiManager.UpdateTimer(nbTickMax - nbTick);

         if (nbTick < nbTickMax)
         {
             StartCoroutine(TimerCoroutine(tickTime));
         }
         else 
         {
             EndGame(false);
         }
     }
    */
    private void SetDifficulty()
    {
        switch (difficulty)
        {
            case 1:
                nbButtonPerSign = 3;
                nbTickMax = 8;
                break;
            case 2:
                nbButtonPerSign = 4;
                nbTickMax = 6;
                break;
            case 3:
                nbButtonPerSign = 4;
                nbTickMax = 5;
                break;
            default:
                nbButtonPerSign = 3;
                nbTickMax = 8;
                break;
        }
    }

    private void InitializeArray()
    {
        trueInputs = new string[signs.Count, nbButtonPerSign];
        inputStreak = new int[signs.Count];

        for (int i = 0; i < inputStreak.Length; i++)
        {
            inputStreak[i] = 0;
        }
    }

    private void CreateSigns()
    {
        trueSign = Random.Range(0, signs.Count);
        uiManager.InitializeTrueSign(trueSign);

        int s = 0;
        foreach (var sign in signs)
        {
            for (int i = 0; i < nbButtonPerSign; i++)
            {
                buttonSpriteRenderer = sign.transform.GetChild(i).GetComponent<SpriteRenderer>();
                rand = Random.Range(0, xboxButtonSprites.Length);
                buttonSpriteRenderer.sprite = xboxButtonSprites[rand];
                trueInputs[s,i] = inputs[rand];
            }
            s++;
        }
    }

    public void CheckInputsOrder(string input) 
    {
        if (trueInputs[trueSign, inputStreak[trueSign]].Equals(input))
        {
            //soundManager.PlayShotSound();
            if (++inputStreak[trueSign] == nbButtonPerSign) 
            {
                EndGame(true);
            }
        }
        else 
        {
            EndGame(false);
        }

        DebugInputStreak();
    }

    private void EndGame(bool result) 
    {
        StopAllCoroutines();
        this.hasEnded = true;
        this.result = result;
        uiManager.EnableEndScreen(result);
    }

    private void DebugInputStreak() 
    {
        Debug.Log("_________________");
        for (int i = 0; i < inputStreak.Length; i++)
        {
            Debug.Log("panneau " + i + " : " + inputStreak[i]);
        }
    }

    public int GetTrueSign() 
    {
        return this.trueSign;
    }

    public bool HasStarted() 
    {
        return this.hasStarted;
    }

    public int GetNbTick() 
    {
        return Ticker.currentTick;
    }

    public int GetNbTickMax() 
    {
        return this.nbTickMax;
    }

    public void OnTick()
    {
        Debug.Log("has ended : " + hasEnded);

        if (!hasEnded) 
        {
            Debug.Log("timer");
            uiManager.UpdateTimer(nbTickMax - Ticker.currentTick);
        }
        if (Ticker.currentTick == nbTickMax) EndGame(false);
        if (Ticker.currentTick == 8) GameController.FinishGame(result);
    }
}
