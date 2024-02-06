using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioBehaviour : MonoBehaviour
{
    private SettingsManager SettingsManagerIdentity;
	[SerializeField] private Slider SliderMusicVolume;
	[SerializeField] private Slider SliderFXVolume;

    [SerializeField] private AudioMixerGroup AudioMixer;

	private void OnEnable()
	{
        SettingsManagerIdentity = GameObject.FindObjectOfType<SettingsManager>();
        Load();
	}

    private void Load()
	{
        if(SliderMusicVolume == null || SliderFXVolume == null)
        {
            return;
        }
		SliderMusicVolume.value = SettingsManagerIdentity.SavedSettings.MusicVolume;
		SliderFXVolume.value = SettingsManagerIdentity.SavedSettings.SoundVolume;
	}

    public void ChangeValueOfMusic(float volume)
    {
        if(AudioMixer != null)
        {
            AudioMixer.audioMixer.SetFloat("Music Volume", Mathf.Lerp(-80,0,volume));
        }
        SettingsManagerIdentity.SavedSettings.MusicVolume = volume;
    }

    public void ChangeValueOfFX(float volume)
    {
        if(AudioMixer != null)
        {
            AudioMixer.audioMixer.SetFloat("FX Volume", Mathf.Lerp(-80,0,volume));
        }   
        SettingsManagerIdentity.SavedSettings.SoundVolume = volume;
    }	

	public void Default()
	{
		SettingsManagerIdentity.SavedSettings.MusicVolume = SettingsManagerIdentity.DefaultSettings.MusicVolume;
		SettingsManagerIdentity.SavedSettings.SoundVolume = SettingsManagerIdentity.DefaultSettings.SoundVolume;
	}	
}
