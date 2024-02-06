using UnityEngine;

public class SettingsBehaviour : MonoBehaviour
{
	private SettingsManager SettingsManagerIdentity;

	private void OnEnable()
	{
        SettingsManagerIdentity = GameObject.FindObjectOfType<SettingsManager>();
        Load();
    }

	private void Load()
	{
		if(FileProvider.IsFileExist("SavedSettings.json"))
		{
			FileProvider.GetObjectFromJSONFile<Settings>(SettingsManagerIdentity.SavedSettings, "SavedSettings.json");
		}
		else
		{
			FileProvider.SaveObjectToJSONFile<Settings>(SettingsManagerIdentity.SavedSettings,"SavedSettings.json");
			SettingsManagerIdentity.SavedSettings = SettingsManagerIdentity.DefaultSettings;
		}
	}

	public void Save()
	{
		FileProvider.SaveObjectToJSONFile<Settings>(SettingsManagerIdentity.SavedSettings,"SavedSettings.json");
	}
}
	