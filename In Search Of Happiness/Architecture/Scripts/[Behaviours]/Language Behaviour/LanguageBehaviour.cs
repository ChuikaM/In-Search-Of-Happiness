using UnityEngine;
using UnityEngine.UI;

public class LanguageBehaviour : MonoBehaviour
{
	public static bool selectedEnglish = false;

    [SerializeField] private Toggle ToggleRussian;
    [SerializeField] private Toggle ToggleEnglish;

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
                selectedEnglish = true;
                ToggleEnglish.isOn = true;
                ToggleRussian.isOn = false;
                break;

			case Settings.SettingsLanguage.Russian:
				SetLanguageToRussian();
                selectedEnglish = false;
                ToggleEnglish.isOn = false;
                ToggleRussian.isOn = true;
                break;
			default:
				SettingsManagerIdentity.Default(); 
			break;
		}
    }

	public void SetLanguage(bool enabled)
	{
		if(!selectedEnglish)
		{
            SettingsManagerIdentity.SetLanguageToEnglish();
            ToggleEnglish.isOn = true;
            ToggleRussian.isOn = false;
            selectedEnglish = true;
        }
		else
		{
            SettingsManagerIdentity.SetLanguageToRussian();
            ToggleEnglish.isOn = false;
            ToggleRussian.isOn = true;
            selectedEnglish = false;
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
	