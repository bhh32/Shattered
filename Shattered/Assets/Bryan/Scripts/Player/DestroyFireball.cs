using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireball : MonoBehaviour
{
    float timer = 0f;
    [SerializeField] float destroyTime = 2f;

	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime % destroyTime;

        if(timer >= destroyTime)
        {
            Destroy(gameObject);            
        }
	}
}
