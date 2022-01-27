using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Will determine what type of item the player is attempting to interact with and handle the interaction
public class Interactable : MonoBehaviour
{
    // Interactables Attributes
    [SerializeField] protected bool debugMode = false;
    [SerializeField] protected string OBJECT_NAME;
    [SerializeField] protected int interactionRadius = 5;
    protected int interactIndex = -1; // CHILD MUST DEFINE


    // Prompt Refs
    protected bool isVisible = false;
    protected string INTERACTIONTEXT_TAG = "Interaction Text";


    // Prompt Dialogue Vars
    protected string PROMPT = "Press E to ";
    protected string[] INTERACTION_TYPE = new string[] {"pick up ","loot ", "enter " ,"speak to "};

    

    // External Refs
    protected string PLAYER_OBJECT = "Player";
    public Transform player;
    protected GameObject pickupText;


    // Called when the script instance is being loaded
    protected void Awake()
    {
        OBJECT_NAME = this.GetType().Name;
        player = GameObject.FindWithTag(PLAYER_OBJECT).transform;
        pickupText = GameObject.FindWithTag(INTERACTIONTEXT_TAG);
    }


    // Update is called once per frame
    protected void Update()
    {
// If more than one object is nearby create a focused object to take priority; Which object is closer?

        // If player nearby and prompt is not visible then activate prompt object in HUD
        if (Vector3.Distance(transform.position, player.position) <= interactionRadius && !pickupText.activeSelf)
        {
            // Debug.Log("Player nearby");
            displayPrompt(interactIndex);
        }

        // If player is outside interaction radius and prompt is visible then deactivate prompt object in HUD
        if (Vector3.Distance(transform.position, player.position) >= interactionRadius && pickupText.activeSelf)
        {
            pickupText.GetComponent<Text>().text = "";
            pickupText.SetActive(false);
        }
    }


    // Alters the prompt to display the proper text depending on the applicable child class for the object
    protected void displayPrompt(int i)
    {
        Debug.Log("Displaying the pick up prompt.");
        pickupText.SetActive(true);
        pickupText.GetComponent<Text>().text = PROMPT + INTERACTION_TYPE[interactIndex] + this.GetType().Name;        
    }


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
