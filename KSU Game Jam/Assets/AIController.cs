using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class AIController : MonoBehaviour {
	GameObject Player;
	GameObject Enemy;
	public AudioSource audio;
    public AudioClip Footsteps;
	

	Transform playerT;               // Reference to the player's position.

	NavMeshAgent nav;               // Reference to the nav mesh agent.
	public bool isSeen = false;
	public bool isAttacking;

	void Awake ()
	{
		// Set up the references.
		
		audio = GetComponent<AudioSource>();
		playerT = GameObject.FindGameObjectWithTag ("Player").transform;

		nav = GetComponent <NavMeshAgent> ();
	}


	void FixedUpdate ()
	
	{
		if (isSeen==true) {
			nav.isStopped = true;

		} else

		{
			
			if (nav.isStopped) nav.isStopped = false;
			Debug.Log("Attacking");
			nav.SetDestination (playerT.position);
			isAttacking = true;
			playFootsteps();
		}


	}
	private void OnTriggerEnter(Collider col)
	{
		Debug.Log("Collided");
		if (col.gameObject.tag == "Sight")
		{
			Debug.Log("In Sight");
			isSeen = true;
			isAttacking = false;
		}
		if (col.gameObject.tag == "Player"&& (isAttacking))
		{

            SceneManager.LoadScene("GameOver");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("Left");
		if (other.gameObject.tag == "Sight") {
			Debug.Log("Out Sight");
			isSeen = false;
		}
	}
	public void playFootsteps()
	{
		AudioClip Footsteps = GetComponent<AudioClip>();
		audio.clip = Footsteps;
		audio.Play();
	}
	

}
