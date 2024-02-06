using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;

public class SettingsManager : MonoBehaviour
{
	public static SettingsManager SettingsManagerIdentity;
    public Settings SavedSettings;
    public Settings DefaultSettings;

    [SerializeField] private AudioMixerGroup AudioMixer;
    public GameObject FPSLabel { get; private set; }

    private void Start()
    {
        FPSLabel = GameObject.Find("FPS Label");
        if(FPSLabel != null )
        {
            FPSLabel.SetActive(SavedSettings.ShowFPS);
        }
    }

    private void OnEnable()
	{
		if(SettingsManagerIdentity != null)
		{
			Destroy(this.gameObject);
			return;
		}

		SettingsManagerIdentity = this;

		if(FileProvider.IsFileExist("SavedSettings.json"))
		{
            SavedSettings = FileProvider.LoadObjectFromJSONFile<Settings>("SavedSettings.json");
        }
		else
		{
			FileProvider.SaveObjectToJSONFile<Settings>(SavedSettings, "SavedSettings.json");
		}

		if(FileProvider.IsFileExist("DefaultSettings.json"))
		{
			DefaultSettings = FileProvider.LoadObjectFromJSONFile<Settings>("DefaultSettings.json");
		}
        else
        {
            FileProvider.SaveObjectToJSONFile<Settings>(DefaultSettings, "DefaultSettings.json");
        }

		LoadSettings();

        DontDestroyOnLoad(this.gameObject);	
	}

	private void LoadSettings()
	{
        AudioMixer.audioMixer.SetFloat("Music Volume", Mathf.Lerp(-80, 0, SavedSettings.MusicVolume));
        AudioMixer.audioMixer.SetFloat("FX Volume", Mathf.Lerp(-80, 0, SavedSettings.SoundVolume));

        switch (SavedSettings.Language)
        {
            case Settings.SettingsLanguage.English:
                SetLanguageToEnglish();
                break;

            case Settings.SettingsLanguage.Russian:
                SetLanguageToRussian();
                break;
            default:
                Default();
                break;
        }

        Application.targetFrameRate = 60;
    }

    public void SetLanguageToEnglish()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        SettingsManagerIdentity.SavedSettings.Language = Settings.SettingsLanguage.English;
    }

    public void SetLanguageToRussian()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        SettingsManagerIdentity.SavedSettings.Language = Settings.SettingsLanguage.Russian;
    }

    public void Default()
    {
        SetLanguageToEnglish();
    }
}