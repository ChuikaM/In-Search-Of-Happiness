using UnityEngine;
using Pathfinding;
using System;

[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bot : MonoBehaviour
{
    [Header("Data")]
    [SerializeReference] private float nextWaypointDistance = 3f;
    [SerializeField] private float distanceToShoot = 3f;
    [SerializeField] private float distanceToAngry = 8f;
    [SerializeField] private float jumpForce = 2f;

    [SerializeField] private GameObject deadEffectGameObject;

    private GameObject shootGameObject;

    private int currentWaypoint = 0;

    private bool isMove = true;
    private bool isFlip = false;
    private bool isAttacking = false;

    private Seeker Seeker;
    private Path Path;

    private Transform Target;

    private Animator animator;

    private Target target;

    public Weapon weapon;

    private Rigidbody2D rigidbody2D;

    void OnEnable()
    {
        Initiate();
        target.OnDead += Dead;
    }

    private void Dead()
    {
        Destroy(Instantiate(deadEffectGameObject, transform.position, transform.rotation), 1.5f);
        Destroy(gameObject);
    }

    public void Initiate()
    {
        weapon = transform.GetChild(0).GetComponent<Weapon>();

        Seeker = gameObject.GetComponent<Seeker>();

        target = gameObject.GetComponent<Target>();

        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        animator = gameObject.GetComponent<Animator>();

        Target = GameObject.FindObjectOfType<Player>().transform;

        InvokeRepeating("UpdatePath", 0, 0.5f);
    }

    void UpdatePath()
    {
        if (Seeker.IsDone() && isMove)
        {
            Seeker.StartPath(rigidbody2D.position, Target.position, OnPathComplite);
        }
    }

    void OnPathComplite(Path p)
    {
        if (!p.error)
        {
            Path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, Target.position) < distanceToAngry)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
        
        MovementLogic();
        ShootLogic();
    }

    private void MovementLogic()
    {
        if (Path == null)
        {
            return;
        }

        if (currentWaypoint >= Path.vectorPath.Count)
        { 
            return;
        }

        Vector2 direction = ((Vector2)Path.vectorPath[currentWaypoint] - rigidbody2D.position).normalized;
 
        if (direction.x > 0)
        {
            direction.x = 1;
        }
        else if(direction.x < 0)
        {
            direction.x = -1;
        }
        if(direction.y > 0.5)
        {
            direction.y = 1;
        }
        else if (direction.y < 0.5)
        {
            direction.y = -1;
        }

        if (direction.x > 0)
        {
            if (isFlip)
            {
                transform.Rotate(0, 180, 0);
                isFlip = false;
            }
        }
        else if (direction.x < 0)
        {
            if (!isFlip)
            {
                transform.Rotate(0, 180, 0);
                isFlip = true;
            }
        }

        rigidbody2D.velocity = new Vector2(direction.x * target.Speed, rigidbody2D.velocity.y);

        animator.SetFloat("Movement", Mathf.Abs(direction.x));

        if (Target != null && direction.y > 0 && Vector2.Distance(Target.position, transform.position) > distanceToAngry)
        {
            Jump();
        }
        float distance = Vector2.Distance(rigidbody2D.position, Path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    private void Jump()
    {
        if (Math.Abs(rigidbody2D.velocity.y) < 0.05f)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Stay()
    {
        rigidbody2D.velocity = Vector2.zero;
       
        currentWaypoint = 0;
        isMove = false;
    }

    private void ShootLogic()
    {
        if(Target != null && Vector2.Distance(transform.position, Target.position) < distanceToAngry && !isAttacking)
        { 
            Invoke(nameof(Attack), weapon.RapidityOfFire);
            isAttacking = true;
           // animator.SetBool("Attacking", true);
        }
        else
        {
           // animator.SetBool("Attacking", false);
        }
    }

    public void Attack()
    {
        weapon.Shoot();
        isAttacking = false;
    }
}
