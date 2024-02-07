using UnityEngine;

public class Weapon : MonoBehaviour
{ 
    [SerializeField][Min(0)] private float rapidityOfFire;
    [SerializeField] private GameObject bulletGameObject;
    
    private Transform shootTransform;

    private bool shooting = false;

    private void OnEnable()
    {
        shootTransform = transform;
    }

    private void Update()
    {
        if (Input.GetAxis("Fire 1") > 0)
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
    }
}
