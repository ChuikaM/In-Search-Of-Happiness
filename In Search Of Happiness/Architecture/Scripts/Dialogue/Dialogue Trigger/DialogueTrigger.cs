using UnityEngine;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<Dialogue> dialogues = new List<Dialogue>();
    private bool visiting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null && !visiting)
        {
            visiting = true;
            FindObjectOfType<DialogueBehaviour>().PrepareForDialogue(dialogues);          
        }
    }
}
