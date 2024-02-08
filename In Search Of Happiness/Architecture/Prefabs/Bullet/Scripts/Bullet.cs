using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField][Min(0)] private float shootForce;
    [SerializeField][Min(0)] private float timeToDestroy;
    private new Rigidbody2D rigidbody2D;
    private void OnEnable()
    {
        TryGetComponent<Rigidbody2D>(out rigidbody2D);
        if(rigidbody2D != null)
        {
            rigidbody2D.velocity = transform.right * shootForce;
        }
        Destroy(gameObject, timeToDestroy);
    }
}
