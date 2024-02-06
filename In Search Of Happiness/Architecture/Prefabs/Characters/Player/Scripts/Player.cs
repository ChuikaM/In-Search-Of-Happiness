using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Target))]
public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 20f;

	private Animator animator;

    private Rigidbody2D rigidbody2D;

	private Target target;

	private bool isFlip = false;
	private bool onGround = false;

	private float movementX = 0;

    private void OnEnable()
	{
		gameObject.TryGetComponent<Animator>(out animator);
        gameObject.TryGetComponent<Rigidbody2D>(out rigidbody2D);
        gameObject.TryGetComponent<Target>(out target);
    }

	private void Update()
	{
		MovementLogic();
	}

    private void FixedUpdate()
	{
        rigidbody2D.velocity = new Vector2(movementX * target.Speed, rigidbody2D.velocity.y);
    }

	private void MovementLogic()
	{
        movementX = Input.GetAxisRaw("Horizontal");

        animator?.SetFloat("Movement", Mathf.Abs(movementX));
        animator?.SetBool("Grounding", Mathf.Abs(rigidbody2D.velocity.y) < 0.05f);

        if (Input.GetAxisRaw("Jump") > 0)
        {
            Jump();
        }

		if(movementX > 0)
		{
			goRight() ;
		}
		else if(movementX < 0)
		{
			goLeft();
		}
		else
		{
			movementX = 0;
		}
    }

    private void goRight()
	{
        movementX = 1f;
        if (isFlip)
        {
            transform.Rotate(0, 180, 0);
            isFlip = false;
        }
    }

	private void goLeft()
	{
        movementX = -1f;
        if (!isFlip)
        {
            transform.Rotate(0, 180, 0);
            isFlip = true;
        }
    }

    private void Jump()
	{
		if (Math.Abs(rigidbody2D.velocity.y) < 0.05f || onGround)
		{
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			onGround = false;
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
