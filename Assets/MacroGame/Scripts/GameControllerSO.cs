using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameControllerSO : ScriptableObject
{
    [Range(0f, 10f)]
    public float currenGameSpeed = 1f;
}
