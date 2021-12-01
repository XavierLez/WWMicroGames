using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour//, ITickable
{
	private static string currentScene;
	private static bool gameFinished = false;
	public static void FinishGame(bool result)
	{
		gameFinished = true;
		Ticker.Unregister();
	}

	private static void LoadMicroGame(string sceneName)
	{
		currentScene = sceneName;
		SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
	}
	
	
	
	
	
	/// --- NON STATIC
	
	private GameState state = GameState.MACRO;

	[SerializeField] private string[] sceneNames;

	private void Start()
	{
		StartCoroutine(MainLoop());
	}


	private IEnumerator MainLoop()
	{
		LoadMicroGame(sceneNames[Random.Range(0, sceneNames.Length)]);
		while (true) 
		{
			if (gameFinished)
			{
				if (state == GameState.MICRO)
				{
					yield return SceneManager.UnloadSceneAsync(currentScene);
					state = GameState.MACRO;
				}
				else
				{
					LoadMicroGame(sceneNames[Random.Range(0, sceneNames.Length)]);
					state = GameState.MICRO;
				}
				
				gameFinished = false;
			}

			// Ticker.Register(MacroGame)
			// MacroGame

			yield return null;
		}
	}

	/*
	private void Awake()
	{
		Ticker.Register(this);
	}

	public void OnTick()
	{
		Debug.Log("GameController is TICKING");
	}*/

	private enum GameState
	{
		MACRO,
		MICRO
	}
}