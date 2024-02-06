using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int protection;
    [SerializeField] private float speed;

    public float Speed => speed;
    public int Health => health;

    private int maxHealth;
    private int maxProtection;
    private float maxSpeed;

    private void OnEnable()
    {
        maxHealth = health;
        maxProtection = protection;
        maxSpeed = Speed;
    }

    public void TakeDamage(int damage)
    {
        if (protection > 0)
        {
            protection -= damage;
            return;
        }
        health -= damage;

        if(IsDead())
        {
            Kill();
        }
    }

    public void Kill()
    {
        protection = 0;
        health = 0;
    }

    public void SetProtectionToMax()
    {
        protection = maxProtection;
    }

    public void SetHealthToMax()
    {
        health = maxHealth;
    }
    public void SetSpeedToMax()
    {
        speed = maxSpeed;
    }

    public void Heal(int healCount)
    {
        if(healCount < 0)
        {
            return;
        }

        if(health + healCount <= maxHealth)
        {
            health += healCount;
        }
    }

    public void EnlargeSpeed(float speedCount)
    {
        if(speedCount < 0)
        {
            return;
        }

        if(maxSpeed + speedCount > Speed)
        {
            speed += speedCount;
        }      
    }


    public bool IsDead()
    {
        return health <= 0;
    }
}
