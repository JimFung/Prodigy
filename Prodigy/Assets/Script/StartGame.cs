using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	private CardboardHead head;
	public Color greyBlue = new Color(0.2F, 0.3F, 0.4F, 0.5F);
	public Color lightBlue = new Color(0.1F, 0.15F, 0.2F, 0.5F);
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (isLookedAt && Cardboard.SDK.CardboardTriggered) { 
			GetComponent<TextMesh>().text = "LOADING";
			GetComponent<Renderer>().material.color = lightBlue;
			Application.LoadLevel("Game");

		}
		// currently looking at object
		else if (isLookedAt) { 
			GetComponent<Renderer>().material.color = greyBlue; 
		} 
		// not looking at object
		else if (!isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.white; 
		}
	}
	
}