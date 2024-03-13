using UnityEngine;

public class HealUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI textMeshProOfHP;

    private void OnLevelWasLoaded(int level)
    {
        if (level > 1 &&
          level != UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1)
        {
            HUDMenuManager.SetActiveMenu("HP");
            if (FindObjectOfType<Player>() != null)
            {
                FindObjectOfType<Player>().gameObject.GetComponent<Target>().OnHPChanged += ChangeHPText;
                textMeshProOfHP.text = FindObjectOfType<Player>().gameObject.GetComponent<Target>().Health.ToString();
            }
        }
        else
        {
            HUDMenuManager.SetActiveMenu("HP", false);
        }
    }

    private void ChangeHPText(int generalHp)
    {
        textMeshProOfHP.text = generalHp.ToString();
    }
}
