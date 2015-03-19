using UnityEngine;
using System.Collections;

public class DroneEvent : MonoBehaviour {

	private static bool trigger;
	private Animator animator;
	private static bool decelerate;
	private static Rigidbody droneRB;
	private float accel = 10f;
	private float decel = -2f;

	void Start(){
		trigger = false;
		decelerate = false;
		droneRB = GetComponent<Rigidbody>();
		//So that the drone ignores the camera
		Physics.IgnoreLayerCollision (9, 8,true);
		animator = GetComponent<Animator> ();
	}

	/*
	ALL NUMBERS IN THIS FUNCTION ARE MAGIC NUMBERS CREATED AFTER YEARS OF 
	STUDY AND TRAINING. ONLY EDIT IF YOU'RE AT LEAST A LEVEL 9001 ARCHMAGE!
	 */
	void FixedUpdate () {

		if (trigger) {
			//change z vector for droneRB;
			droneRB.AddForce(Vector3.back * accel, ForceMode.Acceleration);
			if(droneRB.velocity.magnitude >= 8.9f){
				trigger = false;
				decelerate = true;
			}
		}
		if (decelerate) {
			//code to decelerate
			droneRB.useGravity = true;
			droneRB.AddForce(Vector3.back * decel, ForceMode.Acceleration);
			if(droneRB.velocity.z >= -4.0f){
				Destroy(animator);
			}
			if(droneRB.velocity.z >= 0.0f){
				decelerate = false;
				droneRB.velocity= Vector3.zero;
				Physics.IgnoreLayerCollision (9, 8,false);
				SmokeFade.startFade();
			}
		}
	}

	public static void triggerDrone(){
		trigger = true;
	}
}
