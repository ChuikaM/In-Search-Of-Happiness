using System;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public static System.Action OnTeleported;
    public static bool Teleporting = false;
    [SerializeField] private Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!Teleporting)
        {        
            OnTeleported?.Invoke();
            collision.gameObject.transform.position = spawnPoint.position;
            Teleporting = true;
        }      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Teleporting = false;
    }
}
