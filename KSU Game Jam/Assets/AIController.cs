using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIController : MonoBehaviour {
	GameObject FPSController;
	Transform player;               // Reference to the player's position.

	NavMeshAgent nav;               // Reference to the nav mesh agent.
	bool isSeen = false;

	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		nav = GetComponent <NavMeshAgent> ();
	}


	void Update ()
	{
		if (isSeen==true) {
			Debug.Log ("Stop");

		} else {
			nav.SetDestination (player.position);
		}

	}

}
