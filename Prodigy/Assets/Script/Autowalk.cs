using UnityEngine;
using System.Collections;

public class Autowalk : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f; 
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	void Update() {
		// if looking at object for 2 seconds, enable/disable autowalk
		if (Cardboard.SDK.CardboardTriggered) { 
			GameObject FPSController = GameObject.Find("Head");
			FPSInputController autowalk = FPSController.GetComponent<FPSInputController>();
			autowalk.checkAutoWalk = !autowalk.checkAutoWalk;
			delay = Time.time + 2.0f;
		}
	}
	
}