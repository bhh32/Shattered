using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void Update()
    {
        float horiz = Input.GetAxis("Horizontal");

        Debug.Log(horiz);

        if (horiz != 0f && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            anim.SetBool("isJetpacking", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isJumping", false);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("isJetpacking", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", true);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJetpacking", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJetpacking", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
        }
    }
}
