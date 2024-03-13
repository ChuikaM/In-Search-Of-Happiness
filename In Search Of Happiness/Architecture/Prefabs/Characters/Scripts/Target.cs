using UnityEngine;

public class Target : MonoBehaviour
{
    public enum CharacterType { Player, Bot };
    public CharacterType CharacterTypeOfGameObject => characterType;
    public System.Action OnDead;
    public System.Action<int> OnHPChanged;

    [SerializeField] private CharacterType characterType;
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

        if(IsPlayerComponentExists())
        {
            EffectManager.PlayEffect("Injure Effect");
        }

        OnHPChanged?.Invoke(health);

        if (IsDead())
        {
            Kill();
        }
    }

    public void Kill()
    {
        protection = 0;
        health = 0;
        OnDead?.Invoke();
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
            OnHPChanged?.Invoke(health);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("KillArea"))
        {
            OnDead?.Invoke();
        }
    }

    public bool IsPlayerComponentExists()
    {
        return gameObject.GetComponent<Player>() != null;
    }

    public bool IsBotComponentExists()
    {
        return gameObject.GetComponent<Bot>() != null;
    }
}
