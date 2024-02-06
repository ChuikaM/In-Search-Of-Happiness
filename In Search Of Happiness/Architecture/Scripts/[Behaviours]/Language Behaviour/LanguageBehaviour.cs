using UnityEngine;

public class LanguageBehaviour : MonoBehaviour
{
	private SettingsManager SettingsManagerIdentity;
	private void OnEnable()
	{
		SettingsManagerIdentity = GameObject.FindObjectOfType<SettingsManager>();
        Load();
	}

    private void Load()
	{
		if(SettingsManagerIdentity == null)
		{
			return;
		}

        switch (SettingsManagerIdentity.SavedSettings.Language)
		{
			case Settings.SettingsLanguage.English:
				SetLanguageToEnglish();
            break;

			case Settings.SettingsLanguage.Russian:
				SetLanguageToRussian();
            break;
			default:
				SettingsManagerIdentity.Default(); 
			break;
		}
    }

	public void SetLanguageToEnglish()
	{
        SettingsManagerIdentity.SetLanguageToEnglish();
    }
	
	public void SetLanguageToRussian()
	{
        SettingsManagerIdentity.SetLanguageToRussian();
    }
}
	