using UnityEngine;

public class CharacterElement : MonoBehaviour
{
    [SerializeField] private GameObject character;

    public void SelectCharacter()
    {
        CharacterChooser.Instance.SetActiveElements(false);
        CharacterManager.Instance.SelectCharacter(character);
    }
}
