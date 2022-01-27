using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Will determine what type of item the player is attempting to interact with and handle the interaction
public class Interactable : MonoBehaviour
{
    [SerializeField]
    protected int interactionRadius = 5;
    [SerializeField]
    protected bool debugMode = false;
    protected bool isVisible = false;
    protected int interactIndex = -1;
    protected string PROMPT = "Press E to ";
    protected string[] INTERACTION_TYPE = new string[] {"pick up ","open ","speak to "};
    protected string PLAYER_OBJECT = "Player";
    protected string INTERACTIONTEXT_TAG = "Interaction Text";
    [SerializeField]
    protected string OBJECT_NAME;
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
        // Debug.Log("Player " + Vector3.Distance(transform.position, player.position) + " from object.");
        // If player nearby, then display prompt
        if (Vector3.Distance(transform.position, player.position) <= interactionRadius)
        {
            // Debug.Log("Player nearby");
            displayPrompt(interactIndex);
        }
        if (Vector3.Distance(transform.position, player.position) >= interactionRadius && pickupText.activeSelf)
        {
            pickupText.GetComponent<Text>().text = "";
            pickupText.SetActive(false);
        }
    }

    // Displays object interaction radius
    void OnDrawGizmos ()
    {
        if (debugMode)
        {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
    }

    // Alters the prompt to display the proper text depending on the applicable child class for the object
    protected void displayPrompt(int i)
    {
        //Debug.Log("Inside displayPrompt");
        pickupText.SetActive(true);
        pickupText.GetComponent<Text>().text = PROMPT + INTERACTION_TYPE[interactIndex] + this.GetType().Name;        
    }
}
