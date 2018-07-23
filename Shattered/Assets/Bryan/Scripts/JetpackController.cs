using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackController : MonoBehaviour
{
    public float jetpackFuel = 100f;
    [SerializeField] float thrust;
    bool jetpacking = false;
    [SerializeField] Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        jetpacking = Input.GetKey(KeyCode.Space);
        
    }

    void FixedUpdate()
    {
        if (jetpackFuel > 0f && jetpacking)
        {
            rb.AddRelativeForce(new Vector2(0f, thrust), ForceMode2D.Impulse);
            jetpackFuel -= .25f;
        }
    }
}
