using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f && Input.GetKeyDown(KeyCode.W) ||
                                                Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
        }
    }
}
