using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class AIController : MonoBehaviour
{
    GameObject Player;
    GameObject Enemy;
    public AudioSource audio;
    public AudioClip Footsteps;


    Transform playerT;               // Reference to the player's position.

    NavMeshAgent nav;               // Reference to the nav mesh agent.
    public bool isSeen = false;
    public bool isAttacking;

    void Awake()
    {
        // Set up the references.

        audio = GetComponent<AudioSource>();
        playerT = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();
    }


    void FixedUpdate()

    {
        if (isSeen == true)
        {
            nav.isStopped = true;

        }
        else
        {
            if (nav.isStopped) nav.isStopped = false;
            nav.SetDestination(playerT.position);
            isAttacking = true;
            playFootsteps();
        }


    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Sight")
        {
            isSeen = true;
            isAttacking = false;
        }
        if (col.gameObject.tag == "Player" && (isAttacking))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sight")
        {
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
