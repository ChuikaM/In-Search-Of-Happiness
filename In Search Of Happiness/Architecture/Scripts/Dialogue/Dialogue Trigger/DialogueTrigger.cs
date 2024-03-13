using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private bool autoShow = false;

    private bool visiting = false;
    private bool selecting = false;

    private void Update()
    {
        if(Input.GetAxis("ShowDialogue") > 0 && !autoShow)
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
        else
        {
            HUDMenuManager.SetActiveMenu("Dialogue Suggest");
        }

        if (collision.gameObject.GetComponent<Player>() != null && !visiting)
        {  
            if (selecting || autoShow)
            {
                visiting = true;
                selecting = false;
                HUDMenuManager.SetActiveMenu("Dialogue");
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
