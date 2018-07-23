using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooter : MonoBehaviour {


    public GameObject fireball;
    public Transform shootPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire3"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        GameObject round = Instantiate(fireball, shootPoint.transform.position, fireball.transform.rotation);
    }
}
