using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float RapidityOfFire => rapidityOfFire;

    [SerializeField][Min(0)] private float rapidityOfFire;
    [SerializeField] private GameObject bulletGameObject;
    [SerializeField] private AudioSource audioSource;

    private Transform shootTransform;

    private bool shooting = false;

    private void OnEnable()
    {
        shootTransform = transform;
    }

    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            if (!shooting)
            {
                Invoke(nameof(Shoot), rapidityOfFire);
                shooting = true;
            }
        }
    }

    public void Shoot()
    {
        shooting = false;
        Instantiate(bulletGameObject, shootTransform.position, shootTransform.rotation);
        audioSource.Play();

    }
}
