using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField][TextArea] private Dialogue dialogue;
    private bool visiting = false;
    private bool selecting = false;

    private void Update()
    {
        if(Input.GetAxis("ShowDialogue") > 0)
        {
            selecting = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(visiting)
        {
            HUDMenuManager.SetActiveMenu("Dialogue Suggest", false);
        }
        if (collision.gameObject.GetComponent<Player>() != null && !visiting)
        {
            HUDMenuManager.SetActiveMenu("Dialogue Suggest");
            if (selecting)
            {
                visiting = true;
                selecting = false;
                FindObjectOfType<DialogueBehaviour>().PrepareForDialogue(dialogue);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            HUDMenuManager.SetActiveMenu("Dialogue Suggest", false);
        }
    }
}
