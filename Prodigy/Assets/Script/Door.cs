using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private Animator animator;
	private bool doorOpen;
	private bool doorlock;
	public GameObject enemyDronePrefab;

	//boilerplate
	void Start(){
		doorOpen = false;
		animator = GetComponent<Animator>();
		doorlock = true;
	}

	//open door
	void OnTriggerEnter(Collider obj){
		if ((obj.gameObject.name == "Drone" || obj.gameObject.name == "Head") && doorlock) {
			doorOpen = true;
			DoorController("Open");
			doorlock = false;

			if(obj.gameObject.name == "Head")
			{
				randomDroneSpawn();
			}
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

	void randomDroneSpawn(){
		if (Random.value > .4) {
			GameObject g = (GameObject)Instantiate(enemyDronePrefab,
			                                       transform.position + new Vector3(5f,0.0f,0.0f),
			                                       transform.parent.rotation);
		}
	}

}
