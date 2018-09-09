using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{

    public string assignedDoor;

    // // Use this for initialization
    void Start()
    {
        Debug.Log("Key Start");
    }

    // // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collision other)
    {
        Debug.Log("Colliding");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Key Cool");
            Inventory inventory = other.gameObject.GetComponent(typeof(Inventory)) as Inventory;
            bool successfulAdd = inventory.addItem("Key_" + assignedDoor);
            if (successfulAdd)
            {
                Destroy(this);
            }
        }
    }
}

