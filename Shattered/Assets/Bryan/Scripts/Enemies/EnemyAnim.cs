using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] Animator anim;

    void Start()
    {
        anim.SetFloat("Speed", 1f);    
    }
}
