using UnityEngine;
using System.Collections;

public class DroneEvent : MonoBehaviour {

	private static bool trigger;
	private static Rigidbody droneRB;
	private float accel = 5f;

	void Start(){
		trigger = false;
		droneRB = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		if (trigger) {
			//change z vector for droneRB;
			droneRB.AddForce(Vector3.back * accel, ForceMode.Acceleration);
			droneRB.useGravity = true;
		}
	}

	public static void triggerDrone(){
		trigger = true;
	}
}
