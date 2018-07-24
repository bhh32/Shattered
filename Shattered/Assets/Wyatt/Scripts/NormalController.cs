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
	void Start ()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();	
	}
	

	
	void Update ()
    {
		if(Physics2D.gravity == new Vector2 (0, -9.81f))
		{
			gravityDir = Vector2.down;
		}
		else if(Physics2D.gravity == new Vector2 (0, 9.81f))
		{
			gravityDir = Vector2.up;
		}
		else if(Physics2D.gravity == new Vector2 (9.81f, 0))
		{
			gravityDir = Vector2.right;
		}
		else if(Physics2D.gravity == new Vector2 (-9.81f, 0))
		{
			gravityDir = Vector2.left;
		}


	    float xAxis = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(xAxis * mSpeed, rb.velocity.y);
		
		if(Input.GetKeyDown(KeyCode.W))
		{
			if(IsGrounded() == true)
			{
				rb.velocity += new Vector2(rb.velocity.x, 5);
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
