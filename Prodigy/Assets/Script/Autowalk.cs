using UnityEngine;
using System.Collections;

public class Autowalk : MonoBehaviour {
	
	private CardboardHead head;
	private float gazeYPosition;
	private float delay = 0.0f; 
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update() {
		
		gazeYPosition = head.Gaze.direction.y;
		
		GameObject FPSController = GameObject.Find ("Head");
		FPSInputController autowalk = FPSController.GetComponent<FPSInputController> ();
		
		// if looking at object for 2 seconds, enable/disable autowalk
		if (gazeYPosition < -.3) { 
			autowalk.checkAutoWalk = true;
		} else {
			autowalk.checkAutoWalk = false;
		}
	}
}