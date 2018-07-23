using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAddForce : MonoBehaviour {

    public Rigidbody2D rb;
    public Vector2 force;
    public float deathCount;
    public float speed;

    public UnityStandardAssets._2D.PlatformerCharacter2D controller; 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         StartCoroutine(KillRound());
        controller = UnityStandardAssets._2D.PlatformerCharacter2D.instance;
        if (controller.m_FacingRight)
        {
            FireRound();
            print("fire right");
            return;
        }
        else
        {
            FireLeft();
            print("fire left");
            return;
        }
    }

  

    IEnumerator KillRound()
    {

        yield return new WaitForSeconds(deathCount);
        Destroy(this.gameObject);
    }

    void FireRound()
    {
        force.x = speed * 10;
        rb.AddForce(force);
    }

    void FireLeft()
    {
        force.x = speed * 10;
        rb.AddForce(-force);
    }


}
