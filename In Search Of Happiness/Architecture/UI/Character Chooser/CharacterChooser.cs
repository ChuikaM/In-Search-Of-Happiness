using System.Collections.Generic;
using UnityEngine;

public class CharacterChooser : MonoBehaviour
{
    public static CharacterChooser Instance;
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();

    private bool showing = false;

    private void OnEnable()
    {
       
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level > 0 &&
           level != UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1)
        {
            showing = true;
        }
        else
        {
            showing = false;
        }
    }

    private void Update()
    {
        if(Input.GetAxis("ShowCharacterChooser") > 0 && showing)
        {
            SetActiveElements();
        }
        else
        {
            SetActiveElements(false);
        }
    }

    public void SetActiveElements(bool enabled = true)
    {
        foreach(GameObject button in buttons)
        {
            button.SetActive(enabled);
        }
    }
}
