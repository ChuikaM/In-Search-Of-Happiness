using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int protection;
    public float Speed = 3f;
    public int Health { get { return health; } }
    public enum Team {Blue, Red};
    public Team team;

    public System.Action OnTeamChanged;
    public System.Action<Team> OnDead;

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
        
        
        if(health < 0.3 * maxHealth && !IsDead())
        {
            gameObject.GetComponent<Animator>().SetBool("Lowing", true);
        }
        else if(!IsDead())
        {
            gameObject.GetComponent<Animator>().SetTrigger("OnInjure");
        }

        if(IsDead())
        {
            Kill();
        }
    }

    public void Kill()
    {
        protection = 0;
        health = 0;

        switch(team)
        {
            case Team.Blue:
                ++GameStatsManager.KillsOfRed;
                ++GameStatsManager.DeathesOfBlue;
                break;
            case Team.Red:
                ++GameStatsManager.KillsOfBlue;
                ++GameStatsManager.DeathesOfRed;
                break;
        }

        OnDead?.Invoke(team);
    }

    public void WearBroofBulletWest()
    {
        protection = maxProtection;
    }

    public void RegenerateHealth()
    {
        health = maxHealth;
    }

    public void Heal(int count)
    {
        if(health + count <= maxHealth)
        {
            health += count;
        }
        if (health > 0.3 * maxHealth)
        {
            gameObject.GetComponent<Animator>().SetBool("Lowing", false);
        }
    }

    public void EnlargeSpeed(float count)
    {
        if(count < 0)
        {
            return;
        }

        if(maxSpeed + count > Speed)
        {
            Speed += count;
        }      
    }

    public void ReturnSpeed()
    {
        Speed = maxSpeed;
    }

    public bool IsDead()
    {
        return health <= 0;
    }

  

    public void SetTeam(Team team)
    {
        this.team = team;
        OnTeamChanged?.Invoke();
    }
}
