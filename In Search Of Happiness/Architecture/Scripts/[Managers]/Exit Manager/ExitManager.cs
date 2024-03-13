using UnityEngine;

public class ExitManager : MonoBehaviour
{
    private bool isExitShown = false;
    private bool isSceneHaveRightToExit = false;

    private void OnLevelWasLoaded(int level)
    {
        if (level > 1 &&
          level != UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1)
        {
            isSceneHaveRightToExit = true;
        }
        else
        {
            isSceneHaveRightToExit = false;
        }
    }
        
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isSceneHaveRightToExit)
        {
            if(!isExitShown)
            {
                HUDMenuManager.SetActiveMenu("Exit");
                isExitShown = true;
            }
            else
            {
                HUDMenuManager.SetActiveMenu("Exit", false);
                isExitShown = false;
            }
        }

    }
}
