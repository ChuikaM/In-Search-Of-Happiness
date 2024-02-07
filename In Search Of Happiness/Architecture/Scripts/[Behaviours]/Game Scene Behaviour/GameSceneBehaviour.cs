using UnityEngine;

public class GameSceneBehaviour : MonoBehaviour
{
	public void LoadScene(int i)
	{
        GameSceneManager.Instance.LoadScene(i);
	}

	public void LoadSavedScene()
	{
		GameSceneManager.Instance.LoadSavedScene();
	}
	
	public void StartLoadScene()
	{
		GameSceneManager.Instance.StartLoadScene();
	}
	
	public void Restart()
	{
		GameSceneManager.Instance.Restart();
	}
	
	public void Resume()
	{
		GameSceneManager.Instance.Resume();
	}
	
	public void Pause()
	{
		GameSceneManager.Instance.Pause();
	}
	
	public void Quit()
	{
		GameSceneManager.Instance.Quit();
	}
	
	public void Next()
	{
		GameSceneManager.Instance.Next();
	}
	
	public void Home()
	{
		GameSceneManager.Instance.Home();
	}
}