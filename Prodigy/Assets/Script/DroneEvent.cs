using UnityEngine;
using System.Collections;

public class DroneEvent : MonoBehaviour {

	private static bool trigger;
	private static Rigidbody droneRB;

	void Start(){
		trigger = false;
		droneRB = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		if (trigger) {
			//change z vector for droneRB;
			Debug.Log("Watch your Head");
		}
	}

	public static void triggerDrone(){
		trigger = true;
	}
}
