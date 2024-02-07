using UnityEngine;
using UnityEngine.UI;

public class ProfileBehaviour : MonoBehaviour
{
	[SerializeField] private Toggle ToggleFPS;

	private GameObject fpsLabel;

    private void OnEnable()
	{
        Load();
	}

    private void Load()
	{
		if(ToggleFPS == null)
		{
			return;
		}	
		ToggleFPS.isOn = SettingsManager.Identity.SavedSettings.ShowFPS;
		fpsLabel = GameObject.Find("FPS Label");
		fpsLabel.SetActive(SettingsManager.Identity.SavedSettings.ShowFPS);
    }

	public void ToggleShowFPS(bool enabled)
	{
        SettingsManager.Identity.SavedSettings.ShowFPS = enabled;
        fpsLabel.SetActive(enabled);
    }
	
	public void Default()
	{
        SettingsManager.Identity.SavedSettings.ShowFPS = SettingsManager.Identity.DefaultSettings.ShowFPS;
        fpsLabel.SetActive(SettingsManager.Identity.DefaultSettings.ShowFPS);
    }	
}
	