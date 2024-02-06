using UnityEngine;

public class GameSceneBehaviour : MonoBehaviour
{
	private GameSceneManager gameSceneManager;
	private void Start()
	{
		gameSceneManager = FindObjectOfType<GameSceneManager>();
	}
	
	public void LoadScene(int i)
	{
		gameSceneManager.LoadScene(i);
	}
	
	public void StartLoadScene()
	{
		gameSceneManager.StartLoadScene();
	}
	
	public void Restart()
	{
		gameSceneManager.Restart();
	}
	
	public void Resume()
	{
		gameSceneManager.Resume();
	}
	
	public void Pause()
	{
		gameSceneManager.Pause();
	}
	
	public void Quit()
	{
		gameSceneManager.Quit();
	}
	
	public void Next()
	{
		gameSceneManager.Next();
	}
	
	public void Home()
	{
		gameSceneManager.Home();
	}
}