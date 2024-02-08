using System.Collections;
using UnityEngine;

public class DialogueBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI nameOfTeller;
    [SerializeField] private TMPro.TextMeshProUGUI textOfDialogue;
    [SerializeField][Min(0)] private float timeToShowACharacter = 0.05f;

    public void PrepareForDialogue(Dialogue dialogue)
    {
        nameOfTeller.enabled = true;
        textOfDialogue.enabled = true;
        ShowDialogue(dialogue);
    }

    private void ShowDialogue(Dialogue dialogue)
    {
        StartCoroutine(ShowDialogueTellerName(dialogue));       
    }

    IEnumerator ShowDialogueTellerName(Dialogue dialogue)
    {
        nameOfTeller.text = "";
        foreach (char ch in dialogue.NameOfTeller.ToCharArray())
        {
            nameOfTeller.text += ch;
            yield return new WaitForSeconds(timeToShowACharacter);
        }
        StartCoroutine(ShowDialogueTellerText(dialogue));
    }

    IEnumerator ShowDialogueTellerText(Dialogue dialogue)
    {
        textOfDialogue.text = "";
        foreach (char ch in dialogue.Text.ToCharArray())
        {
            textOfDialogue.text += ch;
            yield return new WaitForSeconds(timeToShowACharacter);
        }
        yield return new WaitForSeconds(dialogue.TimeToDisappearDialogueBox);
        DisappearDialogue();
    }

    private void DisappearDialogue()
    {
        nameOfTeller.enabled = false;
        textOfDialogue.enabled = false;
    }
}
