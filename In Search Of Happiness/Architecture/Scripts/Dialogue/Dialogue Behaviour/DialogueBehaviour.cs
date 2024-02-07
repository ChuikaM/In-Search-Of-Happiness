using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI nameOfTeller;
    [SerializeField] private TMPro.TextMeshProUGUI nameOfDialogue;
    [SerializeField] private GameObject buttonNext;

    Queue<Dialogue> dialogues = new Queue<Dialogue>();
    string textOfDialogue;

    public void PrepareForDialogue(List<Dialogue> dialogues)
    {
        this.dialogues.Clear();
        foreach (Dialogue dialogue in dialogues)
        {
            this.dialogues.Enqueue(dialogue);
        }
        nameOfTeller.enabled = true;
        nameOfDialogue.enabled = true;
        buttonNext.SetActive(true);
        NextDialogue();
    }

    public void NextDialogue()
    {
        if(dialogues.Count == 0)
        {
            nameOfTeller.enabled = false;
            nameOfDialogue.enabled = false;
            buttonNext.SetActive(false);
            return;
        }

        Dialogue dialogue = dialogues.Dequeue();
        nameOfTeller.text = dialogue.NameOfTeller;

        textOfDialogue = dialogue.Next;
        StartCoroutine(nameof(ShowDialogue));
    }

    IEnumerator ShowDialogue()
    {           
        foreach(char ch in textOfDialogue)
        {
            textOfDialogue += ch;
            yield return null;
        }
        yield return null;
    }
}
