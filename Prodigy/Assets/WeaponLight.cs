using UnityEngine;
using System.Collections;

public class WeaponLight : MonoBehaviour {

	private static GameObject self;

	void Start(){
		self = this.gameObject;
	}

	public static void destroyLight(){
		Destroy (self);
	}
}
