using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HUDMenuManager : MonoBehaviour
{
    public static List<HUDMenuManager> instances = new List<HUDMenuManager>();

    private void OnEnable()
    {
        instances.Clear();
        instances.AddRange(GameObject.FindObjectsOfType<HUDMenuManager>());
    }

    private void OnLevelWasLoaded(int level)
    {
        instances.Clear();
        instances.AddRange(GameObject.FindObjectsOfType<HUDMenuManager>());
    }

    public static void SetActiveMenu(string name, bool isActive = true)
    {
        foreach (var menu in instances)
        {
            if (menu.gameObject.name == name || menu.gameObject.name.IndexOf(name) >= 0)
            {
                menu.transform.GetChild(0).gameObject.SetActive(isActive);
            }
        }
    }
}
