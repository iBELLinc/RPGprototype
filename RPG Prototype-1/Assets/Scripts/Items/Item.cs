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
    protected void Update()
    {
        base.Update();
    }

}
