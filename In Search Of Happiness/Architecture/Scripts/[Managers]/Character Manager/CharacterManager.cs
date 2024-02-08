using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    public List<GameObject> characters = new List<GameObject>();

    public GameObject character;

    public void Init()
    {
        if (Instance != null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddNewCharacter(GameObject character)
    {
        characters.Add(character);
        SettingsManager.Identity.SaveToBF(characters);
    }

    public void SelectCharacter(GameObject character)
    {
        foreach(GameObject child in characters)
        {
            if(child == character)
            {
                this.character = character;
            }
        }
    }
}
