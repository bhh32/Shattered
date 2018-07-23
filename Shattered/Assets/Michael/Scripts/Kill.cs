using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public float deathCount = 2f;

    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(deathCount);
        Destroy(gameObject);
    }


}
