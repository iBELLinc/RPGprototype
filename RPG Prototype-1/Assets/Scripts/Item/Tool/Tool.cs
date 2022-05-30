using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Item
{
    // Start is called before the first frame update
    protected void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    protected void Update()
    {
        base.Update();
    }

    protected void equipTool ()
    {
        // If no space is available to equip then attempt to stash tool
    }
    protected void stashTool () {}
}
