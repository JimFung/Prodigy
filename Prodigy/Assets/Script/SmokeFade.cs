using UnityEngine;
using System.Collections;

public class SmokeFade : MonoBehaviour {

	private static ParticleEmitter pEmitter;
	private static bool fade;

	void Start(){
		pEmitter = GetComponent<ParticleEmitter>();
		fade = false;
	}
	void Update(){
		if (fade) {
			if(pEmitter.minEnergy <= 0){ 
				fade = false;
				return;
			}
			pEmitter.minEnergy -= (Time.deltaTime/20);
			pEmitter.maxEnergy = pEmitter.minEnergy;
		}

	}
	public static void startFade(){
		fade = true;
	}
}