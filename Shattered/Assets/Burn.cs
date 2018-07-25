using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour {

    SpriteRenderer spriteRender;
    public ParticleSystem particle; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FireBall")
        {
            Debug.LogWarning("fireball hit");
            gameObject.SetActive(false);
            particle.gameObject.SetActive(true);
        }
    }


}
