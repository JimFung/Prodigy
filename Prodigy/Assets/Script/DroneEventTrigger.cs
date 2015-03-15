using UnityEngine;
using System.Collections;

public class DroneEventTrigger : MonoBehaviour {

	/*
	obj = object entering the trigger zone. (ie. the camera in our case)
	 */

	void OnTriggerEnter(Collider obj){
		DroneEvent.triggerDrone();
	}

//	commented for reference sake
//	void OnTriggerStay (Collider obj){
//		Debug.Log ("IT'S DANGEROUS!!!!");
//		Debug.Log (obj.gameObject.name);
//	}
//
//	void OnTriggerExit (Collider obj){
//		Debug.Log ("Leaving THE DANGER ZONE!!");
//	}
}