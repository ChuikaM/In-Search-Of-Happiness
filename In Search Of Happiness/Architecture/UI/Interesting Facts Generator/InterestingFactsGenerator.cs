using System.Collections.Generic;
using UnityEngine;

public class InterestingFactsGenerator : MonoBehaviour
{
    [SerializeField][TextArea(3,5)] private List<string> facts = new List<string>();
    [SerializeField] private TMPro.TextMeshProUGUI TextMeshPro;

    private void OnEnable()
    {
        TextMeshPro.text = facts[Random.Range(0, facts.Count - 1)];
    }
}
