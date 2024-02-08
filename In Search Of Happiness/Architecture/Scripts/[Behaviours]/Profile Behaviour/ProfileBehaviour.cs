using UnityEngine;
using UnityEngine.UI;

public class ProfileBehaviour : MonoBehaviour
{
	[SerializeField] private Toggle ToggleFPS;

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
		SettingsManager.Identity.FPSLabelGameObject.SetActive(SettingsManager.Identity.SavedSettings.ShowFPS);		
    }

	public void ToggleShowFPS(bool enabled)
	{
        SettingsManager.Identity.SavedSettings.ShowFPS = enabled;
        SettingsManager.Identity.FPSLabelGameObject.SetActive(enabled);
        SettingsManager.Identity.SaveToJSON<Settings>(SettingsManager.Identity.SavedSettings, "SavedSettings.json");
    }
	
	public void Default()
	{
        SettingsManager.Identity.SavedSettings.ShowFPS = SettingsManager.Identity.DefaultSettings.ShowFPS;
        SettingsManager.Identity.FPSLabelGameObject.SetActive(SettingsManager.Identity.DefaultSettings.ShowFPS);
        SettingsManager.Identity.SaveToJSON<Settings>(SettingsManager.Identity.DefaultSettings, "SavedSettings.json");
    }	
}
	