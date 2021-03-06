﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityUpSwitch : MonoBehaviour 
{
	public float radius;
	public bool CanSwitch;
	
	void Update () 
	{
		Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		Collider2D[] hood = Physics2D.OverlapCircleAll(pos, radius);
		CanSwitch = false;
		foreach(Collider2D guyInHood in hood)
		{
			if(guyInHood.tag == ("Player"))
			{
				CanSwitch = true;
				break;
			}
			else if(guyInHood.tag != ("Player"))
			{
				CanSwitch = false;
			}
		}
		if(CanSwitch)
		{
			if(Input.GetKey(KeyCode.Space))
			{
				Physics2D.gravity = new Vector2 (0, 9.81f);
			}
		}
	}	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(gameObject.transform.position, radius);
	}
}
