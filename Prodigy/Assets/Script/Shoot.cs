using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	// Rocket Prefab
	public GameObject rocketPrefab;

	void Update() {
		if (Cardboard.SDK.CardboardTriggered && WieldWeapon.weaponWielded && !Interactable.interacting) {

			GameObject g = (GameObject)Instantiate(rocketPrefab,
			                                       transform.position,
			                                       transform.parent.rotation);

			float force = g.GetComponent<Rocket>().speed;
			g.rigidbody.AddForce(g.transform.forward * force);
		}
	}
}