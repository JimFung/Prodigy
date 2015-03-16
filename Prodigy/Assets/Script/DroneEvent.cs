using UnityEngine;
using System.Collections;

public class DroneEvent : MonoBehaviour {

	private static bool trigger;
	private static Rigidbody droneRB;
	private static bool decelerate;
	private float accel = 10f;
	private float decel = -10f;
	private float stop = 0f;

	void Start(){
		trigger = false;
		decelerate = false;
		droneRB = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		if (trigger) {
			//change z vector for droneRB;
			droneRB.AddForce(Vector3.back * accel, ForceMode.Acceleration);
			Debug.Log(droneRB.velocity.magnitude);
			if(droneRB.velocity.magnitude >= 8.0f){
				trigger = false;
				decelerate = true;
				accel *= -1;
			}
		}
		if (decelerate) {
			//code to decelerate
			Debug.Log("Hi!");
			droneRB.useGravity = true;
			droneRB.AddForce(Vector3.back * decel, ForceMode.Impulse);
			Debug.Log(droneRB.velocity.magnitude);
			if(droneRB.velocity.magnitude <= 0.0f){

				decelerate = false;
			}
		}
	}

	public static void triggerDrone(){
		trigger = true;
	}
}
