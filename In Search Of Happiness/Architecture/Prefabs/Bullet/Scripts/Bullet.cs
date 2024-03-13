using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Target.CharacterType characterType;
    [SerializeField][Min(0)] private int damage;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Target>() != null && characterType != collision.gameObject.GetComponent<Target>().CharacterTypeOfGameObject)
        {
            collision.gameObject.GetComponent<Target>().TakeDamage(damage);
        }
    }
}
