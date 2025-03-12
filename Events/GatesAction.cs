using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesAction : AbstractAction
{
    public int switchCount = 3;
    private int counter;

    private void Awake()
    {
        gameObject.SetActive(true);
    }

    public override void Activate()
    {
        counter++;
        if(counter < switchCount)
            return;
        
        gameObject.SetActive(false);
        if (chain != null)
            chain.Activate();
    }
}
