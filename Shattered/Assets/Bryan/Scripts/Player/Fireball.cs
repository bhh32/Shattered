using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] Transform fireballOrigin;
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] float fireballForce;
    bool isFiring = false;


    void Update()
    {
        isFiring = Input.GetKeyDown(KeyCode.F);

    }

    void FixedUpdate()
    {
        if(renderer.flipX)
        {
            fireballOrigin.localPosition = new Vector3(-.23f, fireballOrigin.localPosition.y);
        }
        else
        {
            fireballOrigin.localPosition = new Vector3(.23f, fireballOrigin.localPosition.y);
        }

        if(isFiring)
        {
            GameObject newFireball = Instantiate(fireballPrefab, fireballOrigin.position, Quaternion.identity) as GameObject;

            if (renderer.flipX)
                newFireball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(Vector2.left.x * fireballForce, 0f), ForceMode2D.Impulse);
            else
                newFireball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(Vector2.right.x * fireballForce, 0f), ForceMode2D.Impulse);
        }
    }
}
