using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Rigidbody rb;
    private string INTERACT = "Interact";

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses E
        if (Input.GetButtonDown(INTERACT))
        {
            // Are they near an item that they can pick up? interactPickup();
            if (true) {}
            // Are they near a door or container? => interactOpen();
            // Are they near an NPC? interactSpeak();
        }
    }

    // Player picks up item
    private void interactPickup()
    {
        // Send call to PickupController script for handling
    }

    // Player opens door/container
    private void interactOpen() {}
    // Player enters dialogue with NPC
    private void interactSpeak() {}
}
