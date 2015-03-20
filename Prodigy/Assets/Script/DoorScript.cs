using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	private Animator animator;
	public bool locked;
	private bool doorOpen;
	private bool doorlock;

	//boilerplate
	void Start(){
		doorOpen = false;
		animator = GetComponent<Animator>();
		doorlock = true;
		locked = true;

	}

	//open door
	void OnTriggerEnter(Collider obj){
		if ((obj.gameObject.name == "Drone" || obj.gameObject.name == "Head") && doorlock) {
			doorOpen = true;
			DoorController("Open");
			doorlock = false;
		}
	}

	//close door
	//OnTriggerExit gets called multiple times becuase there are multiple 
	//components attached to the camera that would trigger this method call.
	void OnTriggerExit(Collider obj){

			//this check makes sure that we only send the Close trigger once per open.
		if (doorOpen && (obj.gameObject.name == "Drone" || obj.gameObject.name == "Head")) {
			doorOpen = false;
			doorlock = true;
			DoorController ("Close");

		}
	}

	//Passes the state we want to the state diagram in the animator
	private void DoorController(string state){
		animator.SetTrigger(state);
	}

	public bool isLocked(){
		return locked;
	}

	public void setLocked(bool lockState){
		locked = lockState;
	}
}
