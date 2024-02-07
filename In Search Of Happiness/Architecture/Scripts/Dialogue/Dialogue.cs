using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string NameOfTeller;
    [SerializeField] private string text;

    public string Text => text;
}
