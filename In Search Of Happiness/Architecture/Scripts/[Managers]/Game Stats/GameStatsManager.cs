using UnityEngine;

public class GameStatsManager : MonoBehaviour
{
    public static int KillsOfRed
    {
        get => killsOfRed;
        set
        {
            killsOfRed = value;
            OnEnlargeKills?.Invoke();
        }
    }
    public static int KillsOfBlue
    {
        get => killsOfBlue;
        set
        {
            killsOfBlue = value;
            OnEnlargeKills?.Invoke();
        }
    }

    public static int DeathesOfRed = 0;
    public static int DeathesOfBlue = 0;

    private static int killsOfRed = 0;
    private static int killsOfBlue = 0;

    public static System.Action OnEnlargeKills;

    private void OnLevelWasLoaded(int level)
    {
        KillsOfRed = KillsOfBlue = DeathesOfRed = DeathesOfBlue = 0;
    }
}
