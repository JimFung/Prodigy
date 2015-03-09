using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	// Rocket Prefab
	public GameObject rocketPrefab;

	void Update () {
		// left mouse clicked?
		if (Input.GetMouseButtonDown(0)) {
			// spawn rocket
			// Instantiate: throw prefab into the game world
			// GameObject) cast is required because unity is stupid
			// transform.position because we want to instantiate it exactly where the weapon is
			// transform.parent.rotation because the rocket should face the same direction that the player faces (which is the weapon's parent. 
			//   we can't just use the weapon's rotation because the weapon is
			GameObject g = (GameObject)Instantiate(rocketPrefab,
			                                       transform.position,
			                                       transform.parent.rotation);
			
			// make the rocket fly forward by simply calling the rigidbody's AddForce method
			float force = g.GetComponent<Rocket>().speed;
			g.rigidbody.AddForce(g.transform.forward * force);
		}
	}
}