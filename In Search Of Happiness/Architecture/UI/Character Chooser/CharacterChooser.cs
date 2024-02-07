using System.Collections.Generic;
using UnityEngine;

public class CharacterChooser : MonoBehaviour
{
    public static CharacterChooser Instance;
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();

    private bool showing = false;

    private void OnEnable()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetAxis("ShowCharacterChooser") > 0)
        {
            SetActiveElements();
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
