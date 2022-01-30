using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{    
    // Start is called before the first frame update
    protected void Awake()
    {
        base.Awake();
        this.interactIndex = 0;
    }

    // Update is called once per frame
    protected void Update() // Eventually add Q to drop behavior
    {
        base.Update();
        // If player presses E while near this item
    }

    protected void pickupItem ()
    {
        // Identify what type of item this is
        // then equip or stash in inventory (because no equip slots OR because non-equipable item)

    }

}
