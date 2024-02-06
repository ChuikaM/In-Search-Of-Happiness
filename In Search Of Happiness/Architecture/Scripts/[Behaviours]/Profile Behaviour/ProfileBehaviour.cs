using UnityEngine;
using UnityEngine.UI;

public class ProfileBehaviour : MonoBehaviour
{
	private SettingsManager SettingsManagerIdentity;

	[SerializeField] private Toggle ToggleFPS;

	private void OnEnable()
	{
		SettingsManagerIdentity = GameObject.FindObjectOfType<SettingsManager>();
        Load();
	}

    private void Load()
	{
		if(ToggleFPS == null)
		{
			return;
		}	
		ToggleFPS.isOn = SettingsManagerIdentity.SavedSettings.ShowFPS;
    }

	public void ToggleShowFPS(bool enabled)
	{
		SettingsManagerIdentity.SavedSettings.ShowFPS = enabled;
        SettingsManagerIdentity.FPSLabel.SetActive(SettingsManagerIdentity.SavedSettings.ShowFPS);
    }
	
	public void Default()
	{
		SettingsManagerIdentity.SavedSettings.ShowFPS = SettingsManagerIdentity.DefaultSettings.ShowFPS;
	}	
}
	