using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// SINGLETON CLASS
/// Manages equiped player tools during gameplay
/// Handles the display of all equipped tools on player and backpacks
public class PlayerToolbelt : MonoBehaviour
{

    private static PlayerToolbelt instance = new PlayerToolbelt();
    public bool atCapacity = false;
    private int toolSlotMax = 4; // 2 front, 2 back
    private GameObject currentTool = null;


    /// Private Constructor
    private PlayerToolbelt() {}


    /// Public Instance Constructor
    public static PlayerToolbelt Instance
    {
        get {return instance;}
    }

    void Start()
    {
        /// Pull equipment data from playerData
    }

    // Update is called once per frame
    void Update()
    {
        /// Check for scroll wheel input in combat stance
        if (Input.mouseScrollDelta.y != 0 && PlayerData.Instance.combatStance) {toolScroll();}

        /// Check for tool durabilities
    }


    /// Switch to tool in next slot
    private void toolScroll()
    {
        if (Input.mouseScrollDelta.y > 0) {}
        if (Input.mouseScrollDelta.y < 0) {}
    }


    /// Equip tool
    public void equipTool (GameObject tool)
    {
        Debug.Log("Tool is being equiped.");
        PlayerData.Instance.addTool(tool); /// Add tool to PlayerData

        // If no tool is currently equip then set toolbelt focus to this new tool
        if (currentTool == null)
        {
            currentTool = tool;
            
            /// Show tool in current focused tool slot

            /// Alter player damage output
            /// Move tool to hand
        }
        // Else display on player in appropriate tool slot
        else
        {
            ///
        }

        /// Update atCapacity variable if needed
        if (PlayerData.Instance.toolCount() >= toolSlotMax) {atCapacity = true;}
    }

    public void dropTool ()
    {
        /// Remove currentTool from PlayerData and move it from Player>equipped_items to World Space>ItemsOnGround
    }
}
