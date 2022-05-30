using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// SINGLETON CLASS
/// Handles all calls to saved player data including: skills, inventory, location, reputation, etc
public class PlayerData : MonoBehaviour
{
    /// Playerdata Variables
    public bool combatStance {get; private set;}
    private Dictionary<int, GameObject> equippedTools = new Dictionary<int, GameObject>(); // 4 slots
    // private Dictionary<string, int> playerSkills = new Dictionary<string, int>(); // Skill values
    private List<Item> damageModifiers = new List<Item>(); // Track all equipped objects that modify player damage output
    private int PlayerDamageModifiers; // Tracks all (de)buffs to player damage


    private static PlayerData instance = new PlayerData();

    private PlayerData ()
    {
        /// Retrieve playerData from file
    }

    public static PlayerData Instance 
    {
        get {return instance;}
    }


    /// Saves the current game data to a file
    public int newPlayerData()
    {
        /// Create data for new game save
        //playerSkills.Add("Strength", 0); Use loop here
        //playerSkills.Add("Strength", 0);

        return 0; /// Return 0 if all is well with creation
    }


    /// Saves the current game data to a file
    public int savePlayerData()
    {
        /// Save game data to file

        return 0; /// Return 0 if all is well with save file
    }


    /// Load game from a save file
    private int loadPlayerData()
    {
        return 0; /// Return 0 if all is well with save file
    }


    /// Save world data from file
    private int saveWorldData()
    {
        return 0; /// Return 0 if all is well with world file
    }


    /// Load world data from file
    private int loadWorldData()
    {
        return 0; /// Return 0 if all is well with world file
    }


    /// Adds tool too PlayerData.equippedTools<>
    public void addTool (GameObject toolToAdd)
    {
        if (equippedTools.Count < 4)
        {
            equippedTools.Add(equippedTools.Count + 1, toolToAdd); // Adds the tool in the next empty slot
        }
        else // Failsafe incase atCapacity was not updated properly
        {
            PlayerToolbelt.Instance.atCapacity = true; /// Update capacity variable

            /// Open inventory so that player can store in inventory if desired
            InventoryManager im = new InventoryManager();
            im.pickUpObject(toolToAdd);
        }

        Debug.Log("Number of tools in equippedTools: " + equippedTools.Count);
    }


    /// Removes tool too PlayerData.equippedTools<>
    public void removeTool (GameObject toolToRemove) {}

    public int toolCount() {return equippedTools.Count;}
}
