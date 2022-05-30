using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Utility class for inventory interactions
/// Manages interactions with the internal player inventory, backpacks, and containers
public class InventoryManager : MonoBehaviour
{
    public void pickUpObject(GameObject obj)
    {
        Interactable objScript = (Interactable) obj.GetComponent(typeof(Interactable));

        /// Is the object a tool?
        if (objScript is Tool)
        {
            if (!PlayerToolbelt.Instance.atCapacity)
            {
                PlayerToolbelt.Instance.equipTool(obj); /// Pass this call on to Toolbelt. Inventory not needed.
            }
            else
            {
                /// Allow player to place into obj inventory
                inventoryManagement(obj);
            }
        }
        else 
        {
            /// Allow player to place obj into inventory
            inventoryManagement(obj);
        }
        Debug.Log("Call recieved in Inventory Manager: pick up object");
    }

    /// Player viewing inventory contents
    private void inventoryManagement()
    {

    }


    /// Player adding item to inventory
    private void inventoryManagement(GameObject obj)
    {

    }


    /// Player is viewing contents of a container
    private void externalInventoryManagement(GameObject container) {}
}
