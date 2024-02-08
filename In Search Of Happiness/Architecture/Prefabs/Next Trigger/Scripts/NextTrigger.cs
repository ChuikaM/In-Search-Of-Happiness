using UnityEngine;

public class NextTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameSceneManager.Instance.Next();
    }
}
