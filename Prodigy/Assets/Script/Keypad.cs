using UnityEngine;
using System.Collections;

public class Keypad : Interactable {

	private CardboardHead head;
	private GameObject player;
	public GameObject doorObj;
	private DoorScript doorScript;
	float distance = 10.0F;
	public bool keypadActive;

	void Start(){

		player = GameObject.FindWithTag("MainCamera"); // Find the object tagged as MainCamera
		head = Camera.main.GetComponent<StereoController>().Head;
	}

	void Update(){

		doorScript = doorObj.GetComponent<DoorScript> ();

		distance = Vector3.Distance (this.transform.position, player.transform.position);

		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		Debug.Log (keypadActive);
		if (isLookedAt && distance < 2) {
			//player is in range to do something!
			if(keypadActive){
				//pad = active; door = unlocked //never happens.
				//pad = active; door = locked
				GetComponent<Renderer> ().material.color = Color.green;
				interacting = true;
				if(doorScript.isLocked()){
					if(Cardboard.SDK.CardboardTriggered){
						doorScript.unlock();
						doorScript.openDoors(GameObject.Find("Head").GetComponent<Collider>());
						keypadActive = false;
					}
				}
			} else {
				//pad = inactive; door = unlocked //completed state. 
				if(!doorScript.isLocked()){
					GetComponent<Renderer> ().material.color = Color.white;	
					return;
				}

				//pad = inactive; door = locked
				GetComponent<Renderer> ().material.color = Color.red;
				interacting = true;
			}

		} else {
			GetComponent<Renderer> ().material.color = Color.white;	
			interacting = false;
		}

	}

	public void gotKey(){
		keypadActive = true;
	}
}