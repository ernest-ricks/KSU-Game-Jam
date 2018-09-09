using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Rigidbody rigidbody;
    Dictionary<string, string> items;


    // Use this for initialization
    void Start()
    {
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool addItem(string itemName)
    {
        items.Add(itemName, itemName);
        return true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding Inventory");
        if (other.gameObject.tag == ("Key"))
        {
            Debug.Log("Key Cool");
            DoorKey inventory = other.gameObject.GetComponent(typeof(DoorKey)) as DoorKey;
            // bool successfulAdd = inventory.addItem("Key_" + assignedDoor);
            // if (successfulAdd)
            // {
            //     Destroy(this);
            // }
        }
    }
}
