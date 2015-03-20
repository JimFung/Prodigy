using UnityEngine;
using System.Collections;

public class Keypad : MonoBehaviour{

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
		doorScript.isLocked ();

		distance = Vector3.Distance (this.transform.position, player.transform.position);

		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);

		if (isLookedAt && distance < 2) {
			//player is in range to do something!
			if(keypadActive){
				Debug.Log("keypad active");
				//pad = active; door = unlocked //never happens.
				//pad = active; door = locked
				GetComponent<Renderer> ().material.color = Color.green;
				if(doorScript.isLocked()){
					if(Cardboard.SDK.CardboardTriggered){
						Debug.Log("Unlocked the door");
						doorScript.unlock();
						doorScript.openDoors(GameObject.Find("Head").GetComponent<Collider>());
					}
				}
			} else{
				//TODO: add check of usb key.
				//pad = inactive; door = unlocked //completed state. 
				if(!doorScript.isLocked()){
					return;
				}

				//pad = inactive; door = locked
				Debug.Log("Need to activate keypad!");
				GetComponent<Renderer> ().material.color = Color.red;
			}

		} else {
			GetComponent<Renderer> ().material.color = Color.white;	
			Debug.Log("default");
		}

	}
}