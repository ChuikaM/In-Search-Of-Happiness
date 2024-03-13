using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Target))]
public class Player : MonoBehaviour
{
    public bool IsFlip = false;

    [SerializeField] private float jumpForce = 20f;

	private Animator animator;

    private Rigidbody2D rigidbody2D;
	private BoxCollider2D boxCollider2D;

    private Target target;
	
	private bool onGround = false;

	private float movementX = 0;

    private void OnEnable()
	{
		gameObject.TryGetComponent<Animator>(out animator);
        gameObject.TryGetComponent<Rigidbody2D>(out rigidbody2D);
        gameObject.TryGetComponent<BoxCollider2D>(out boxCollider2D);
        gameObject.TryGetComponent<Target>(out target);

		target.OnDead += Dead;
    }

    private void Dead()
    {
		GameSceneManager.Instance.Restart();
    }

    private void Update()
	{
		MovementLogic();
        if (Input.GetAxis("Fire1") > 0)
		{
            animator?.SetBool("Attacking", true);
        }
		else
		{
            animator?.SetBool("Attacking", false);
        }

    }

    private void FixedUpdate()
	{
        rigidbody2D.velocity = new Vector2(movementX * target.Speed, rigidbody2D.velocity.y);
		rigidbody2D.WakeUp();
    }

	private void MovementLogic()
	{
        movementX = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Jump") > 0)
        {
            Jump();
		}
		

		if (movementX > 0)
		{
			goRight();
		}
		else if (movementX < 0)
		{
			goLeft();
		}
		else
		{
			movementX = 0;
		}

        animator?.SetFloat("Movement", Mathf.Abs(movementX));
        animator?.SetBool("Grounding", Mathf.Abs(rigidbody2D.velocity.y) < 0.5f);
    }

	private void goRight()
	{
        movementX = 1f;

        if (IsFlip)
        {
            transform.Rotate(0, 180, 0);
            IsFlip = false;
        }
    }

	private void goLeft()
	{
        movementX = -1f;

        if (!IsFlip)
        {
            transform.Rotate(0, 180, 0);
            IsFlip = true;
        }
    }

    private void Jump()
	{
		Collider2D collider = Physics2D.OverlapBox(new Vector2(boxCollider2D.bounds.max.x, boxCollider2D.bounds.max.y), new Vector2(boxCollider2D.size.x, 1), 0);
		if ((Math.Abs(rigidbody2D.velocity.y) < 0.05f && collider == null) || onGround)
		{
            animator?.SetBool("Grounding", true);
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			onGround = false;
        }
		else
		{
            animator?.SetBool("Grounding", false);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
	{
		onGround = true;
		if (collision.gameObject.tag == "Platform")
		{
			base.transform.parent = collision.transform;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
        onGround = false;
        if (collision.gameObject.tag == "Platform")
		{
			base.transform.parent = null;
        }
	}
}
