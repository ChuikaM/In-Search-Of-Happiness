using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Settings
{
	public bool ShowFPS;
	public float MusicVolume;
	public float SoundVolume;
	public enum SettingsLanguage {English, Russian};
	public SettingsLanguage Language;
	public List<Vector2> position;
	public List<Vector2> size;
	public int Count {get => position.Count;}
}