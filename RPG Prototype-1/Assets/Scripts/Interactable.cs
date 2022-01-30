using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Will determine what type of item the player is attempting to interact with and handle the interaction
public class Interactable : MonoBehaviour
{
    // Interactables Attributes
    [SerializeField] protected bool debugMode = false;
    public int interactIndex = -1; // ***CHILD CATEGORIES _MUST_ DEFINE***


    // Called when the script instance is being loaded
    protected void Awake() {}


    // Update is called once per frame
    protected void Update() {}


    // Return interactIndex
    public int getInteractIndex() {return interactIndex;}
}
