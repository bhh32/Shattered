using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalController : MonoBehaviour
{
	public LayerMask layermask;
	public Vector3 gravityDir;
    Rigidbody2D rb;
	public float mSpeed;
	public float Distance;
	public Vector2 gravityVal;
	void Start ()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();	
	}
	

	
	void Update ()
    {
		gravityVal = Physics2D.gravity;
		

		if(Physics2D.gravity == new Vector2 (0, -9.81f))
		{
			gravityDir = Vector2.down;
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else if(Physics2D.gravity == new Vector2 (0, 9.81f))
		{
			gravityDir = Vector2.up;
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
		}
		else if(Physics2D.gravity == new Vector2 (9.81f, 0))
		{
			gravityDir = Vector2.right;
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
		}
		else if(Physics2D.gravity == new Vector2 (-9.81f, 0))
		{
			gravityDir = Vector2.left;
			gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
		}



	    float xAxis = Input.GetAxisRaw("Horizontal");

		if(gravityVal.x == 0)
		{
			rb.velocity = new Vector2(xAxis * mSpeed, rb.velocity.y);
		}
		if(gravityVal.y == 0)
		{
			if(gravityDir.x > 0)
			{
				rb.velocity = new Vector2(rb.velocity.x, xAxis * mSpeed);
			}
			else if (gravityDir.x < 0)
			{
				rb.velocity = new Vector2(rb.velocity.x, xAxis * mSpeed);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			if(IsGrounded() == true)
			{
				rb.AddForce(transform.up * 7, ForceMode2D.Impulse);
			}
		}
	}

	bool IsGrounded()
	{
			
		RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, gravityDir, Distance, layermask);
		
		if(hit.collider != null)
		{
			if(hit.collider.tag == "Floor")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		return false;
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(gameObject.transform.position, gravityDir * Distance);
	}

}
