using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	public static GameSceneManager Instance;
	public int SceneIndex = 0;

    public void Init()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
	
    public void Restart()
    {		
		LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	
	public void Next()
    {
        SettingsManager.Identity.SaveToBF(Instance);
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	
	public void Home()
	{
        LoadScene(0);
	}

    public void LoadSavedScene()
    {
        Instance.LoadScene(Instance.SceneIndex);
    }
	
    public void LoadScene(int i)
    {
        if (SceneIndex > SceneManager.sceneCountInBuildSettings)
		{
			SceneIndex = SceneManager.sceneCountInBuildSettings;
		}
		else
		{
			SceneIndex = i;
		}
		LoadScene("Load Scene");
    } 
	
	public void LoadScene(string nameOfScene)
    {		
        StartCoroutine(LoadAsync(nameOfScene));
    }
	
	public void StartLoadScene()
	{
		StartCoroutine(LoadAsync(SceneIndex));
	}  

    IEnumerator LoadAsync(int i)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(i);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            if(asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
            {
                asyncLoad.allowSceneActivation = true;
                Time.timeScale = 1;
            }
            yield return null;
        }
    }

	IEnumerator LoadAsync(string i)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(i);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            if(asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
            {
                asyncLoad.allowSceneActivation = true;
                Time.timeScale = 1;
            }
            yield return null;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
