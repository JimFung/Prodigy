using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private Animator animator;
	private bool doorOpen;

	//boilerplate
	void Start(){
		doorOpen = false;
		animator = GetComponent<Animator>();
	}

	//open door
	void OnTriggerEnter(Collider obj){

		if (obj.gameObject.name == "Head") {
			doorOpen = true;
			DoorController("Open");
		}
	}

	//close door
	//OnTriggerExit gets called multiple times becuase there are multiple 
	//components attached to the camera that would trigger this method call.
	void OnTriggerExit(Collider obj){

		//this check makes sure that we only send the Close trigger once per open.
		if (doorOpen) {
			doorOpen = false;
			DoorController("Close");
		}

	}

	//Passes the state we want to the state diagram in the animator
	private void DoorController(string state){
		animator.SetTrigger(state);
	}
}
