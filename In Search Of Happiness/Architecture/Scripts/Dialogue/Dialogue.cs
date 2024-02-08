using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string NameOfTeller;
    [SerializeField][TextArea(3, 5)] private string text;
    [SerializeField] private float timeToDisappearDialogueBox = 2;

    public string Text => text;
    public float TimeToDisappearDialogueBox => timeToDisappearDialogueBox;
}
