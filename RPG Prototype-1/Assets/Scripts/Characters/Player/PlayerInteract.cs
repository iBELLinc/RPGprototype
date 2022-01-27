using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private GameObject interactFocus; // This is the interactable object that is closest to the player
    
    private string INTERACT = "Interact";

    protected string PLAYER_OBJECT = "Player";
    public Transform player;
    protected GameObject pickupText;

    // Start is called before the first frame update
    void Start()
    {
        // Collect necessary refs and disable prompt in HUD for gameplay start
        player = GameObject.FindWithTag(PLAYER_OBJECT).transform;
        pickupText = GameObject.FindWithTag(INTERACTIONTEXT_TAG);
        pickupText.SetActive(false);
    }


    // Activates when player interaction collider collides with an object
    void OnTriggerEnter (Collider other)
    {
        // display prompt for closest object
    }


    // Disables the interaction prompt when interaction trigger is false
    void OnTriggerExit ()
    {
        pickupText.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // If player presses E run appropriate method for focused object
        //if (Input.GetButtonDown(INTERACT)) {}
    }


    // Identifies nearest object and sets interaction prompt
    private void displayPrompt()
    {
        // Check for multiple objects
        /// place objects in for loop array
            // Which is closest
            /// calculate distance of each object in array
                // Set focus
                /// set shortest distance to interactFocus
        
        // Set prompt for focused object
    }


    // Player picks up item
    private void interactPickup()
    {
        // Send call to PickupController script for handling
    }

    // Player opens a container or body
    private void interactLoot() {}
    // Player enters a location
    private void interactEnter() {}
    // Player enters dialogue with NPC
    private void interactSpeak() {}
}
