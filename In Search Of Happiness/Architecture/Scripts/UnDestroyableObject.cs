using UnityEngine;

public class UnDestroyableObject : MonoBehaviour
{
    private void OnEnable()
    {
        if(GameObject.Find(gameObject.name) != null && GameObject.Find(gameObject.name) != gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }     
    }

    public static void DestoyObjectByName(string name)
    {
        if(GameObject.Find(name).name == name)
        {
            Destroy(GameObject.Find(name));
        }
    }
}
