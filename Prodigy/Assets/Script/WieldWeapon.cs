using UnityEngine;
using System.Collections;

public class WieldWeapon : Interactable {
	
	private CardboardHead head;
	public GameObject player;
	float distance = 10.0f;
	GameObject hand;
	public static bool weaponWielded = false;
	private static bool destroyLight;
	
	void Start(){
		player = GameObject.FindWithTag("MainCamera"); // Find the object tagged as MainCamera
		hand = GameObject.Find("CardboardMain/Head/MainCamera/RightHand"); // Find RightHand of MainCamera where we will place Weapon
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	// Update is called once per frame
	void Update () {
		
		distance = Vector3.Distance (this.transform.position, player.transform.position);
		GetComponent<Renderer> ().material.color = Color.white;
		
		if(!weaponWielded){
			
			RaycastHit hit;
			bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
			
			if ((isLookedAt && distance < 2)) {
				
				GetComponent<Renderer> ().material.color = Color.green;
				interacting = true;
				
				if (Cardboard.SDK.CardboardTriggered) {
					
					Debug.Log ("Grabby grab!");
					this.transform.parent = hand.transform; //Parent weapon to RightHand
					this.transform.localPosition = new Vector3 (0, 0, 0); //Center weapon
					this.transform.localRotation = Quaternion.identity; //Reset rotation
					this.transform.localRotation = Quaternion.Euler (0, 0, 0); //Rotate
					this.transform.localScale += new Vector3(-0.5F, -0.5F, -0.5F);
					Destroy(this.collider);
					weaponWielded = true;
					interacting = false;
					WeaponLight.destroyLight();
				}
			}
			if (!isLookedAt){
				interacting = false;
				GetComponent<Renderer> ().material.color = Color.white;
			}
		}	
	}
}