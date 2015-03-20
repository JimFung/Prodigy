using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform player;
	NavMeshAgent nav;
	
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag("MainCamera").transform;
		nav = GetComponent <NavMeshAgent> ();
	}
	
	
	void LateUpdate ()
	{
		nav.SetDestination (player.position);
		transform.LookAt (player);

	} 
}