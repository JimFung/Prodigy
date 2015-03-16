using UnityEngine;
using System.Collections;

public class DroneEventTrigger : MonoBehaviour {

	/*
	obj = object entering the trigger zone. (ie. the camera in our case)
	 */
	private static int status;

	void Start(){
		status = 0;
	}

	void OnTriggerEnter(Collider obj){
		if (!(obj.gameObject.name == "rocket") && status == 0) {
			DroneEvent.triggerDrone ();
			status = 1;
		}
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