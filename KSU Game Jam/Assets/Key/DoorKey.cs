using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{

    public string assignedDoor;
    AudioSource audioData;
    MeshFilter meshFilter;

    // // Use this for initialization
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        meshFilter = GetComponent<MeshFilter>();
        Debug.Log("Key Start");
    }

    // // Update is called once per frame
    void Update()
    {
    }

    // void OnTriggerEnter(Collider other)
    // {

    // }

    public void PickUp()
    {
        audioData.Play(0);
        Debug.Log("Pick up log");
        Destroy(this.meshFilter);
        Destroy(this.gameObject, .180F);
    }
}

