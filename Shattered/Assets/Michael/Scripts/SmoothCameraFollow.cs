using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 desPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;
        transform.LookAt(target);
	}
}
