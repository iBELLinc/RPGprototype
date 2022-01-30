using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private bool debugMode = false;
    [SerializeField] private int interactionRadius = 5;
    private GameObject interactFocus; // This is the interactable object that is closest to the player
    
    private string INTERACTABLE = "Interactable";

    protected string PLAYER_OBJECT = "Player";
    protected string INTERACTIONTEXT_TAG = "Interaction Text";
    // Prompt Dialogue Vars
    protected string PROMPT = "Press E to ";
    protected string[] INTERACTION_TYPE = new string[] {"pick up ","loot ", "enter " ,"speak to "};
    public Transform player;
    protected GameObject pickupText;
    private List<GameObject> objectsInRange = new List<GameObject>(); // Tracks current nearby objects to calculate distances

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
        // Add object to nearby objects list
        if (other.tag == INTERACTABLE)
        {
            objectsInRange.Add(other.gameObject);
        }
        if (other.tag == INTERACTABLE && interactFocus == null)
        {
            interactFocus = other.gameObject;
            updatePrompt();
        }
    }


    // If focus is null and another obj is currently in radius then display prompt for that item
    void OnTriggerStay (Collider other)
    {
        if (other.tag == INTERACTABLE && objectsInRange.Count > 0)
        {
            GameObject previousFocus = interactFocus; // Save the previous interactFocus for comparison
            float closestDistance = 0;

            // Do distance calc
            for (int i = 0; i < objectsInRange.Count; i++)
            {
                GameObject interactable = objectsInRange[i]; // Get refs to current interactable in list
                float distance = Vector3.Distance(transform.position, interactable.transform.position); // Get distance of current interactable from player
                
                // If interactable is closer than previous objects then set focus to this interactable
                if (distance < closestDistance)
                {
                    closestDistance = distance; // Update closest distance
                    interactFocus = interactable; // Update interactFocus to this object
                }
            }

            // If focus is on new object then update prompt to reflect focus change
            if (interactFocus != previousFocus) {updatePrompt();}
            if (debugMode)
            {
                Debug.Log("Focused Interactable: " + interactFocus.name);
                Debug.Log("Current number of objects in list: " + objectsInRange.Count.ToString());
                for (int i = 0; i < objectsInRange.Count; i++) {Debug.Log("Interactable Objects List: " + objectsInRange[i]);}
            }
        }
    }


    // Disables the interaction prompt when interaction trigger is false
    void OnTriggerExit (Collider other)
    {
        // Stop tracking instances of this object since it is no longer near        
        if (other.tag == INTERACTABLE)
        {
            objectsInRange.Remove(other.gameObject); // Removes object from list
        }

        // If no objects nearby then remove prompt and clear interactFocus var
        if (objectsInRange.Count == 0)
        {
            pickupText.SetActive(false); // Disable prompt
            interactFocus = null; // Clear interactFocus
        }

        if (debugMode) {Debug.Log("Current number of objects in list: " + objectsInRange.Count.ToString());}
    }


    // Update is called once per frame
    void Update()
    {
        // If player presses E run appropriate method for focused object
        //if (Input.GetButtonDown(INTERACT)) {}
    }


    // Sets interaction prompt to current interactFocus
    private void updatePrompt()
    {
        pickupText.SetActive(true);
        string objectName = interactFocus.name;
        Interactable objectScript = (Interactable) interactFocus.GetComponent(typeof(Interactable));
        pickupText.GetComponent<Text>().text = PROMPT + INTERACTION_TYPE[objectScript.getInteractIndex()] + objectName;
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


    /// DEBUG
    // Displays object interaction radius when debugMode = true
    void OnDrawGizmos ()
    {
        if (debugMode)
        {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
    }
}
