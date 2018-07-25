using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGrabber : MonoBehaviour {

    //public GameObject player;
    public Joint2D joint;
    Rigidbody2D rb;


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            joint.gameObject.SetActive(true);
            rb = joint.connectedBody;
            rb = other.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            Debug.LogWarning("hit");
        
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        joint.gameObject.SetActive(false);
        rb.isKinematic =false;
    }

}
