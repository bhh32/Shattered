using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] SpriteRenderer enemy;
    [SerializeField] Vector2 rightBound;
    [SerializeField] Vector2 leftBound;
    [SerializeField] float speed;

	// Update is called once per frame
	void Update ()
    {
        if(transform.position.x > leftBound.x + 1f && transform.position.x < leftBound.x - 1f)
        { }
        else if (transform.position.x >= rightBound.x - 1f)
        {
            enemy.flipX = true;
        }
        else if (transform.position.x <= leftBound.x + 1f)
        {
            enemy.flipX = false;
        }

        if (enemy.flipX)
            transform.Translate(-speed, 0f, 0f);
        else
            transform.Translate(speed, 0f, 0f);
	}
}
