using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;

public class SettingsManager : MonoBehaviour
{
	public static SettingsManager Identity;
    public Settings SavedSettings;
    public Settings DefaultSettings;

    [SerializeField] private AudioMixerGroup AudioMixer;

    private void OnEnable()
	{
		if(Identity != null)
		{
			Destroy(this.gameObject);
			return;
		}

		Identity = this;

        GameSceneManager.Instance = GetData<GameSceneManager>();
        if(GameSceneManager.Instance == null )
        {
            GameSceneManager.Instance = GameObject.FindObjectOfType<GameSceneManager>();
        }
        GameSceneManager.Instance.Init();
       
        CharacterManager.Instance = GetData<CharacterManager>();
        if (CharacterManager.Instance == null)
        {
            CharacterManager.Instance = GameObject.FindObjectOfType<CharacterManager>();
        }
        CharacterManager.Instance.Init();


        if (FileProvider.IsFileExist("SavedSettings.json"))
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

        GameObject.Find("FPS Label").SetActive(SavedSettings.ShowFPS);

        Load();

        DontDestroyOnLoad(this.gameObject);	
	}

	private void Load()
	{
        if (FileProvider.IsFileExist("SavedSettings.json"))
        {
            FileProvider.GetObjectFromJSONFile<Settings>(Identity.SavedSettings, "SavedSettings.json");
        }
        else
        {
            FileProvider.SaveObjectToJSONFile<Settings>(Identity.SavedSettings, "SavedSettings.json");
            Identity.SavedSettings = Identity.DefaultSettings;
        }

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

    public void Save<T>(T objectToSave, string pathToFile = "SavedSettings.bf")
    {
        FileProvider.SaveToBFFile<T>(objectToSave, "SavedSettings.bf");
    }

    public T GetData<T>(string pathToFile = "SavedSettings.bf")
    {
        T data = FileProvider.LoadFromBFFile<T>(pathToFile);

        return data != null ? data : default(T);
    }

    public void SetLanguageToEnglish()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        Identity.SavedSettings.Language = Settings.SettingsLanguage.English;
    }

    public void SetLanguageToRussian()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        Identity.SavedSettings.Language = Settings.SettingsLanguage.Russian;
    }

    public void Default()
    {
        SetLanguageToEnglish();
    }
}