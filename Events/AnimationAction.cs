using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAction : AbstractAction
{
    public override void Activate()
    {
        GetComponent<Animation>().Play();
        if (chain != null)
            chain.Activate();
    }
}
