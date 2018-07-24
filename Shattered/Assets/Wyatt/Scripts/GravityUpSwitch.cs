using System.Collections;
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

		foreach(Collider2D guyInHood in hood)
		{
			if(guyInHood.tag == ("Player"))
			{
				CanSwitch = true;
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
}
