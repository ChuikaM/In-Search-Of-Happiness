using UnityEngine;

public class HUDMenuBehaviour : MonoBehaviour
{
    public void ShowMenu(string name)
    {
        HUDMenuManager.SetActiveMenu(name, true);
    }

    public void DisappearMenu(string name)
    {
        HUDMenuManager.SetActiveMenu(name, false);
    }
}
