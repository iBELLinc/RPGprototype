using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// These are global vars that may need to be updated across the entire project. This makes future edits easier hopefully.
// DO NOT ALTER THESE VALUES IN OTHER SCRIPTS ! ! !
public class GameManager : MonoBehaviour
{
    // Game Object Refs
    public readonly string PLAYER_OBJECT = "Player";

    // Object Tag Refs
    public readonly string GROUND_TAG = "Ground";

    // Axis Refs
    public readonly string HORZ_AXIS = "Horizontal", VERT_AXIS = "Vertical";

    // Button Refs
    public readonly string SPRINT_BUTTON = "Sprint", JUMP_BUTTON = "Jump";

    // public static string getTag(string s)
    // {
    //     if (s.ToLower() == "player") {return PLAYER_OBJECT;}
    //     else if (s.ToLower() == "ground") {return GROUND_TAG;}
    //     else if (s.ToLower() == "jump") {return JUMP_BUTTON;}
    //     else if (s.ToLower() == "horizontal") {return HORZ_AXIS;}
    //     else if (s.ToLower() == "vertical") {return VERT_AXIS;}
    //     else if (s.ToLower() == "sprint") {return SPRINT_BUTTON;}
    //     else  // Add extra tags above here
    //     {
    //         Debug.Log("Tag requested was not valid. Error in call to ProjectReferences.cs");
    //         return "ERROR";
    //     }
    // }
}
