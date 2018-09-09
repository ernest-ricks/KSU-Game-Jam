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
        items = new Dictionary<string, string>();
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Key"))
        {
            Debug.Log("Key Cool");
            DoorKey doorKey = other.gameObject.GetComponent(typeof(DoorKey)) as DoorKey;
            string key = "Key_" + doorKey.assignedDoor;
            Debug.Log("Door Key");
            Debug.Log("Hello " + items.Count + "Hello");
            if (!items.ContainsKey(key))
            {
                Debug.Log("Door Tooo");
                items.Add(key, key);
                doorKey.PickUp();
            }
        }
    }
}
