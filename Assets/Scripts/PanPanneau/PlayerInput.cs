using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private MiniGameController miniGameController;

    void Update()
    {
        if (miniGameController.HasStarted() && !miniGameController.GetHasEnded())
        {
            if (Input.GetButtonDown("A"))
            {
                miniGameController.CheckInputsOrder("A");
            }
            if (Input.GetButtonDown("B"))
            {
                miniGameController.CheckInputsOrder("B");
            }
            if (Input.GetButtonDown("X"))
            {
                miniGameController.CheckInputsOrder("X");
            }
            if (Input.GetButtonDown("Y"))
            {
                miniGameController.CheckInputsOrder("Y");
            }
        }
    }
}
