using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateMicroGame : MonoBehaviour, ITickable
{
    void Start()
    {
        Ticker.Register(this);
    }

    public void OnTick()
    {
        if (Ticker.currentTick == 8)
        {
            // You can call FinishGame(result) whenever you want, this will end your game
            GameController.FinishGame(true);
        }
    }
}
