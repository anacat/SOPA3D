using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spill : MonoBehaviour {

public Transform castRight;

private void Update() {
	 RaycastHit hit;
       
        Physics.Raycast(castRight.position, castRight.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);
		Debug.Log(hit.normal);
        //{
            //Debug.DrawRay(castRight.position, castRight.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");

        //}
    
	Vector3 forward = castRight.TransformDirection(Vector3.forward) * 10;
    Debug.DrawRay(castRight.position, forward, Color.green);
}


}
