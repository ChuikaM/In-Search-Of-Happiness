using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Dialogue
{
    public string NameOfTeller;
    [SerializeField] private List<string> texts = new List<string>();
    
    public string Next
    {
        get 
        {
            texts.GetEnumerator().MoveNext();
            return texts.GetEnumerator().Current;
        }
    }
}
