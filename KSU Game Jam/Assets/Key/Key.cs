using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public string assignedDoor;
	
	// // Use this for initialization
	// void Start () {
	// }
	
	// // Update is called once per frame
	// void Update () {
	// }

	/**
	Destroys Key and returns the assigned door
	 */
	public string Destroy(){
		Destroy(this);
		return assignedDoor;
	}
}

