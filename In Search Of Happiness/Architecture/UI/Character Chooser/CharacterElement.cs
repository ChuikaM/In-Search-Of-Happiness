using UnityEngine;

public class CharacterElement : MonoBehaviour
{
    [SerializeField] private GameObject character; 
    [SerializeField] private KeyCode keyCode;

    private void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            SelectCharacter();
        }
    }

    public void SelectCharacter()
    {
        CharacterChooser.Instance.SetActiveElements(false);
        CharacterManager.Instance.SelectCharacter(character);

        EffectManager.PlayEffect("Switching");

        GameObject playerGameObject = GameObject.FindObjectOfType<Player>().gameObject;
        GameObject clone = Instantiate(character, playerGameObject.transform.position, playerGameObject.transform.rotation);
        clone.GetComponent<Player>().IsFlip = clone.transform.rotation.y < 0 ? true : false;

        CameraFollower.Instance.TargetTransform = clone.transform;
        Destroy(playerGameObject);
    }
}
