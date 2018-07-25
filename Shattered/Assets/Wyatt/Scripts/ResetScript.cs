using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour 
{
	public GameObject spawn;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag ==("Player"))
		{
			other.gameObject.transform.position = spawn.transform.position;
			Physics2D.gravity = new Vector2 (0, -9.81f);
			other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		}
	}
}
