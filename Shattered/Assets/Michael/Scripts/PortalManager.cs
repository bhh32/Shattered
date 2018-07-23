using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour {


    public Transform portalDestination;
    public EdgeCollider2D collider;
    public Vector2 thing;
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("hit");
        other.transform.position =portalDestination.transform.position ;
    }
}
