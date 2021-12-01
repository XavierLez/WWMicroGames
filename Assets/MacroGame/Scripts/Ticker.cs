using System.Collections;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public interface ITickable
{
    void OnTick();
}

public class Ticker : MonoBehaviour
{
    public static float gameSpeed { get; private set; }
    
    public static float deltaTick => 1f / gameSpeed;
    public static int currentTick { get; private set; }
    [CanBeNull] private static ITickable tickable;
    private static Ticker instance;
    
    public static void Register(ITickable t)
    {
        if (tickable != null) return;
        
        if (instance == null)
            new GameObject(("Ticker")).AddComponent<Ticker>();

        tickable = t;
        ResetTick();

    }

    public static void Unregister()
    {
        tickable = null;
    }

    private static void ResetTick()
    {
        currentTick = 0;
    }
    
    
    private GameControllerSO gameControllerSO;
    
   private void Awake()
   { 
       gameControllerSO = Resources.LoadAll<GameControllerSO>("").First();
       gameSpeed = 1f;
       instance = this;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            tickable?.OnTick();

            gameSpeed = gameControllerSO.currenGameSpeed;
            yield return new WaitForSeconds(deltaTick);
            currentTick++;
        }
        
    }
}
